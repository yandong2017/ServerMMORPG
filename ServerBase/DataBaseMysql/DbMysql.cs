using MySql.Data.MySqlClient;
using ServerBase.Config;
using static ServerBase.Config.Conf;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ServerBase.Service;
using ServerBase.IniFile;

namespace ServerBase.DataBaseMysql
{
    /// <summary>
    /// 数据库Mysql处理
    /// </summary>
    public class DbMysql
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        private MySqlConnection DataBaseUser = null;

        /// <summary>
        /// 数据库指令
        /// </summary>
        private MySqlCommand DataBaseCmd;

        /// <summary>
        /// 连接状态
        /// </summary>
        private int DataBaseState = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DbMysql()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public DbMysql(string DataSource, string Port, string UserId, string Password, string Database)
        {
            try
            {
                string ConnectionString = $"Data Source={DataSource};Port={Port};User Id={UserId};Password={Password};Database={Database}";
                DataBaseUser = new MySqlConnection(ConnectionString);
                DataBaseCmd = DataBaseUser.CreateCommand();
                DataBaseCmd.CommandType = CommandType.Text;
            }
            catch (Exception ex)
            {
                ServerLoger.loger.Fatal("Mysql数据库初始化失败", ex);
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public DbMysql(string connectionstring)
        {
            try
            {
                DataBaseUser = new MySqlConnection(connectionstring);
                DataBaseCmd = DataBaseUser.CreateCommand();
                DataBaseCmd.CommandType = CommandType.Text;
            }
            catch (Exception ex)
            {
                ServerLoger.loger.Fatal("Mysql数据库初始化失败", ex);
            }
        }

        /// <summary>
        /// 连接到数据库
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        public void DbMysqlConnect()
        {
            //ServerLoger.Loger.Info($"数据库连接 {DataBaseUser.ConnectionString}");
            try
            {
                DataBaseCmd.Connection.Open();
                DataBaseState = 1;
                ServerLoger.loger.Info("Mysql数据库连接成功");
            }
            catch
            {
                DataBaseState = 0;
                ServerLoger.loger.Fatal("Mysql数据库连接失败");
            }
        }

        public bool IsConnect()
        {
            if (DataBaseState == 1)
            {
                return DataBaseUser.Ping();
            }
            return false;
        }

        /// <summary>
        /// 心跳循环内容
        /// </summary>
        public void HeartbeatExecute()
        {
            bool isConnect = false;
            try
            {
                isConnect = DataBaseUser.Ping();
            }
            catch
            {
            }
            if (isConnect)
            {
                ServerLoger.loger.Debug("Mysql数据库连接正常");
            }
            else
            {
                ServerLoger.loger.Warn("Mysql数据库未连接  尝试重新连接......");
                DbMysqlConnect();
            }
        }

        /// <summary>
        /// 执行数据库语句
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="immediately">是否及时处理</param>
        /// <returns></returns>
        public bool RunCommand(string cmd, bool immediately = false)
        {
            if (!immediately)
            {
                ThreadDbMysqlSecond.AddCmd(cmd);
                return true;
            }
            if (!IniConf.ConfSwitch.MysqlState)
            {
                return false;
            }
            if (DataBaseState != 1)
            {
                return false;
            }
            try
            {
                DataBaseCmd.CommandText = cmd;
                DataBaseCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ServerLoger.loger.Error($"执行数据库错误 {cmd}", ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 执行数据库查询
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public MySqlDataReader RunReader(string cmd)
        {
            if (!IniConf.ConfSwitch.MysqlState)
            {
                return null;
            }
            if (DataBaseState != 1)
            {
                return null;
            }
            //ServerLoger.Loger.Debug($"{cmd}");
            DataBaseCmd.CommandText = cmd;
            return DataBaseCmd.ExecuteReader();
        }

        /// <summary>
        /// 执行数据库插入
        /// </summary>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        public bool RunInsert(string tablename, Dictionary<string, object> datas, bool immediately = false)
        {
            if (datas.Count > 0)
            {
                var sbk = new StringBuilder();
                var sbv = new StringBuilder();
                int index = 0;
                foreach (var kvp in datas)
                {
                    index++;
                    sbk.Append(kvp.Key);
                    sbv.Append($"'{kvp.Value}'");
                    if (index != datas.Count)
                    {
                        sbk.Append(", ");
                        sbv.Append(", ");
                    }
                }
                string cmd = $"insert into {tablename} ({sbk}) values ({sbv})";
                return RunCommand(cmd, immediately);
            }
            return true;
        }

        /// <summary>
        /// 执行数据库更新
        /// </summary>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        public bool RunUpdate(string tablename, Dictionary<string, object> datas, Dictionary<string, object> dataswhere, bool immediately = false)
        {
            if (datas.Count > 0)
            {
                var sbu = new StringBuilder();
                int index = 0;
                foreach (var kvp in datas)
                {
                    index++;
                    sbu.Append($"{kvp.Key}='{kvp.Value}'");
                    if (index != datas.Count)
                    {
                        sbu.Append(", ");
                    }
                }
                string cmd = $"update {tablename} set {sbu}";
                if (dataswhere.Count > 0)
                {
                    var sbw = new StringBuilder();
                    int indexw = 0;
                    foreach (var kvpw in dataswhere)
                    {
                        indexw++;
                        sbw.Append($"{kvpw.Key}='{kvpw.Value}'");
                        if (indexw != dataswhere.Count)
                        {
                            sbw.Append(" and ");
                        }
                    }
                    cmd += $" where ({sbw})";
                }
                return RunCommand(cmd, immediately);
            }
            return true;
        }

        /// <summary>
        /// 执行数据库增加/减少
        /// </summary>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        public bool RunModify(string tablename, string mode, object value, Dictionary<string, object> dataswhere, string op = "+", bool immediately = true)
        {
            string cmd = $"update {tablename} set {mode} = {mode} {op} {value}";
            if (dataswhere.Count > 0)
            {
                var sbw = new StringBuilder();
                int indexw = 0;
                foreach (var kvpw in dataswhere)
                {
                    indexw++;
                    sbw.Append($"{kvpw.Key}='{kvpw.Value}'");
                    if (indexw != dataswhere.Count)
                    {
                        sbw.Append(" and ");
                    }
                }
                cmd += $" where ({sbw})";
            }
            return RunCommand(cmd, immediately);
        }

        /// <summary>
        /// 执行数据库查询存在
        /// </summary>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        public bool RunCheckExist(string tablename, Dictionary<string, object> dataswhere)
        {
            bool isexist = false;
            string cmd = $"select * from {tablename}";
            if (dataswhere != null && dataswhere.Count > 0)
            {
                var sbw = new StringBuilder();
                int indexw = 0;
                foreach (var kvpw in dataswhere)
                {
                    indexw++;
                    sbw.Append($"{kvpw.Key}='{kvpw.Value}'");
                    if (indexw != dataswhere.Count)
                    {
                        sbw.Append(" and ");
                    }
                }
                cmd = $"select * from {tablename} where ({sbw})";
            }
            MySqlDataReader reader = RunReader(cmd);
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        isexist = true;
                    }
                    else
                    {
                        isexist = false;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                reader.Close();
            }
            return isexist;
        }


        /// <summary>
        /// 执行数据库查询行数
        /// </summary>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        public int RunCheckCount(string tablename, Dictionary<string, object> dataswhere, string sqlDateTime)
        {
            int result = 0;
            var sbw = new StringBuilder();
            if (dataswhere != null && dataswhere.Count > 0)
            {
                int indexw = 0;
                foreach (var kvpw in dataswhere)
                {
                    indexw++;
                    sbw.Append($"{kvpw.Key}='{kvpw.Value}'");
                    if (indexw != dataswhere.Count)
                    {
                        sbw.Append(" and ");
                    }
                }
                if (!string.IsNullOrEmpty(sqlDateTime))
                {
                    sbw.Append($" and {sqlDateTime}");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(sqlDateTime))
                {
                    sbw.Append($"{sqlDateTime}");
                }
            }
            string cmd = $"select count(*) from {tablename}";
            if (sbw.Length > 0)
            {
                cmd = $"select count(*) from {tablename} where ({sbw})";
            }
            MySqlDataReader reader = RunReader(cmd);
            try
            {
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                    break;
                }
            }
            catch
            {
            }
            finally
            {
                reader.Close();
            }
            return result;
        }

        /// <summary>
        /// 执行数据库查询总数
        /// </summary>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        public long RunCheckSum(string tablename, string dataname, Dictionary<string, object> dataswhere, string sqlDateTime)
        {
            long result = 0;
            var sbw = new StringBuilder();
            if (dataswhere != null && dataswhere.Count > 0)
            {
                int indexw = 0;
                foreach (var kvpw in dataswhere)
                {
                    indexw++;
                    sbw.Append($"{kvpw.Key}='{kvpw.Value}'");
                    if (indexw != dataswhere.Count)
                    {
                        sbw.Append(" and ");
                    }
                }
                if (!string.IsNullOrEmpty(sqlDateTime))
                {
                    sbw.Append($" and {sqlDateTime}");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(sqlDateTime))
                {
                    sbw.Append($"{sqlDateTime}");
                }
            }
            string cmd = $"select sum({dataname}) from {tablename}";
            if (sbw.Length > 0)
            {
                cmd = $"select sum({dataname}) from {tablename} where ({sbw})";
            }
            MySqlDataReader reader = RunReader(cmd);
            try
            {
                while (reader.Read())
                {
                    result = reader.GetInt64(0);
                    break;
                }
            }
            catch
            {
            }
            finally
            {
                reader.Close();
            }
            return result;
        }

        /// <summary>
        /// 执行数据库读取
        /// </summary>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        public bool RunReader(string tablename, Dictionary<string, object> dataswhere, ref Dictionary<string, object> datasread)
        {
            bool isexist = false;
            string cmd = $"select * from {tablename} where 1=1";
            if (dataswhere != null && dataswhere.Count > 0)
            {
                var sbw = new StringBuilder();
                int indexw = 0;
                foreach (var kvpw in dataswhere)
                {
                    indexw++;
                    sbw.Append($"{kvpw.Key}='{kvpw.Value}'");
                    if (indexw != dataswhere.Count)
                    {
                        sbw.Append(" and ");
                    }
                }
                cmd = $"select * from {tablename} where ({sbw})";
            }
            MySqlDataReader reader = RunReader(cmd);
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        isexist = true;
                        var datasreadkeys = new List<string>(datasread.Keys);
                        foreach (var item in datasreadkeys)
                        {
                            datasread[item] = reader[item];
                        }
                    }
                    else
                    {
                        isexist = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ServerLoger.loger.Fatal($"执行数据库读取错误", ex);
            }
            finally
            {
                reader.Close();
            }
            return isexist;
        }

        /// <summary>
        /// 执行数据库读取
        /// </summary>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        public bool RunReader(string tablename, Dictionary<string, object> dataswhere, List<string> datasreadkeys, out List<Dictionary<string, object>> listdatasread)
        {
            listdatasread = new List<Dictionary<string, object>>();
            bool isexist = false;
            string cmd = $"select * from {tablename}";
            if (dataswhere != null && dataswhere.Count > 0)
            {
                var sbw = new StringBuilder();
                int indexw = 0;
                foreach (var kvpw in dataswhere)
                {
                    indexw++;
                    sbw.Append($"{kvpw.Key}='{kvpw.Value}'");
                    if (indexw != dataswhere.Count)
                    {
                        sbw.Append(" and ");
                    }
                }
                cmd = $"select * from {tablename} where ({sbw})";
            }
            MySqlDataReader reader = RunReader(cmd);
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        isexist = true;
                        var datasread = new Dictionary<string, object>();
                        foreach (var item in datasreadkeys)
                        {
                            datasread[item] = reader[item];
                        }
                        listdatasread.Add(datasread);
                    }
                    else
                    {
                        isexist = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ServerLoger.loger.Fatal($"执行数据库读取错误", ex);
            }
            finally
            {
                reader.Close();
            }
            return isexist;
        }

        /// <summary>
        /// 执行数据库排序读取
        /// </summary>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        public bool RunOrderReader(string tablename, Dictionary<string, string> listorders, int limit, List<string> datasreadkeys, ref List<Dictionary<string, object>> listdatasread)
        {
            bool isexist = false;
            string cmd = $"select * from {tablename} limit {limit}";
            if (listorders.Count > 0)
            {
                var sbw = new StringBuilder();
                int indexw = 0;
                foreach (var kvpw in listorders)
                {
                    indexw++;
                    sbw.Append($"{kvpw.Key} {kvpw.Value}");
                    if (indexw != listorders.Count)
                    {
                        sbw.Append(", ");
                    }
                }
                cmd = $"select * from {tablename} ORDER BY {sbw} limit {limit}";
            }
            MySqlDataReader reader = RunReader(cmd);
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        isexist = true;
                        var datasread = new Dictionary<string, object>();
                        foreach (var item in datasreadkeys)
                        {
                            datasread[item] = reader[item];
                        }
                        listdatasread.Add(datasread);
                    }
                    else
                    {
                        isexist = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ServerLoger.loger.Fatal($"执行数据库读取错误", ex);
            }
            finally
            {
                reader.Close();
            }
            return isexist;
        }

        /// <summary>
        /// 执行数据库读取
        /// </summary>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        public DataTable RunReadDataTable(string tablename, Dictionary<string, object> dataswhere, string sqlDateTime)
        {
            if (!IniConf.ConfSwitch.MysqlState)
            {
                return null;
            }
            if (DataBaseState != 1)
            {
                return null;
            }

            try
            {
                var sbw = new StringBuilder();
                if (dataswhere != null && dataswhere.Count > 0)
                {
                    int indexw = 0;
                    foreach (var kvpw in dataswhere)
                    {
                        indexw++;
                        sbw.Append($"{kvpw.Key}='{kvpw.Value}'");
                        if (indexw != dataswhere.Count)
                        {
                            sbw.Append(" and ");
                        }
                    }
                    if (!string.IsNullOrEmpty(sqlDateTime))
                    {
                        sbw.Append($" and {sqlDateTime}");
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sqlDateTime))
                    {
                        sbw.Append($"{sqlDateTime}");
                    }
                }
                string cmd = $"select * from {tablename}";
                if (sbw.Length > 0)
                {
                    cmd = $"select * from {tablename} where ({sbw})";
                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd, DataBaseUser);
                DataSet MyDataSet = new DataSet();
                da.Fill(MyDataSet);
                return MyDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                ServerLoger.loger.Fatal($"执行数据库读取错误", ex);
                return null;
            }
        }

        //static void ttt()
        //{
        //    string ConnectionString = "Database=test;Data Source=192.168.0.150;User Id=root;Password=jiayou123";//其中localhost表示连接本地数据库 改为相应的Id则可以实现远程连接

        //    MySqlConnection dbconn = new MySqlConnection(ConnectionString);//连接MySQL数据库

        //    MySqlCommand cmd = dbconn.CreateCommand();

        //    cmd.Connection.Open();
        //    cmd.CommandType = CommandType.Text;
        //    if (RunCommand(cmd, "select * from MyTable1 where 1 = 1 "))
        //    {
        //        RunCommand(cmd, "drop table mytable1");                                                //删除表格
        //        RunCommand(cmd, "set names 'gb2312' / 'utf8' ");
        //        RunCommand(cmd, "create table MyTable1( name varchar(20),sex varchar(20),age int(3) ) ");//新建表
        //        RunCommand(cmd, "Alter table MyTable1 add primary key(name)");                           //添加主键
        //        RunCommand(cmd, "Alter table MyTable1 drop  primary key");                              //删除主键
        //        RunCommand(cmd, "insert into MyTable1( name, sex, age ) values('李雷','男','20')");     //插入数据
        //        RunCommand(cmd, "delete from MyTable1 where name = '李雷' ");                           //删除数据
        //        RunCommand(cmd, "insert into MyTable1( name, sex, age ) values('李雷','男','20')");     //插入数据
        //        RunCommand(cmd, "update MyTable1   set age = 22 where name = '李雷'");                  //修改数据
        //    }
        //    else
        //    {
        //        RunCommand(cmd, "set names 'gb2312' / 'utf8' ");
        //        RunCommand(cmd, "create table MyTable1( name varchar(20),sex varchar(20),age int(3) ) ");   //新建表
        //        RunCommand(cmd, "Alter table MyTable1 add primary key(name)");                              //添加主键
        //        RunCommand(cmd, "Alter table MyTable1 drop  primary key");                                  //删除主键
        //        RunCommand(cmd, "insert into MyTable1( name, sex, age ) values('李雷','男','20')");         //插入数据
        //        RunCommand(cmd, "delete from MyTable1 where name = '李雷' ");                               //删除数据
        //        RunCommand(cmd, "insert into MyTable1( name, sex, age ) values('李雷','男','20')");         //插入数据
        //        RunCommand(cmd, "update MyTable1   set age = 22 where name = '李雷'");                      //修改数据
        //    }

        //    string filePath = "d:\\tmp\\tl.sql";
        //    //将数据导出
        //    if (File.Exists(filePath))
        //    {
        //        File.Delete(filePath);
        //        RunCommand(cmd, "select * from MyTable1 where 1=1 into outfile 'd:/tmp/tl.sql'");
        //    }
        //    else
        //    {
        //        RunCommand(cmd, "select * from MyTable1 where 1=1 into outfile 'd:/tmp/tl.sql'");
        //    }

        //    //用DataSet获取数据
        //    //////////////////////////////////////////////////////////////////////////
        //    MySqlDataAdapter da = new MySqlDataAdapter("select * from MyTable1 where 1 = 1 ", dbconn);
        //    DataSet MyDataSet = new DataSet();
        //    da.Fill(MyDataSet);
        //    DataTable tbl = MyDataSet.Tables[0];//获取第一张表

        //    foreach (DataColumn col in tbl.Columns)
        //    {
        //        Console.WriteLine(col.ColumnName);//打印列名
        //    }
        //    DataRow irow = tbl.Rows[0];

        //    Console.WriteLine(irow["name"]);//打印name列的数据
        //    Console.WriteLine(irow["age"]);
        //    Console.WriteLine(irow["sex"]);

        //    tbl = irow.Table;

        //    foreach (DataColumn col in tbl.Columns)
        //    {
        //        Console.WriteLine(irow[col]);//循环打印某行数据
        //    }
        //    //用MySqlDataReader获取数据
        //    //////////////////////////////////////////////////////////////////////////
        //    MySqlDataReader reader;
        //    cmd.CommandText = "select * from MyTable1 where 1 = 1 ";
        //    reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Console.WriteLine(reader["age"].ToString());
        //        Console.WriteLine(reader["name"].ToString());
        //        Console.WriteLine(reader["sex"].ToString());

        //    }
        //}
    }
    

}