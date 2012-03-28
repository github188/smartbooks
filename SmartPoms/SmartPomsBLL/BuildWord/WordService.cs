
namespace SmartPoms.BLL.BuildWord {
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    using System.IO.Packaging;
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;

    public static class WordService {

        public static void CreateFile(string fileNamePath) {
            using (WordprocessingDocument objWordDocument = WordprocessingDocument.Create(fileNamePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document)) {
                MainDocumentPart objMainDocumentPart = objWordDocument.AddMainDocumentPart();

                Document objDocument = new Document();
                Body objBody = new Body();

                Paragraph para = objBody.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                RunProperties p = new RunProperties();
                run.RunProperties = p;

                p.FontSize = new FontSize() { Val = "72" };

                run.AppendChild(new Text(" "));

                objDocument.Append(objBody);

                objMainDocumentPart.Document = objDocument;
                objMainDocumentPart.Document.Save();
            }
        }

        public static void ReplaceDocument(string fileNamePath) {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fileNamePath, true)) {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream())) {
                    docText = sr.ReadToEnd();
                }

                Regex regexText = new Regex("H");
                docText = regexText.Replace(docText, "demo,");

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create))) {
                    sw.Write(docText);
                }
            }
        }

        public static bool BuildWeekWordFile(string templateFileName, string newFileName, ReportParam param) {    
            try {
                File.Copy(templateFileName, newFileName, true);

                using (WordprocessingDocument obj = WordprocessingDocument.Open(newFileName, true)) {
                    string docText = "";
                    using (StreamReader sr = new StreamReader(obj.MainDocumentPart.GetStream())) {
                        docText = sr.ReadToEnd();
                    }

                    docText = docText.Replace("$TITLE$", param.Tile);           //标题
                    docText = docText.Replace("$ANNEX$", param.AnnexContent);   //附件内容
                    docText = docText.Replace("$AUTHOR$", param.Author);        //作者
                    docText = docText.Replace("$BODY$", param.BodyContent);     //主题内容
                    docText = docText.Replace("$CREATEDATE$", param.CreateDate);        //创建日期
                    docText = docText.Replace("$NUMBER$", param.Number);        //编号
                    docText = docText.Replace("$PUBLISHDATE$", param.PublishDate);      //发布日期
                    docText = docText.Replace("$PUBLISHWORD$", param.PublishWord);      //发字号
                    docText = docText.Replace("$SUBTITLE$", param.SubTitle);    //子标题
                    docText = docText.Replace("$TEL$", param.Tel);              //电话
                    docText = docText.Replace("$UNITNAME$", param.UnitName);    //单位名称
                    docText = docText.Replace("$YEAR$", param.Year);            //年

                    if (param.KeyWord != null) {
                        string words = "";
                        foreach (string k in param.KeyWord) {
                            words += k + " ";
                        }
                        docText = docText.Replace("$KEYWORD$", words);              //关键字
                    }

                    using (StreamWriter sw = new StreamWriter(obj.MainDocumentPart.GetStream(FileMode.Create))) {
                        sw.Write(docText);
                    }

                    obj.MainDocumentPart.Document.Save();
                    obj.Close();
                }
            } catch (Exception ex) {
                throw ex;
            }
            return true;
        }
    }
}
