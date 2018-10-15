using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ProtocolTool
{
    partial class Program
    {
        private static void ProtocolReader()
        {
            Show("ProtocolReader");
            ProtocolReaderDir(PathCurrentDesign);
        }
        private static void ProtocolReaderDir(string path)
        {
            foreach (string ptlname in Directory.GetFileSystemEntries(path))
            {
                if (File.Exists(ptlname))
                {
                    if (Path.GetExtension(ptlname) == ".txt")
                    {
                        ProtocolReaderFile(ptlname);
                    }
                }
            }
            foreach (string ptlname in Directory.GetDirectories(path))
            {
                ProtocolReaderDir(ptlname);
            }
        }

        private static void ProtocolReaderFile(string ptlname)
        {
            Show($"读取文件：{ptlname}");
            try
            {
                FileStream fs_PTL = new FileStream(ptlname, FileMode.Open);
                StreamReader sr_PTL = new StreamReader(fs_PTL, Encoding.Default);

                while ((LineText = sr_PTL.ReadLine()) != null)
                {
                    LineCount++;
                    ProtocolReaderLine();
                }

                sr_PTL.Close();
            }
            catch (Exception ex)
            {
                Error($"ProtocolReaderFile 错误！第{LineCount}行：{LineText}", ex);
            }
        }

        private static void ProtocolReaderLine()
        {
            if (LineText == "")
            {
                return;
            }
            if (LineText[0] == '$')
            {
                if (LineText.Length >= 2)
                {
                    if (LineText[1] == '$')
                    {
                        MMode2 = LineText.TrimStart('$');
                    }
                    else
                    {
                        MMode1 = LineText.TrimStart('$');
                    }
                }
                return;
            }
            if (LineText[0] == '@')
            {
                ClassDesc = LineText.TrimStart('@');
                return;
            }
            LineText.Trim();
            ProtocolReaderLineAnalyze();

            if (LineContect.Count <= 0)
            {
                return;
            }
            if (LineContect[0] == "enums")
            {
                BodyType = EBodyType.eBodyTypeEnum;
                EnumCurrent = new CEnum(LineContect[1], ClassDesc);
                CEnumId = 0;
            }
            else if (LineContect[0] == "enume")
            {
                DictEnum.Add(EnumCurrent.Name, EnumCurrent);
            }
            else if (LineContect[0] == "msgs")
            {
                BodyType = EBodyType.eBodyTypeClass;
                if (LineContect.Count > 2)
                {
                    ClassCurrent = new CClass(0, LineContect[1], ClassDesc, S2I(LineContect[2]));
                }
                else
                {
                    ClassCurrent = new CClass(0, LineContect[1], ClassDesc);
                }
            }
            else if (LineContect[0] == "msge")
            {
                DictClass.Add(ClassCurrent.Name, ClassCurrent);
            }
            else if (LineContect[0] == "pubs")
            {
                BodyType = EBodyType.eBodyTypeClass;
                if (LineContect.Count > 2)
                {
                    ClassCurrent = new CClass(1, LineContect[1], ClassDesc, S2I(LineContect[2]));
                }
                else
                {
                    ClassCurrent = new CClass(1, LineContect[1], ClassDesc);
                }
            }
            else if (LineContect[0] == "pube")
            {
                DictClass.Add(ClassCurrent.Name, ClassCurrent);
            }
            else
            {
                if (BodyType == EBodyType.eBodyTypeEnum)
                {
                    var node = new CEnum.Node()
                    {
                        Line = LineCount,
                        Body = LineContect[0],
                    };
                    if (LineContect.Count > 1)
                    {
                        CEnumId = S2I(LineContect[1]);
                        node.Value = CEnumId;
                    }
                    else
                    {
                        CEnumId++;
                        node.Value = CEnumId;
                    }
                    node.Desc = LineDesc;
                    EnumCurrent.DictBody.Add(LineCount, node);
                }
                else if (BodyType == EBodyType.eBodyTypeClass)
                {
                    var node = new CClassNode();
                    GetNodeFromLine(ref node);
                    ClassCurrent.DictBody.Add(LineCount, node);
                }
            }
        }

        private static void ProtocolReaderLineAnalyze()
        {
            LineDesc = "";
            LineContect.Clear();

            string[] words1 = LineText.Split(strSeparators1, StringSplitOptions.RemoveEmptyEntries);
            string str_contect = words1[0].Trim();
            if (words1.Length >= 2)
            {
                LineDesc = words1[1].Trim();
            }
            LineContect = str_contect.Split(strSeparators2, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}