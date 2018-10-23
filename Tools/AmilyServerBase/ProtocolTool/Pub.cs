using System;
using System.Text;

namespace ProtocolTool
{
    partial class Program
    {
        //类型转化
        public static string TypeConvert(string v)
        {
            string value = v.ToLower();
            switch (value)
            {
                case "int8":
                    return "byte";

                case "int16":
                    return "short";

                case "int32":
                    return "int";

                case "uint32":
                    return "uint";

                case "int64":
                    return "long";

                case "vector":
                    return "list";

                case "map":
                    return "dict";

                case "dt":
                case "datetime":
                case "DateTime":
                    return "DateTime";

                case "ts":
                case "timespan":
                case "TimeSpan":
                    return "TimeSpan";

                default:
                    return v;
            }
        }

        //成员转化
        public static void GetNodeFromLine(ref CClassNode node)
        {
            node.Line = LineCount;
            node.Desc = LineDesc;
            node.Ctype = TypeConvert(LineContect[0]);
            switch (node.Ctype)
            {
                case "list":
                    node.Ctype1 = LineContect[1];
                    node.Body = LineContect[2];
                    break;

                case "dict":
                    node.Ctype1 = LineContect[1];
                    node.Ctype2 = LineContect[2];
                    node.Body = LineContect[3];
                    break;

                default:
                    node.Body = LineContect[1];
                    break;
            }
        }

        //成员和初始化
        public static string GetClassBodyFromNode(CClassNode v)
        {
            var sb = new StringBuilder();
            
            //if (v.Desc != "")
            //{
            //    sb.Append($"        [Desc(\"{v.Desc}\")]\r\n");
            //}
            switch (v.Ctype)
            {
                case "bool":
                    sb.Append($"        public {v.Ctype} {v.Body} = false;");
                    break;
                case "byte":
                case "short":
                case "int":
                case "uint":
                case "long":
                    sb.Append($"        public {v.Ctype} {v.Body} = 0;");
                    break;

                case "float":
                    sb.Append($"        public {v.Ctype} {v.Body} = 0.0f;");
                    break;

                case "string":
                    sb.Append($"        public {v.Ctype} {v.Body} = \"\";");
                    break;

                case "dt":
                case "datetime":
                case "DateTime":
                    sb.Append($"        public {v.Ctype} {v.Body} = {v.Ctype}.Now;");
                    break;

                case "list":
                    sb.Append($"        public List<{v.Ctype1}> {v.Body} = new List<{v.Ctype1}>();");
                    break;

                case "dict":
                    sb.Append($"        public Dictionary<{v.Ctype1}, {v.Ctype2}> {v.Body} = new Dictionary<{v.Ctype1}, {v.Ctype2}>();");
                    break;

                default:
                    sb.Append($"        public {v.Ctype} {v.Body} = new {v.Ctype}();");
                    break;
            }
            //if (v.Desc != "")
            //{
            //    sb.Append($"    // {v.Desc}");
            //}
            return sb.ToString();
        }

        //成员序列化
        public static string GetClassSerializeFromNodeType(CClassNode v)
        {
            var sb = new StringBuilder();
            switch (v.Ctype)
            {
                case "list":
                    switch (v.Ctype1)
                    {
                        case "bool":
                        case "byte":
                        case "short":
                        case "int":
                        case "uint":
                        case "long":
                        case "float":
                        case "string":
                        case "DateTime":
                        case "TimeSpan":
                            sb.Append($"nbs.Write(k);");
                            break;

                        default:
                            sb.Append($"k.Serialize(nbs);");
                            break;
                    }
                    break;

                case "dict":
                    sb.Append($"nbs.Write(kvp.Key);");
                    switch (v.Ctype2)
                    {
                        case "bool":
                        case "byte":
                        case "short":
                        case "int":
                        case "uint":
                        case "long":
                        case "float":
                        case "string":
                        case "DateTime":
                        case "TimeSpan":
                            sb.Append($"nbs.Write(kvp.Value);");
                            break;

                        default:
                            sb.Append($"kvp.Value.Serialize(nbs);");
                            break;
                    }
                    break;

                default:
                    break;
            }
            return sb.ToString();
        }

        //成员序列化
        public static string GetClassSerializeFromNode(CClassNode v, string space)
        {
            var sb = new StringBuilder();
            switch (v.Ctype)
            {
                case "bool":
                case "byte":
                case "short":
                case "int":
                case "uint":
                case "long":
                case "float":
                case "string":
                case "DateTime":
                case "TimeSpan":
                    sb.Append($"{space}nbs.Write({v.Body});\r\n");
                    break;

                case "list":
                    sb.Append($"{space}nbs.Write({v.Body}.Count);\r\n");
                    sb.Append($"{space}foreach (var k in {v.Body})\r\n");
                    sb.Append($"{space}{{\r\n");
                    sb.Append($"    {space}{GetClassSerializeFromNodeType(v)}\r\n");
                    sb.Append($"{space}}}\r\n");
                    break;

                case "dict":
                    sb.Append($"{space}nbs.Write({v.Body}.Count);\r\n");
                    sb.Append($"{space}foreach (var kvp in {v.Body})\r\n");
                    sb.Append($"{space}{{\r\n");
                    sb.Append($"    {space}{GetClassSerializeFromNodeType(v)}\r\n");
                    sb.Append($"{space}}}\r\n");
                    break;

                default:
                    if (v.Ctype.Length > 0 && v.Ctype[0] == 'E')
                    {
                        sb.Append($"{space}nbs.Write((short){v.Body});\r\n");
                    }
                    else
                    {
                        sb.Append($"{space}{v.Body}.Serialize(nbs);\r\n");
                    }
                    break;
            }
            return sb.ToString();
        }

        //成员反序列化
        public static string GetClassUnserializeFromNodeType(CClassNode v)
        {
            var sb = new StringBuilder();
            string varname = GetVariablesId();
            switch (v.Ctype)
            {
                case "list":
                    switch (v.Ctype1)
                    {
                        case "bool":
                        case "byte":
                        case "short":
                        case "int":
                        case "uint":
                        case "long":
                        case "float":
                        case "string":
                        case "DateTime":
                        case "TimeSpan":
                            sb.Append($"nbs.Read(out {v.Ctype1} {varname});"); break;
                        default:
                            sb.Append($"var {varname} = new {v.Ctype1}(); {varname}.Unserialize(nbs);");
                            break;
                    }
                    sb.Append($"{v.Body}.Add({varname});");
                    break;

                case "dict":
                    switch (v.Ctype1)
                    {
                        case "bool":
                        case "byte":
                        case "short":
                        case "int":
                        case "uint":
                        case "long":
                        case "float":
                        case "string":                            
                            sb.Append($"nbs.Read(out {v.Ctype1} {varname}); "); break;
                        default:
                            sb.Append($"var {varname} = new {v.Ctype1}(); {varname}.Unserialize(nbs); ");
                            break;
                    }
                    string varname2 = GetVariablesId();
                    switch (v.Ctype2)
                    {
                        case "bool":
                        case "byte":
                        case "short":
                        case "int":
                        case "uint":
                        case "long":
                        case "float":
                        case "string":
                        case "DateTime":
                        case "TimeSpan":
                            sb.Append($"nbs.Read(out {v.Ctype2} {varname2}); "); break;

                        default:
                            sb.Append($"var {varname2} = new {v.Ctype2}(); {varname2}.Unserialize(nbs); ");
                            break;
                    }
                    sb.Append($"{v.Body}.Add({varname}, {varname2}); ");
                    break;

                default:
                    break;
            }
            return sb.ToString();
        }

        //成员反序列化
        public static string GetClassUnserializeFromNode(CClassNode v, string space)
        {
            var sb = new StringBuilder();
            string varname = GetVariablesId();
            switch (v.Ctype)
            {
                case "bool":
                case "byte":
                case "short":
                case "int":
                case "uint":
                case "long":
                case "float":
                case "string":
                case "DateTime":
                case "TimeSpan":
                    sb.Append($"{space}nbs.Read(out {v.Body});\r\n");
                    break;

                case "list":
                    sb.Append($"{space}nbs.Read(out int {varname});\r\n");
                    sb.Append($"{space}for (int k = 0; k < {varname}; k++)\r\n");
                    sb.Append($"{space}{{\r\n");
                    sb.Append($"    {space}{GetClassUnserializeFromNodeType(v)}\r\n");
                    sb.Append($"{space}}}\r\n");
                    break;

                case "dict":
                    sb.Append($"{space}nbs.Read(out int {varname});\r\n");
                    sb.Append($"{space}for (int k = 0; k < {varname}; k++)\r\n");
                    sb.Append($"{space}{{\r\n");
                    sb.Append($"    {space}{GetClassUnserializeFromNodeType(v)}\r\n");
                    sb.Append($"{space}}}\r\n");
                    break;

                default:
                    if (v.Ctype.Length > 0 && v.Ctype[0] == 'E')
                    {
                        sb.Append($"{space}if (true) {{ nbs.Read(out short etemp); {v.Body} = ({v.Ctype})etemp; }}\r\n");
                    }
                    else
                    {
                        sb.Append($"{space}{v.Body}.Unserialize(nbs);\r\n");
                    }
                    break;
            }
            return sb.ToString();
        }

        //显示
        public static void Show(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{obj}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Error(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{obj}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Error(object obj, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{obj}\n{ex.Message}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //变量ID
        public static int VariablesId = 0;

        public static string GetVariablesId()
        {
            string str = $"var{VariablesId}";
            VariablesId++;
            return str;
        }
    }
}