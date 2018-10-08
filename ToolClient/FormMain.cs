using ServerBase.BaseObjects;
using ServerBase.Client;
using ServerBase.Protocol;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace ToolSimulator
{
    public partial class FormMain : Form, IUtilLoger
    {
        public FormMain()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = 3;
            this.Closed += new System.EventHandler(this.Form_Closed);
        }

        private void Form_Closed(object sender, EventArgs e)
        {
            isLogined = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            comboBox1.SelectedIndex = 0;

            ClientDispatcher.SetLoger(this);

            ClientDispatcher.BindEventHandler(OnLoginUserLogin, EProtocolId.L2E_GAME_LOGINSERVER);
            ClientDispatcher.BindEventHandler(OnLoginUserRegister, EProtocolId.L2E_GAME_REGISTER);
            ClientDispatcher.BindEventHandler(OnPlayerXY, EProtocolId.G2E_GAME_PLAYERXY);
            ClientDispatcher.BindEventHandler(OnPlayerLoginOut, EProtocolId.G2E_GAME_LOGINOUT);
            ClientDispatcher.BindEventHandler(OnPlayerMapInOther, EProtocolId.G2E_GAME_MAPINOTHER);
            ClientDispatcher.BindEventHandler(OnPlayerMapIn, EProtocolId.G2E_GAME_MAPIN);
            tabControl1.SelectedIndex = 0;
        }


        #region 公共
        public void Info(object o)
        {
            //MessageBox.Show($"{o}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox3.Text += $"{o}\r\n";
        }
        public void Error(object o)
        {
            //MessageBox.Show($"{o}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox3.Text += $"{o}\r\n";
        }
        public void Dump(object o)
        {
            textBox3.Text += $"{o}\r\n";
        }
        public void Debug(object o)
        {
            textBox3.Text += $"{o}\r\n";
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //if (ClientNetSingle.LinkState && tabControl1.SelectedIndex == 3 && this.IsMoving)
            //{
            //    if (pCursorOffset.X == 0 && pCursorOffset.Y == 0)
            //    {
            //        return;
            //    }
            //    var Req = new E2G_Game_PlayerXY()
            //    {
            //        PlayerXY = new CLS_PlayerXY() { Top = BtnPlayer.Top, Left = BtnPlayer.Left }
            //    };
            //    ClientNetSingle.Send(Req);
            //}
        }

        #endregion

        #region 登录注册
        public ClientLink ClientNetSingle = new ClientLink();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ClientNetSingle.LinkState)
            {
                if (!CreateLink())
                {
                    return;
                }
            }

            var Req = new E2L_Game_LoginServer()
            {
                Account = textBox1.Text,
                Password = textBox2.Text,
            };
            ClientNetSingle.Send(Req);
        }
        public bool CreateLink()
        {
            int port = 12000;
            var txt = comboBox1.Text;
            switch (txt)
            {
                case "内网":
                    ClientNetSingle.Setup(ConstsBase.Ip内网, port);
                    break;
                case "外网":
                    ClientNetSingle.Setup(ConstsBase.Ip外网, port);
                    break;
                default:
                    ClientNetSingle.Setup(ConstsBase.Ip本机, port);
                    break;
            }
            if (ClientNetSingle.Start())
            {
                Debug("连接成功");
                return true;
            }
            else
            {
                Error("连接失败");
                return false;
            }
        }
        private long puid;
        private bool isLogined = false;
        private void OnLoginUserLogin(byte[] buffer)
        {
            var Req = new L2E_Game_LoginServer(buffer);
            if (Req.Success)
            {
                Info("用户登录成功");
                puid = Req.Puid;
                uidButton[puid] = BtnPlayer;
                isLogined = true;
            }
            else
            {               
                //Error(Req.Result);                
                return;
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ClientNetSingle.LinkState)
            {
                if (!CreateLink())
                {
                    return;
                }
            }
            var Req = new E2L_Game_Register()
            {
                Account = textBox1.Text,
                Password = textBox2.Text,
            };
            ClientNetSingle.Send(Req);
        }

        private void OnLoginUserRegister(byte[] buffer)
        {
            var Req = new L2E_Game_Register(buffer);
            if (Req.Success)
            {
                Info($"用户{Req.Puid}注册成功");
            }
            else
            {
                Error(Req.Result);
            }
        }

        #endregion
        private string msgString = "";
        private void button9_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            var type = Assembly.Load("ServerBase").GetType("ServerBase.Protocol." + textBox6.Text);
            if (type == null)
            {
                MessageBox.Show("协议类型错误");
                return;
            }
            INbsSerializer msg = (INbsSerializer)Activator.CreateInstance(type, true);

            var propertys = type.GetFields();
            int count = dataGridView7.Rows.Count;
            for (int i = 0; i < count; i++)
            {

                var name = dataGridView7.Rows[i].Cells[1].Value;
                var field = propertys.FirstOrDefault(p => p.Name.Equals(name));
                if (field != null)
                {
                    field.SetValue(msg, Convert.ChangeType(dataGridView7.Rows[i].Cells[2].Value, field.FieldType));
                }
            }
            ClientNetSingle.Send(msg);
            msgString = textBox6.Text.Replace("C2G", "G2C");
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            var type = Assembly.Load("ServerBase").GetType("ServerBase.Protocol." + textBox6.Text);
            if (type == null)
            {
                return;
            }
            var dgv = dataGridView7;
            dgv.Rows.Clear();
            try
            {
                INbsSerializer msg = (INbsSerializer)Activator.CreateInstance(type, true);

                var propertys = type.GetFields();
                foreach (var fieldInfo in propertys)
                {
                    if (fieldInfo.Name == "_protocol" || fieldInfo.Name == "_result"
                        || fieldInfo.Name == "Pin" || fieldInfo.Name == "Puid"
                        || fieldInfo.Name == "Shuttle")
                    {
                        continue;
                    }
                    var value = fieldInfo.GetValue(msg);
                    var row = new List<object>();
                    var objs = fieldInfo.GetCustomAttributes(typeof(DescAttribute), true);
                    row.Add(((DescAttribute)objs[0]).DescStr);
                    row.Add(fieldInfo.Name);
                    row.Add(value);
                    dgv.Rows.Add(row.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"协议错误！{ex}");
                return;
            }
        }

        bool IsMoving = false;
        Point pCtrlLastCoordinate = new Point(0, 0);
        Point pCursorOffset = new Point(0, 0);
        Point pCursorLastCoordinate = new Point(0, 0);
        public void MoveBtn()
        {
            
        }
        private void BtnPlayer_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.IsMoving)
            {
                if (pCursorOffset.X == 0 && pCursorOffset.Y == 0)
                {
                    return;
                }
                if ((pCtrlLastCoordinate.X + pCursorOffset.X + BtnPlayer.Width) > 0)
                {
                    BtnPlayer.Left = pCtrlLastCoordinate.X + pCursorOffset.X;
                }
                else
                {
                    BtnPlayer.Left = 0;
                }
                if ((pCtrlLastCoordinate.Y + pCursorOffset.Y + BtnPlayer.Height) > 0)
                {
                    BtnPlayer.Top = pCtrlLastCoordinate.Y + pCursorOffset.Y;
                }
                else
                {
                    BtnPlayer.Top = 0;
                }
                pCursorOffset.X = 0;
                pCursorOffset.Y = 0;
                IsMoving = false;
            }
        }

        private void BtnPlayer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.IsMoving)
                {
                    Point pCursor = new Point(Cursor.Position.X, Cursor.Position.Y);

                    pCursorOffset.X = pCursor.X - pCursorLastCoordinate.X;

                    pCursorOffset.Y = pCursor.Y - pCursorLastCoordinate.Y;
                    BtnPlayer.Left = pCtrlLastCoordinate.X + pCursorOffset.X;
                    BtnPlayer.Top = pCtrlLastCoordinate.Y + pCursorOffset.Y;

                    MoveBtn();
                }

            }
        }

        private void BtnPlayer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsMoving = true;
                pCtrlLastCoordinate.X = BtnPlayer.Left;
                pCtrlLastCoordinate.Y = BtnPlayer.Top;
                pCursorLastCoordinate.X = Cursor.Position.X;
                pCursorLastCoordinate.Y = Cursor.Position.Y;
            }
        }
        Dictionary<long,Button> uidButton = new Dictionary<long, Button>();
        private void OnPlayerXY(byte[] buffer)
        {
            var Req = new G2E_Game_PlayerXY(buffer);
            if (Req.Success)
            {   
                Button btn = uidButton[Req.PlayerXY.Uid];
                btn.Top = Req.PlayerXY.Top;
                btn.Left = Req.PlayerXY.Left;                
            }
            else
            {
                Error(Req.Result);
            }
        }
        private void OnPlayerMapIn(byte[] buffer)
        {
            var Req = new G2E_Game_MapIn(buffer);
            if (!uidButton.ContainsKey(Req.PlayerXY.Uid))
            {
                AddButton(Req.PlayerXY);                        
            }
        }
        private void OnPlayerMapInOther(byte[] buffer)
        {
            var Req = new G2E_Game_MapInOther(buffer);
            foreach (var item in Req.ListPlayerXY)
            {
                if (!uidButton.ContainsKey(item.Uid))
                {
                    AddButton(item);
                }
            }            
        }
        
        private void AddButton(CLS_PlayerXY playerXY)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { AddButton(playerXY); }));
                return;
            }

            Button btn = new Button();
            btn.Location = new System.Drawing.Point(playerXY.Left, playerXY.Top);
            btn.Name = "BtnPlayer" + playerXY.Uid;
            btn.Size = new System.Drawing.Size(50, 43);
            btn.Text = playerXY.Uid.ToString();
            panel2.Controls.Add(btn); ;
            uidButton[playerXY.Uid] = btn;            
        }

        private void BtnPlayer_KeyDown(object sender, KeyEventArgs e)
        {
            int dx = 5;//以10像素为单位偏移
            IsMoving = true;
            switch (e.KeyCode)
            {
                case Keys.W:
                    BtnPlayer.Top -= dx;
                    break;
                case Keys.S:
                    BtnPlayer.Top += dx;
                    break;
                case Keys.A:
                    BtnPlayer.Left -= dx;
                    break;
                case Keys.D:
                    BtnPlayer.Left += dx;
                    break;
                default:
                    IsMoving = false;
                    return;
            }
            pCursorOffset.X = 1;
            MoveBtn();
        }

        private void BtnPlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void BtnPlayer_KeyUp(object sender, KeyEventArgs e)
        {
            IsMoving = false;
        }
        private void OnPlayerLoginOut(byte[] buffer)
        {
            var Req = new G2E_Game_LoginOut(buffer);
            if (Req.Success)
            {
                if (uidButton.TryGetValue(Req.Puid, out var btn))
                {
                    btn.Dispose();
                    uidButton.Remove(Req.Puid);
                }
                
            }
            else
            {
                Error(Req.Result);
            }
        }
        #region 压力测试
        public void Test()
        {
            tabControl1.SelectedIndex = 3;
            Random rd = new Random();
           
            string TestID = "Test"+ rd.Next(1,100000);
            if (!ClientNetSingle.LinkState)
            {
                if (!CreateLink())
                {
                    return;
                }
            }
            var Req1 = new E2L_Game_Register()
            {
                Account = TestID,
                Password = textBox2.Text,
            };
            ClientNetSingle.Send(Req1);
            Thread.Sleep(1000);
            var Req2 = new E2L_Game_LoginServer()
            {
                Account = TestID,
                Password = textBox2.Text,
            };
            ClientNetSingle.Send(Req2);
            while (!isLogined)
            {

            }
            while (true)
            {
                System.Threading.Thread.CurrentThread.Join(100);
                int index= rd.Next(1,5);
                bool err = false;
                switch (index)
                {
                    case 1:
                        BtnPlayer.Top -= 5;
                        break;
                    case 2:
                        BtnPlayer.Top += 5;
                        break;
                    case 3:
                        BtnPlayer.Left -= 5;
                        break;
                    case 4:
                        BtnPlayer.Left += 5;
                        break;
                    default:
                        err = true;
                        break;
                }
                if (!err)
                {
                    var Req = new E2G_Game_PlayerXY()
                    {
                        PlayerXY = new CLS_PlayerXY() { Top = BtnPlayer.Top, Left = BtnPlayer.Left }
                    };
                    ClientNetSingle.Send(Req);
                }
                if (!isLogined)
                {
                    return;
                }                
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            var thread = new Thread(new ThreadStart(Test));
            thread.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isLogined = false;
        }
    }
}
