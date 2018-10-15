using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;        //NPOI
using NPOI.XSSF.UserModel;      //NPOI
using System.Threading;

namespace ExcelTool
{
    public partial class FormTool : Form
    {
        public readonly string Xml_head = "Data";
        public readonly string Xml_node = "Node";

        public string PathCurrent = "";
        public string PathEnum = "";
        public string PathResult = "";
        public string PathGlobalId = "";

        public string PathExcel = "";
        public string PathClass = "";
        public string PathXml = "";
        public string PathJson = "";
        public string PathLua = "";

        public class XFileInfo
        {
            public string Name;
            public TimeSpan Ts;
            public bool Need = true;
            public int rowindex = 0;
            public EValidType ValidType = EValidType.公共;
            public XFileInfo(string name)
            {
                Name = name;
                Ts = new TimeSpan();
                Need = true;
                rowindex = 0;
            }
        }
        public Dictionary<string, XFileInfo> DictFiles = new Dictionary<string, XFileInfo>();
        //枚举列表
        public Dictionary<string, Dictionary<string, string>> DictListEnums = new Dictionary<string, Dictionary<string, string>>();

        public StringBuilder SbClassServer = new StringBuilder();

        public enum EValidType
        {
            无效的 = 0,
            公共 = 1,
            仅服务器 = 2,
            仅客户端 = 3,
        }

        public class PageInfo
        {
            public string Name;
            public string NameCn;
            public string NameFile;
            public EValidType ValidType = EValidType.公共;
            public List<string> HeadC;
            public List<string> Head;
            public List<string> HeadEnum;
            public List<string> TypeClient;
            public List<string> TypeServer;
            public List<List<string>> ListValue;

            public PageInfo(string name)
            {
                Name = name;
                NameCn = name;
                ValidType = EValidType.公共;

                HeadC = new List<string>();
                Head = new List<string>();
                HeadEnum = new List<string>();
                TypeClient = new List<string>();
                TypeServer = new List<string>();
                ListValue = new List<List<string>>();
            }
            public bool IsLegal()
            {
                if (Head.Count <= 0)
                {
                    return false;
                }
                if (ListValue.Count <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Dictionary<string, PageInfo> DictPages = new Dictionary<string, PageInfo>();

        public FormTool()
        {
            InitializeComponent();
        }

        private void FormTool_Load(object sender, EventArgs e)
        {
            PathCurrent = Directory.GetCurrentDirectory();
            PathCurrent = XGlobal.GetParentFolder(PathCurrent);

            textBox2.Text = PathExcel = PathCurrent + @"\Config\Excel";
            textBox3.Text = PathClass = PathCurrent + @"\Config\Class";
            textBox4.Text = PathXml = PathCurrent + @"\Config\Xml";
            textBox5.Text = PathJson = PathCurrent + @"\Config\Json";
            textBox1.Text = PathLua = PathCurrent + @"\Config\Lua";

            //PathEnum = PathExcel + @"\e公共枚举.xlsx";
            PathEnum = PathExcel + @"\A_公共枚举.xlsx";
            PathResult = PathExcel + @"\F_返回码.xlsx";
            PathGlobalId = PathExcel + @"\Q_全局常数.xlsx";
        }
        private void SetEnabled(bool value = true)
        {
            panel1.Enabled = value;
            dataGridView1.Enabled = value;
        }
        private void GetFileList(string path, EValidType ValidType)
        {
            if (Directory.Exists(path))
            {
                foreach (string filename in Directory.GetFileSystemEntries(path))
                {
                    if (File.Exists(filename))
                    {
                        string filename_excel = Path.GetFileNameWithoutExtension(filename);
                        string firs = filename_excel.Substring(0, 1);
                        if (firs != "A")
                        {
                            XFileInfo finfo = new XFileInfo(filename);
                            finfo.ValidType = ValidType;
                            DictFiles.Add(finfo.Name, finfo);
                        }
                    }
                }
            }
        }
        private void UpdateFileList()
        {
            var dgv = dataGridView1;

            dgv.Rows.Clear();

            foreach (var item in DictFiles.Values)
            {
                int rowindex = dgv.Rows.Add();
                item.rowindex = rowindex;
                dgv.Rows[rowindex].Cells[0].Value = item.Name;
                dgv.Rows[rowindex].Cells[1].Value = $"{item.Ts.TotalMilliseconds} ms";
                if (item.Need)
                {
                    dgv.Rows[rowindex].Cells[1].Style.BackColor = Color.Green;
                }
                else
                {
                    dgv.Rows[rowindex].Cells[1].Style.BackColor = Color.Gray;
                }
            }

            UpdateprogressBar1();
        }
        private void UpdateprogressBar1()
        {
            progressBar1.Maximum = DictFiles.Count + 15;
            progressBar1.Value = 0;
        }
        public void UpdateFileTs(XFileInfo fileinfo, TimeSpan ts)
        {
            try
            {
                var dgv = dataGridView1;
                dgv.Rows[fileinfo.rowindex].Cells[1].Value = $"{ts.TotalMilliseconds} ms";
            }
            catch { }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = dataGridView1;
            if (dgv.Columns[e.ColumnIndex].Name.Equals("Column3"))
            {
                try
                {
                    var row = dgv.Rows[e.RowIndex];
                    string name = (string)(row.Cells[0].Value);
                    if (DictFiles.ContainsKey(name))
                    {
                        var old = DictFiles[name].Need;
                        var need = DictFiles[name].Need = !old;
                        var cell = dgv[e.ColumnIndex - 1, e.RowIndex];
                        if (need)
                        {
                            cell.Style.BackColor = Color.Green;
                        }
                        else
                        {
                            cell.Style.BackColor = Color.Gray;
                        }
                    }
                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DictFiles.Clear();

            GetFileList(PathExcel, EValidType.公共);
            GetFileList(PathExcel + @"\服务器", EValidType.仅服务器);
            GetFileList(PathExcel + @"\客户端", EValidType.仅客户端);

            UpdateFileList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DateTime.Now >= new DateTime(2020, 7, 1))
            {
                return;
            }

            UpdateprogressBar1();
            var ageCoun = (from s in DictFiles.Values
                           select s.Need)
                           .Count(a => a == true);
            if (ageCoun <= 0)
            {
                MessageBox.Show($"需要导出的列表为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(PathExcel))
            {
                MessageBox.Show($"导入文档路径< {PathExcel} >并不存在！请重新设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(PathClass))
            {
                MessageBox.Show($"导入文档路径< {PathClass} >并不存在！请重新设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(PathXml))
            {
                MessageBox.Show($"导入文档路径< {PathXml} >并不存在！请重新设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(PathJson))
            {
                MessageBox.Show($"导入文档路径< {PathJson} >并不存在！请重新设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(PathLua))
            {
                MessageBox.Show($"导入文档路径< {PathLua} >并不存在！请重新设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetEnabled(false);

            XGlobal.EmptyFolder(PathClass);
            XGlobal.EmptyFolder(PathXml);
            XGlobal.EmptyFolder(PathJson);
            XGlobal.EmptyFolder(PathLua);

            try
            {
                TransferFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"导出失败，请重试！错误 ({ex.Message})", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Thread.Sleep(1000);
            MessageBox.Show($"导出完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetEnabled(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.SelectedPath = PathExcel;
            fbd.ShowDialog();
            if (fbd.SelectedPath != string.Empty)
            {
                textBox2.Text = PathExcel = fbd.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.SelectedPath = PathClass;
            fbd.ShowDialog();
            if (fbd.SelectedPath != string.Empty)
            {
                textBox3.Text = PathClass = fbd.SelectedPath;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.SelectedPath = PathXml;
            fbd.ShowDialog();
            if (fbd.SelectedPath != string.Empty)
            {
                textBox4.Text = PathXml = fbd.SelectedPath;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.SelectedPath = PathJson;
            fbd.ShowDialog();
            if (fbd.SelectedPath != string.Empty)
            {
                textBox5.Text = PathJson = fbd.SelectedPath;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.SelectedPath = PathLua;
            fbd.ShowDialog();
            if (fbd.SelectedPath != string.Empty)
            {
                textBox1.Text = PathLua = fbd.SelectedPath;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (var item in DictFiles.Values)
            {
                item.Need = true;
            }
            UpdateFileList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (var item in DictFiles.Values)
            {
                item.Need = false;
            }
            UpdateFileList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DictFiles.Clear();
            UpdateFileList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = true;
            ofd.InitialDirectory = PathExcel;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in ofd.FileNames)
                {
                    if (File.Exists(filename))
                    {
                        string filename_excel = Path.GetFileNameWithoutExtension(filename);
                        string firs = filename_excel.Substring(0, 1);
                        if (firs != "A")
                        {
                            XFileInfo finfo = new XFileInfo(filename);
                            DictFiles[finfo.Name] = finfo;
                        }
                    }
                }
                UpdateFileList();
            }
        }

        #region 导出
        public static string GetTextFromCell(ICell cell)
        {
            string result = "";
            if (cell == null)
            {
                return result;
            }
            if (cell.CellType == CellType.Formula)
            {
                switch (cell.CachedFormulaResultType)
                {
                    case CellType.String:
                        string strFORMULA = cell.StringCellValue;
                        if (strFORMULA != null && strFORMULA.Length > 0)
                        {
                            result = strFORMULA.ToString();
                        }
                        break;

                    case CellType.Numeric:
                        result = Convert.ToString(cell.NumericCellValue);
                        break;

                    case CellType.Boolean:
                        result = Convert.ToString(cell.BooleanCellValue);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                result = cell.ToString();
            }
            return result;
        }

        public void TransferFiles()
        {
            //枚举表
            ReadEnums();
            progressBar1.Increment(1);

            ////返回码
            //ReadResults();
            //progressBar1.Increment(1);

            //全局常数
            ReadGlobalIds();
            progressBar1.Increment(1);

            DictPages.Clear();
            foreach (var nn in DictFiles.Values)
            {
                if (nn.Need)
                {
                    ReadFile(nn);
                }
                progressBar1.Increment(1);
            }

            TransferClassServer();
            progressBar1.Increment(1);
            TransferClassServerConf();
            progressBar1.Increment(1);
            TransferClassServerConfRead();
            progressBar1.Increment(1);

            TransferClassClient();
            progressBar1.Increment(1);
            TransferClassClientLua();
            progressBar1.Increment(1);

            Transfers();
            progressBar1.Value = progressBar1.Maximum;
        }

        public void ReadEnums()
        {
            DictListEnums.Clear();

            if (File.Exists(PathEnum))
            {
                FileStream fsExcel = File.OpenRead(PathEnum);
                IWorkbook wk = new XSSFWorkbook(fsExcel); ;

                int rows;

                //读取枚举表
                ISheet sheetenum = wk.GetSheetAt(0);

                rows = sheetenum.LastRowNum;
                int enumcols = 120;
                for (int j = 0; (j + 2) <= enumcols; j += 3)
                {
                    IRow rowdictk = sheetenum.GetRow(1);
                    if (rowdictk == null)
                    {
                        break;
                    }
                    ICell celldictk = rowdictk.GetCell(j);
                    if (celldictk == null)
                    {
                        break;
                    }
                    string DictKey = celldictk.ToString();
                    if (DictKey == "")
                    {
                        break;
                    }
                    Dictionary<string, string> DictList = new Dictionary<string, string>();
                    for (int i = 3; i <= rows; i++)
                    {
                        IRow rowdictv = sheetenum.GetRow(i);
                        if (rowdictv == null)
                        {
                            continue;
                        }
                        ICell cell1 = rowdictv.GetCell(j);
                        ICell cell2 = rowdictv.GetCell(j + 1);
                        if (cell1 == null || cell2 == null)
                        {
                            continue;
                        }
                        string enumK = cell2.ToString();
                        string enumV = cell1.ToString();
                        if (enumK == "" || enumV == "")
                        {
                            continue;
                        }
                        if (!DictList.ContainsKey(enumK))
                        {
                            DictList.Add(enumK, enumV);
                        }
                    }
                    DictListEnums.Add(DictKey, DictList);
                }
            }
        }
        public void ReadResults()
        {
            if (File.Exists(PathResult))
            {
                FileStream fsExcel = File.OpenRead(PathResult);
                IWorkbook wk = new XSSFWorkbook(fsExcel); ;

                int rows;

                //读取枚举表
                ISheet sheetenum = wk.GetSheetAt(0);

                rows = sheetenum.LastRowNum;
                if (true)
                {
                    int j = 0;
                    string DictKey = "ProtocolResult";
                    Dictionary<string, string> DictList = new Dictionary<string, string>();
                    for (int i = 5; i <= rows; i++)
                    {
                        IRow rowdictv = sheetenum.GetRow(i);
                        if (rowdictv == null)
                        {
                            continue;
                        }
                        ICell cell1 = rowdictv.GetCell(j);
                        ICell cell2 = rowdictv.GetCell(j + 1);
                        if (cell1 == null || cell2 == null)
                        {
                            continue;
                        }
                        string enumK = cell2.ToString();
                        string enumV = cell1.ToString();
                        if (enumK == "" || enumV == "")
                        {
                            continue;
                        }
                        if (!DictList.ContainsKey(enumK))
                        {
                            DictList.Add(enumK, enumV);
                        }
                    }
                    DictListEnums.Add(DictKey, DictList);
                }
            }
        }
        public void ReadGlobalIds()
        {
            if (File.Exists(PathGlobalId))
            {
                FileStream fsExcel = File.OpenRead(PathGlobalId);
                IWorkbook wk = new XSSFWorkbook(fsExcel); ;

                int rows;

                //读取枚举表
                ISheet sheetenum = wk.GetSheetAt(0);

                rows = sheetenum.LastRowNum;
                if (true)
                {
                    int j = 0;
                    string DictKey = "GlobalId";
                    Dictionary<string, string> DictList = new Dictionary<string, string>();
                    for (int i = 5; i <= rows; i++)
                    {
                        IRow rowdictv = sheetenum.GetRow(i);
                        if (rowdictv == null)
                        {
                            continue;
                        }
                        ICell cell1 = rowdictv.GetCell(j);
                        ICell cell2 = rowdictv.GetCell(j + 1);
                        if (cell1 == null || cell2 == null)
                        {
                            continue;
                        }
                        string enumK = cell2.ToString();
                        string enumV = cell1.ToString();
                        if (enumK == "" || enumV == "")
                        {
                            continue;
                        }
                        if (!DictList.ContainsKey(enumK))
                        {
                            DictList.Add(enumK, enumV);
                        }
                    }
                    DictListEnums.Add(DictKey, DictList);
                }
            }
        }
        public void ReadFile(XFileInfo fileinfo)
        {
            string path_excel = fileinfo.Name;

            var time_start = DateTime.Now;
            if (File.Exists(path_excel))
            {
                FileStream fsExcel = File.OpenRead(path_excel);
                IWorkbook wk = new XSSFWorkbook(fsExcel);

                int stcount = wk.NumberOfSheets;
                for (int stc = 0; stc < stcount; stc++)
                {
                    ISheet sheet = wk.GetSheetAt(stc);

                    string sheetName = sheet.SheetName;
                    string[] nodes = sheetName.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                    string pagename = sheet.SheetName;
                    string pagenamecn = sheet.SheetName;
                    if (nodes.Length >= 2)
                    {
                        pagename = nodes[1];
                        pagenamecn = nodes[0];
                    }

                    var page = new PageInfo(pagename);
                    page.NameCn = pagenamecn;
                    page.NameFile = Path.GetFileName(path_excel);
                    page.ValidType = fileinfo.ValidType;

                    IRow rowHeadC = sheet.GetRow(1);
                    if (rowHeadC == null)
                    {
                        continue;
                    }
                    for (int k = 0; k <= rowHeadC.LastCellNum; k++)
                    {
                        ICell cell = rowHeadC.GetCell(k);
                        if (cell != null)
                        {
                            page.HeadC.Add(cell.ToString());
                        }
                        else
                        {
                            page.HeadC.Add("");
                        }
                    }
                    IRow rowHead = sheet.GetRow(2);
                    if (rowHead == null)
                    {
                        continue;
                    }
                    for (int k = 0; k <= rowHead.LastCellNum; k++)
                    {
                        ICell cell = rowHead.GetCell(k);
                        if (cell != null)
                        {
                            string strheadenum = cell.ToString();
                            string[] strheadenumnodes = strheadenum.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                            if (strheadenumnodes.Length >= 2)
                            {
                                page.Head.Add(strheadenumnodes[0]);
                                page.HeadEnum.Add(strheadenumnodes[1]);
                            }
                            else
                            {
                                page.Head.Add(strheadenum);
                                page.HeadEnum.Add(strheadenum);
                            }
                        }
                        else
                        {
                            page.Head.Add("");
                            page.HeadEnum.Add("");
                        }
                    }
                    IRow rowTypeClient = sheet.GetRow(3);
                    if (rowTypeClient == null)
                    {
                        continue;
                    }
                    for (int k = 0; k <= page.Head.Count; k++)
                    {
                        ICell cell = rowTypeClient.GetCell(k);
                        if (cell != null)
                        {
                            string TypeClient = cell.ToString();
                            if (TypeClient == "float")
                            {
                                TypeClient = "double";
                            }
                            page.TypeClient.Add(TypeClient);
                        }
                        else
                        {
                            page.TypeClient.Add("");
                        }
                    }
                    IRow rowTypeServer = sheet.GetRow(4);
                    if (rowTypeServer == null)
                    {
                        continue;
                    }
                    for (int k = 0; k <= page.Head.Count; k++)
                    {
                        ICell cell = rowTypeServer.GetCell(k);
                        if (cell != null)
                        {
                            page.TypeServer.Add(cell.ToString());
                        }
                        else
                        {
                            page.TypeServer.Add("");
                        }
                    }

                    for (int j = 5; j <= sheet.LastRowNum; j++)
                    {
                        IRow row = sheet.GetRow(j);
                        if (row == null)
                        {
                            continue;
                        }
                        if (row.GetCell(0) == null)
                        {
                            continue;
                        }
                        if (row.GetCell(0).ToString() == "")
                        {
                            continue;
                        }
                        var listrowvalue = new List<string>();
                        for (int k = 0; k < page.Head.Count; k++)
                        {
                            ICell cell = row.GetCell(k);
                            string s_value = GetTextFromCell(cell);
                            if (s_value == "")
                            {
                                s_value = "0";
                            }

                            if (!string.IsNullOrEmpty(page.HeadEnum[k]))
                            {
                                if (DictListEnums.TryGetValue(page.HeadEnum[k], out var DictList))
                                {
                                    if (DictList.ContainsKey(s_value))
                                    {
                                        s_value = DictList[s_value];
                                    }
                                }
                            }
                            listrowvalue.Add(s_value);
                        }
                        page.ListValue.Add(listrowvalue);
                    }
                    if (page.IsLegal())
                    {
                        DictPages.Add(page.Name, page);
                    }
                }
            }
            UpdateFileTs(fileinfo, DateTime.Now - time_start);
        }
        public void TransferClassServer()
        {
            var sb = new StringBuilder();

            sb.Append($"using System.Collections.Generic;\r\n\r\n");
            sb.Append($"namespace ServerBase.Config\r\n{{\r\n");

            foreach (var nn in DictPages.Values)
            {
                if (!(nn.ValidType == EValidType.公共 || nn.ValidType == EValidType.仅服务器))
                {
                    continue;
                }
                sb.Append($"\tpublic class {nn.Name} : IConfigBase\t// {nn.NameFile}\r\n\t{{\r\n");
                for (int iii = 0; iii < nn.Head.Count; iii++)
                {
                    if (nn.Head[iii] == "")
                    {
                        continue;
                    }
                    if (nn.TypeServer[iii] == "")
                    {
                        continue;
                    }
                    string tp = nn.TypeServer[iii];
                    switch (tp)
                    {
                        case "List<string>":
                        case "List<int>":
                        case "List<long>":
                        case "List<float>":
                        case "Dictionary<string,string>":
                        case "Dictionary<int,int>":
                        case "Dictionary<long,long>":
                        case "Dictionary<string, string>":
                        case "Dictionary<int, int>":
                        case "Dictionary<long, long>":
                            sb.Append($"\t\tpublic {tp} {nn.Head[iii]} = new {tp}(); //{nn.HeadC[iii]}\r\n");
                            break;
                        default:
                            sb.Append($"\t\tpublic {nn.TypeServer[iii]} {nn.Head[iii]}; //{nn.HeadC[iii]}\r\n");
                            break;
                    }
                }
                string getkey = "Id";
                try { getkey = nn.Head[0]; } catch { }
                sb.Append($"\t\tpublic object GetKey() {{ return {getkey}; }}\r\n");
                sb.Append($"\t}}\r\n");
            }

            foreach (var kvp in DictListEnums)
            {
                sb.Append($"\tpublic enum E{kvp.Key}\r\n");
                sb.Append($"\t{{\r\n");
                long min = 0, max = 0;
                foreach (var kvp2 in kvp.Value)
                {
                    sb.Append($"\t\t{kvp2.Key} = {kvp2.Value},\r\n");
                    long.TryParse(kvp2.Value, out long tempmax);
                    min = Math.Min(min, tempmax);
                    max = Math.Max(max, tempmax);
                }
                sb.Append($"\t}}\r\n");
            }
            sb.Append($"}}\r\n");

            string path_class = PathClass + "\\" + "ClassServer.cs";
            XGlobal.DeleteFile(path_class);
            FileStream fs_class = new FileStream(path_class, FileMode.OpenOrCreate);
            StreamWriter sw_class = new StreamWriter(fs_class, Encoding.Unicode);
            sw_class.Write(sb);
            sw_class.Close();
        }
        public void TransferClassServerConf()
        {
            var sb = new StringBuilder();

            sb.Append($"using System.Collections.Generic;\r\n");
            sb.Append($"using UtilLib;\r\n\r\n");
            sb.Append($"namespace ServerBase.Config\r\n{{\r\n");
            sb.Append($"\tpublic static partial class Conf\r\n\t{{\r\n");

            foreach (var nn in DictPages.Values)
            {
                if (!(nn.ValidType == EValidType.公共 || nn.ValidType == EValidType.仅服务器))
                {
                    continue;
                }
                sb.Append($"\t\t//{nn.NameCn}\t// {nn.NameFile}\r\n");
                var confname = nn.Name.Replace("Config", "Conf");
                var keytype = nn.TypeServer[0];
                sb.Append($"\t\tpublic static Dictionary<{keytype}, {nn.Name}> {confname} = new Dictionary<{keytype}, {nn.Name}>();\r\n");
            }

            sb.Append($"\t}}\r\n");
            sb.Append($"}}\r\n");

            string path_class = PathClass + "\\" + "ClassServerConf.cs";
            XGlobal.DeleteFile(path_class);
            FileStream fs_class = new FileStream(path_class, FileMode.OpenOrCreate);
            StreamWriter sw_class = new StreamWriter(fs_class, Encoding.Unicode);
            sw_class.Write(sb);
            sw_class.Close();
        }
        public void TransferClassServerConfRead()
        {
            var sb = new StringBuilder();

            sb.Append($"using System.Collections.Generic;\r\n");
            sb.Append($"using UtilLib;\r\n\r\n");
            sb.Append($"namespace ServerBase.Config\r\n{{\r\n");
            sb.Append($"\tpublic static partial class Conf\r\n\t{{\r\n");
            sb.Append($"\t\tpublic static bool InitConfSettings()\r\n\t\t{{\r\n");

            sb.Append($"\t\t\tbool result = true;\r\n\r\n");
            foreach (var nn in DictPages.Values)
            {
                if (!(nn.ValidType == EValidType.公共 || nn.ValidType == EValidType.仅服务器))
                {
                    continue;
                }
                sb.Append($"\t\t\t//{nn.NameCn}\r\n");
                var confname = nn.Name.Replace("Config", "Conf");
                sb.Append($"\t\t\tif (result) {{ result = ReadConfig(typeof({nn.Name}).Name, ref {confname}); }}\r\n");
            }
            sb.Append($"\r\n\t\t\tif (result) {{ result = InitConfSettingsExt(); }}\r\n\r\n");
            sb.Append($"\t\t\treturn result;\r\n");

            sb.Append($"\t\t}}\r\n");
            sb.Append($"\t}}\r\n");
            sb.Append($"}}\r\n");

            string path_class = PathClass + "\\" + "ClassServerConfRead.cs";
            XGlobal.DeleteFile(path_class);
            FileStream fs_class = new FileStream(path_class, FileMode.OpenOrCreate);
            StreamWriter sw_class = new StreamWriter(fs_class, Encoding.Unicode);
            sw_class.Write(sb);
            sw_class.Close();
        }
        public void TransferClassClient()
        {
            var sb = new StringBuilder();

            sb.Append($"using System.Collections.Generic;\r\n\r\n");

            foreach (var nn in DictPages.Values)
            {
                if (!(nn.ValidType == EValidType.公共 || nn.ValidType == EValidType.仅客户端))
                {
                    continue;
                }
                sb.Append($"public class {nn.Name}\r\n{{\r\n");
                for (int iii = 0; iii < nn.Head.Count; iii++)
                {
                    if (nn.Head[iii] == "")
                    {
                        continue;
                    }
                    if (nn.TypeClient[iii] == "")
                    {
                        continue;
                    }
                    sb.Append($"\tpublic readonly {nn.TypeClient[iii]} {nn.Head[iii]};\r\n");
                }
                sb.Append($"}}\r\n");
            }

            foreach (var kvp in DictListEnums)
            {
                sb.Append($"public enum E{kvp.Key}\r\n");
                sb.Append($"{{\r\n");
                long min = 0, max = 0;
                foreach (var kvp2 in kvp.Value)
                {
                    sb.Append($"\t{kvp2.Key} = {kvp2.Value},\r\n");
                    long.TryParse(kvp2.Value, out long tempmax);
                    min = Math.Min(min, tempmax);
                    max = Math.Max(max, tempmax);
                }
                sb.Append($"}}\r\n");
            }

            string path_class = PathClass + "\\" + "ClassClient.cs";
            XGlobal.DeleteFile(path_class);
            FileStream fs_class = new FileStream(path_class, FileMode.OpenOrCreate);
            StreamWriter sw_class = new StreamWriter(fs_class);
            sw_class.Write(sb);
            sw_class.Close();
        }
        public void TransferClassClientLua()
        {
            var sb = new StringBuilder();

            sb.Append($"using System.Collections.Generic;\r\n\r\n");
            sb.Append($"using XLua;\r\n\r\n");

            foreach (var nn in DictPages.Values)
            {
                if (!(nn.ValidType == EValidType.公共 || nn.ValidType == EValidType.仅客户端))
                {
                    continue;
                }
                sb.Append($"[CSharpCallLua]\r\n");
                sb.Append($"public interface {nn.Name}\r\n{{\r\n");
                for (int iii = 0; iii < nn.Head.Count; iii++)
                {
                    if (nn.Head[iii] == "")
                    {
                        continue;
                    }
                    if (nn.TypeClient[iii] == "")
                    {
                        continue;
                    }
                    sb.Append($"\t{nn.TypeClient[iii]} {nn.Head[iii]} {{ get; }}\r\n");
                }
                sb.Append($"}}\r\n");
            }

            foreach (var kvp in DictListEnums)
            {
                sb.Append($"public enum E{kvp.Key}\r\n");
                sb.Append($"{{\r\n");
                long min = 0, max = 0;
                foreach (var kvp2 in kvp.Value)
                {
                    sb.Append($"\t{kvp2.Key} = {kvp2.Value},\r\n");
                    long.TryParse(kvp2.Value, out long tempmax);
                    min = Math.Min(min, tempmax);
                    max = Math.Max(max, tempmax);
                }
                sb.Append($"}}\r\n");
            }

            string path_class = PathClass + "\\" + "ClassClientLua.cs";
            XGlobal.DeleteFile(path_class);
            FileStream fs_class = new FileStream(path_class, FileMode.OpenOrCreate);
            StreamWriter sw_class = new StreamWriter(fs_class);
            sw_class.Write(sb);
            sw_class.Close();
        }

        public void Transfers()
        {
            foreach (var nn in DictPages.Values)
            {
                var sbXml = new StringBuilder();
                var sbJson = new StringBuilder();
                var sbLua = new StringBuilder();

                sbXml.Append($"<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
                sbXml.Append($"<{Xml_head}>\r\n");

                sbJson.Append("{\r\n");

                sbLua.Append($"{nn.Name}=\r\n{{\r\n");

                var listdataJson = new List<string>();
                var listdataLua = new List<string>();

                foreach (var nnn in nn.ListValue)
                {
                    sbXml.Append($"\t<{Xml_node}>\r\n");

                    var listnodeJson = new List<string>();
                    var listnodeLua = new List<string>();
                    for (int iii = 0; iii < nn.Head.Count; iii++)
                    {
                        if (nn.Head[iii] == "")
                        {
                            continue;
                        }

                        if (nn.TypeServer[iii] != "")
                        {
                            sbXml.Append($"\t\t<{nn.Head[iii]}>{nnn[iii]}</{nn.Head[iii]}>\r\n");
                        }

                        string nodeJson = "";
                        if (nn.TypeClient[iii] == "int" || nn.TypeClient[iii] == "long" || nn.TypeClient[iii] == "float" || nn.TypeClient[iii] == "double")
                        {
                            nodeJson = $"\t\t\"{nn.Head[iii]}\":{nnn[iii]}";
                        }
                        else
                        {
                            nodeJson = $"\t\t\"{nn.Head[iii]}\":\"{nnn[iii]}\"";
                        }
                        listnodeJson.Add(nodeJson);

                        string nodeLua = "";
                        if (nn.TypeClient[iii] == "int" || nn.TypeClient[iii] == "long" || nn.TypeClient[iii] == "float" || nn.TypeClient[iii] == "double")
                        {
                            nodeLua = $"{nn.Head[iii]}={nnn[iii]}";
                        }
                        else
                        {
                            nodeLua = $"{nn.Head[iii]}=\"{nnn[iii]}\"";
                        }
                        listnodeLua.Add(nodeLua);
                    }
                    string dataJson = $"\t\"{nnn[0]}\":{{\r\n{string.Join(",\r\n", listnodeJson)}\r\n\t}}";
                    listdataJson.Add(dataJson);

                    string dataLua = $"[\"{nnn[0]}\"]={{{string.Join(",", listnodeLua)},}}";
                    listdataLua.Add(dataLua);

                    sbXml.Append($"\t</{Xml_node}>\r\n");
                }

                sbXml.Append($"</{Xml_head}>\r\n");

                sbJson.Append(string.Join(",\r\n", listdataJson));
                sbJson.Append("\r\n}\r\n");

                sbLua.Append(string.Join(",\r\n", listdataLua));
                sbLua.Append("\r\n}\r\n");

                if (nn.ValidType == EValidType.公共 || nn.ValidType == EValidType.仅服务器)
                {
                    if (true)
                    {
                        string pathXml = $"{PathXml}\\{nn.Name}.xml";
                        XGlobal.DeleteFile(pathXml);
                        FileStream fsXml = new FileStream(pathXml, FileMode.OpenOrCreate);
                        StreamWriter swXml = new StreamWriter(fsXml);
                        swXml.Write(sbXml.ToString());
                        swXml.Close();
                    }
                }
                if (nn.ValidType == EValidType.公共 || nn.ValidType == EValidType.仅客户端)
                {
                    if (true)
                    {
                        string pathJson = $"{PathJson}\\{nn.Name}.json";
                        XGlobal.DeleteFile(pathJson);
                        FileStream fsJson = new FileStream(pathJson, FileMode.OpenOrCreate);
                        StreamWriter swJson = new StreamWriter(fsJson);
                        swJson.Write(sbJson.ToString());
                        swJson.Close();
                    }
                    if (true)
                    {
                        string pathLua = $"{PathLua}\\{nn.Name}.lua";
                        XGlobal.DeleteFile(pathLua);
                        FileStream fsLua = new FileStream(pathLua, FileMode.OpenOrCreate);
                        StreamWriter swLua = new StreamWriter(fsLua);
                        swLua.Write(sbLua.ToString());
                        swLua.Close();
                    }
                }
            }
        }
        #endregion

    }
}
