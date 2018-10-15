using System.IO;
using System.Text;
using System;
using Microsoft.Office.Interop.Word;

namespace ProtocolTool
{
    partial class Program
    {
        //Word文件
        public static Microsoft.Office.Interop.Word.Application WordApp = null;
        public static Microsoft.Office.Interop.Word.Document WordDoc = null;
        public static Object Nothing = System.Reflection.Missing.Value;

        /// <summary>
        /// 添加标题1
        /// </summary>
        /// <param name="s"></param>
        public static void AddTitle1(string s)
        {
            //Word段落
            Microsoft.Office.Interop.Word.Paragraph p;
            p = WordDoc.Content.Paragraphs.Add(ref Nothing);
            //设置段落中的内容文本
            p.Range.Text = s;
            //设置为一号标题
            object style = Microsoft.Office.Interop.Word.WdBuiltinStyle.wdStyleHeading1;
            p.set_Style(ref style);
            //添加到末尾
            p.Range.InsertParagraphAfter();  //在应用 InsertParagraphAfter 方法之后，所选内容将扩展至包括新段落。
        }
        /// <summary>
        /// 添加标题2
        /// </summary>
        /// <param name="s"></param>
        public static void AddTitle2(string s)
        {
            //Word段落
            Microsoft.Office.Interop.Word.Paragraph p;
            p = WordDoc.Content.Paragraphs.Add(ref Nothing);
            //设置段落中的内容文本
            p.Range.Text = s;
            //设置为一号标题
            object style = Microsoft.Office.Interop.Word.WdBuiltinStyle.wdStyleHeading2;
            p.set_Style(ref style);
            //添加到末尾
            p.Range.InsertParagraphAfter();  //在应用 InsertParagraphAfter 方法之后，所选内容将扩展至包括新段落。
        }
        /// <summary>
        /// 添加标题3
        /// </summary>
        /// <param name="s"></param>
        public static void AddTitle3(string s)
        {
            //Word段落
            Microsoft.Office.Interop.Word.Paragraph p;
            p = WordDoc.Content.Paragraphs.Add(ref Nothing);
            //设置段落中的内容文本
            p.Range.Text = s;
            //设置为一号标题
            object style = Microsoft.Office.Interop.Word.WdBuiltinStyle.wdStyleHeading3;
            p.set_Style(ref style);
            //添加到末尾
            p.Range.InsertParagraphAfter();  //在应用 InsertParagraphAfter 方法之后，所选内容将扩展至包括新段落。
        }
        /// <summary>
        /// 添加标题4
        /// </summary>
        /// <param name="s"></param>
        public static void AddTitle4(string s)
        {
            //Word段落
            Microsoft.Office.Interop.Word.Paragraph p;
            p = WordDoc.Content.Paragraphs.Add(ref Nothing);
            //设置段落中的内容文本
            p.Range.Text = s;
            //设置为一号标题
            object style = Microsoft.Office.Interop.Word.WdBuiltinStyle.wdStyleHeading4;
            p.set_Style(ref style);
            //添加到末尾
            p.Range.InsertParagraphAfter();  //在应用 InsertParagraphAfter 方法之后，所选内容将扩展至包括新段落。
        }
        /// <summary>
        /// 添加普通段落
        /// </summary>
        /// <param name="s"></param>
        public static void AddParagraph(string s)
        {
            Microsoft.Office.Interop.Word.Paragraph p;
            p = WordDoc.Content.Paragraphs.Add(ref Nothing);
            p.Range.Text = s;
            object style = Microsoft.Office.Interop.Word.WdBuiltinStyle.wdStyleBodyText;
            p.set_Style(ref style);
            p.Range.InsertParagraphAfter();
        }

        /// <summary>
        /// 生成协议大纲文档文件
        /// </summary>
        private static void ProtocolConverterWord()
        {
            Show("ProtocolConverterWord");
            Show("正在生成协议大纲。。。。。。。请勿退出！");

            //创建word
            WordApp = new Microsoft.Office.Interop.Word.Application();
            //创建word文档
            WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

            string md1 = "";
            string md2 = "";
            foreach (var nn1 in DictClass.Values)
            {
                if (nn1.Mode1 != md1)
                {
                    md1 = nn1.Mode1;
                    AddTitle1(md1);
                }
                if (nn1.Mode2 != md2)
                {
                    md2 = nn1.Mode2;
                    AddTitle2(md2);
                }
                if (nn1.ClassType == 0)
                {
                    AddTitle3("协议类 " + nn1.Name + " " + nn1.Desc);
                    AddParagraph("对应ID：  " + nn1.NameId);
                }
                else
                {
                    AddTitle3("公共类 " + nn1.Name + " " + nn1.Desc);
                }
                foreach (var nn2 in nn1.DictBody.Values)
                {
                    AddParagraph("  " + GetClassBodyFromNode(nn2));
                }
            }

            //文件保存
            object FileName = PathCurrent + @"协议大纲.docx";  //文件保存路径
            WordDoc.SaveAs(ref FileName, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
            WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
        }

    }
}