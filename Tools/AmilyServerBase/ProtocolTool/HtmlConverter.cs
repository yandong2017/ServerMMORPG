using System.IO;
using System.Text;
using System;
using System.Collections.Generic;

namespace ProtocolTool
{
    partial class Program
    {
        public static readonly string Filepath_Html = @"协议大纲.html";
        public static readonly string Template_Html = @"<!DOCTYPE html>
<html>
<head>
<link rel=""stylesheet"" href=""http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.css"" >
<script src = ""http://code.jquery.com/jquery-1.8.3.min.js""></script >
<script src=""http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.js"" ></script>
</head>
<body>

<div data-role=""page"" id=""pageone"" >
    <div data-role=""header"" >
        <h1>协议大纲</h1>
    </div>

    <div data-role=""content"" >

$CONTENT$

    </div>
  
    <div data-role=""footer"" >
        <h1>完</h1>
    </div>
</div> 

</body>
</html>

";

        /// <summary>
        /// 生成 html 文件
        /// </summary>
        private static void ProtocolConverterHtml()
        {
            Show("ProtocolConverterHtml");
            var sb = new StringBuilder();

            Dictionary<string, Dictionary<string, Dictionary<string, CClass>>> DictDictDictClass = new Dictionary<string, Dictionary<string, Dictionary<string, CClass>>>();
            string md1 = "";
            string md2 = "";
            foreach (var nn1 in DictClass.Values)
            {
                if (nn1.Mode1 != md1)
                {
                    md1 = nn1.Mode1;
                }
                if (!DictDictDictClass.TryGetValue(md1, out var d1))
                {
                    d1 = new Dictionary<string, Dictionary<string, CClass>>();
                    DictDictDictClass[md1] = d1;
                }
                if (nn1.Mode2 != md2)
                {
                    md2 = nn1.Mode2;
                }
                if (!d1.TryGetValue(md2, out var d2))
                {
                    d2 = new Dictionary<string, CClass>();
                    d1[md2] = d2;
                }
                d2[nn1.Name] = nn1;
            }
            foreach (var kvp1 in DictDictDictClass)
            {
                sb.Append($"<div data-role=\"collapsible\">\r\n");
                sb.Append($"<h1>{kvp1.Key}</h1>\r\n");
                foreach (var kvp2 in kvp1.Value)
                {
                    sb.Append($"<div data-role=\"collapsible\">\r\n");
                    sb.Append($"<h1>{kvp2.Key}</h1>\r\n");
                    foreach (var item in kvp2.Value.Values)
                    {
                        sb.Append($"<div data-role=\"collapsible\">\r\n");
                        if (item.ClassType == 0)
                        {
                            sb.Append($"<h1>协议类 {item.Name} {item.Desc}</h1>\r\n");
                        }
                        else
                        {
                            sb.Append($"<h1>公共类 {item.Name} {item.Desc}</h1>\r\n");
                        }
                        sb.Append($"<p>-----{item.Name}-----{item.NameId}-----</p>\r\n");
                        foreach (var bb2 in item.DictBody.Values)
                        {
                            sb.Append($"<p>{GetClassBodyHtml(bb2)}</p>\r\n");
                        }
                        sb.Append($"</div>\r\n");
                    }
                    sb.Append($"</div>\r\n");
                }
                sb.Append($"</div>\r\n");
            }
            string txt = Template_Html;
            FileStream fs = new FileStream(PathCurrent + Filepath_Html, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, new System.Text.UTF8Encoding(false));
            txt = txt.Replace("$CONTENT$", sb.ToString());
            sw.Write(txt);
            sw.Close();
            Show("输出文件：" + Filepath_Html);
        }

        //成员和初始化
        public static string GetClassBodyHtml(CClassNode v)
        {
            var sb = new StringBuilder();
            switch (v.Ctype)
            {
                case "list":
                    sb.Append($"List[{v.Ctype1}] {v.Body}");
                    break;
                case "dict":
                    sb.Append($"Dictionary[{v.Ctype1}, {v.Ctype2}] {v.Body}");
                    break;
                default:
                    sb.Append($"{v.Ctype} {v.Body}");
                    break;
            }
            if (!string.IsNullOrEmpty(v.Desc))
            {
                sb.Append($"  //{v.Desc}");
            }
            return sb.ToString();
        }
    }
}