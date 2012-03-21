using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data;
using System.IO;
using Mozilla.NUniversalCharDet;
using html = HtmlAgilityPack;

namespace Smart.Spider.Client {
    public class TaskUnit {
        #region 公共字段
        public HttpHelper http = new HttpHelper();
        public List<string> UrlRegx = new List<string>();
        System.Threading.Timer t;
        public List<string> FirstCache = new List<string>();
        public string Url = "";
        public Encoding encoding = Encoding.Default;
        #endregion

        #region 私有字段
        private List<SmartPoms.Entity.BASE_WORD> word = new List<SmartPoms.Entity.BASE_WORD>();
        private List<SmartPoms.Entity.BASE_EVENTWORD> eventword = new List<SmartPoms.Entity.BASE_EVENTWORD>();
        #endregion

        public TaskUnit(string url) {
            Url = url;

            BindUrlRegex();
            BindWords();
            t = new System.Threading.Timer(new TimerCallback(Time_Tick), "", Timeout.Infinite, Timeout.Infinite);
        }

        public void Start() {
            t.Change(0, 60000);
        }
        public void Stop() {
            t.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private List<string> ParseHtmlTextUrl(string htmlText) {
            List<string> url = new List<string>();

            foreach (string reg in UrlRegx) {
                MatchCollection coll = Regex.Matches(htmlText.ToLower(), reg);
                foreach (Match match in coll) {
                    url.Add(match.Value);
                }
            }

            return url;
        }

        private List<string> ClearRepeatedElement(List<string> cache, List<string> current) {
            List<string> newsUrl = new List<string>();
            foreach (string u in current) {
                if (!cache.Contains(u)) {
                    newsUrl.Add(u);
                    FirstCache.Add(u);
                }
            }
            return newsUrl;
        }

        private void Exec(object url) {

            #region 抓取下一层Url
            string title = "";
            string content = "";
            Stream stream = http.RequestResult((string)url, 5000);
            if (stream == null) return;
            //内容编码自动识别
            DetectedCharset(stream, out content, out encoding);
            #endregion

            /*截取标题和内容*/
            try {
                int beginIndex = content.IndexOf("<title>");
                int endIndex = content.IndexOf("</title>");
                title = content.Substring(beginIndex + 7, endIndex - beginIndex - 7);
                beginIndex = content.IndexOf("<body>");
                endIndex = content.IndexOf("</body>");
                content = content.Substring(beginIndex + 6, endIndex - beginIndex - 6);
            } catch { }

            html.HtmlDocument doc = new html.HtmlDocument();
            doc.LoadHtml(@content);
            content = doc.DocumentNode.InnerText;

            #region 过滤文章内容为纯汉字
            StringBuilder wordText = new StringBuilder();
            MatchCollection coll = Regex.Matches(content, @"[\u4E00-\u9FA5,，]");
            //MatchCollection coll = Regex.Matches(content, @"(?<=>)(\s*[^><]*[\u4e00-\u9fa5]+\s*)+");
            foreach (Match m in coll) {
                wordText.Append(m.Value);
            }
            content = wordText.ToString();
            content = content.Replace(" ", "");
            content = content.Replace(",,", "");
            content = content.Replace("，，", "");
            content = content.Replace("\r", "");
            content = content.Replace("\n", "");
            content = content.Replace("\t", "");
            coll = Regex.Matches(content, @"&[a-z]+;");
            foreach (Match m in coll) {
                content = content.Replace(m.Value, "");
            }

            #endregion

            #region 文章自动分类
            /*文章自动分类*/
            List<SmartPoms.Entity.BASE_WORD> c = new List<SmartPoms.Entity.BASE_WORD>();
            foreach (SmartPoms.Entity.BASE_WORD w in word) {
                if (content.Contains(w.WordName)) {
                    c.Add(w);
                }
            }
            List<int> eventId = new List<int>();    //文章所属分类ID
            foreach (SmartPoms.Entity.BASE_EVENTWORD e in eventword) {
                foreach (SmartPoms.Entity.BASE_WORD w in c) {
                    if (e.WordID == w.WordID) {
                        eventId.Add(e.EventID);
                    }
                }
            }
            #endregion

            #region 文章加入数据库
            /*截取文章标题和内容为指定的长度*/
            if (title.Length > 80) {
                title = title.Substring(0, 80);
            }
            if (content.Length > 8000) {
                content = content.Substring(0, 8000);
            }

            title = title.Replace("'", "\"");
            content = content.Replace("'", "\"");

            /*要求文章标题和内容同时不为空*/
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(content) && eventId.Count != 0) {
                /*将文章归类*/
                string sec = string.Format("SELECT top 2 articleid from base_article where Title='{0}'", title);
                DataTable dt = Smart.DBUtility.SqlServerHelper.Query(sec).Tables[0];
                string currentArticleId;
                if (dt != null && dt.Rows.Count == 0) {
                    /*添加文章*/
                    SmartPoms.SQLServerDAL.BASE_ARTICLE art = new SmartPoms.SQLServerDAL.BASE_ARTICLE();
                    art.Add(new SmartPoms.Entity.BASE_ARTICLE() {
                        Title = title,
                        Detail = content,
                        Url = this.http.WebRequest.RequestUri.AbsoluteUri,
                        Author = "",
                        ClickNum = 0,
                        CommentNum = 0,
                        ExtractionTime = DateTime.Now,
                        Media = "",
                        Score = 0,
                        SendTime = DateTime.Now
                    });

                    /*重新查询出该文章,并初始化文章ID*/
                    dt = Smart.DBUtility.SqlServerHelper.Query(sec).Tables[0];
                    currentArticleId = dt.Rows[0]["articleid"].ToString();
                }

                /*判断该文章在EventAericle标题是否已经归类*/
                if (dt != null && dt.Rows.Count == 1) {
                    /*初始化文章ID*/
                    currentArticleId = dt.Rows[0]["articleid"].ToString();
                    string getEventArticleId = string.Format("select top 1 articleid from Base_EventArticle where articleid={0}",
                        currentArticleId);
                    dt = Smart.DBUtility.SqlServerHelper.Query(getEventArticleId).Tables[0];

                    /*如果该文章从未在分类表中出现，那么加入自动匹配的分类下*/
                    if (dt.Rows.Count == 0) {
                        /*加入分类*/
                        SmartPoms.SQLServerDAL.BASE_EVENTARTICLE eventArticle = new SmartPoms.SQLServerDAL.BASE_EVENTARTICLE();
                        foreach (int e in eventId) {
                            eventArticle.Add(new SmartPoms.Entity.BASE_EVENTARTICLE() {
                                ArticleID = Convert.ToInt32(currentArticleId),
                                EventID = e
                            });
                        }
                    }
                }
            }
            #endregion
        }

        private void Time_Tick(object obj) {
            //Exec(Url);

            //1.请求
            string content = "";
            Stream stream = http.RequestResult(Url, 5000);
            if (stream == null) return;
            //内容编码自动识别
            DetectedCharset(stream, out content, out encoding);

            List<string> currentUrl = ParseHtmlTextUrl(content);

            //2.cache url重复过滤
            currentUrl = ClearRepeatedElement(FirstCache, currentUrl);

            foreach (string u in currentUrl) {
                Exec(u);
            }
        }

        private void BindWords() {
            string getWord = "select * from Base_Word";
            string getEventWord = "select * from Base_EventWord";
            DataTable wordDt = new DataTable();
            DataTable evendWordDt = new DataTable();
            wordDt = Smart.DBUtility.SqlServerHelper.Query(getWord).Tables[0];
            evendWordDt = Smart.DBUtility.SqlServerHelper.Query(getEventWord).Tables[0];

            foreach (DataRow r in wordDt.Rows) {
                SmartPoms.Entity.BASE_WORD w = new SmartPoms.Entity.BASE_WORD();
                w.Enable = Convert.ToInt32(r["enable"].ToString());
                w.Score = Convert.ToDecimal(r["score"].ToString());
                w.WordID = Convert.ToInt32(r["wordid"].ToString());
                w.WordIDParent = Convert.ToInt32(r["wordidparent"].ToString());
                w.WordName = r["wordname"].ToString();
                this.word.Add(w);
            }

            foreach (DataRow r in evendWordDt.Rows) {
                SmartPoms.Entity.BASE_EVENTWORD ew = new SmartPoms.Entity.BASE_EVENTWORD();
                ew.EventID = Convert.ToInt32(r["eventid"].ToString());
                ew.EventWordID = Convert.ToInt32(r["eventwordid"].ToString());
                ew.WordID = Convert.ToInt32(r["wordid"].ToString());
                this.eventword.Add(ew);
            }
        }

        private void BindUrlRegex() {
            UrlRegx.Add(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*).html?");
            UrlRegx.Add(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*).shtml?");
            UrlRegx.Add(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*).aspx?");
            UrlRegx.Add(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*).dhtml?");
            //UrlRegx.Add(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*).htm");
            //UrlRegx.Add(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*).aspx");
            //UrlRegx.Add(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*).jsp");            
        }

        private void DetectedCharset(Stream stream, out string htmlText, out Encoding enc) {
            htmlText = "";
            enc = Encoding.Default;
            try {
                Stream mystream = stream;                
                if (stream == null) return;
                MemoryStream msTemp = new MemoryStream();
                int len = 0;
                byte[] buff = new byte[512];

                while ((len = mystream.Read(buff, 0, 512)) > 0) {
                    msTemp.Write(buff, 0, len);

                }

                if (msTemp.Length > 0) {
                    msTemp.Seek(0, SeekOrigin.Begin);
                    byte[] PageBytes = new byte[msTemp.Length];
                    msTemp.Read(PageBytes, 0, PageBytes.Length);

                    msTemp.Seek(0, SeekOrigin.Begin);
                    int DetLen = 0;
                    byte[] DetectBuff = new byte[4096];
                    CharsetListener listener = new CharsetListener();
                    UniversalDetector Det = new UniversalDetector(null);
                    while ((DetLen = msTemp.Read(DetectBuff, 0, DetectBuff.Length)) > 0 && !Det.IsDone()) {
                        Det.HandleData(DetectBuff, 0, DetectBuff.Length);
                    }
                    Det.DataEnd();
                    if (Det.GetDetectedCharset() != null) {
                        /*网页内容编码*/
                        enc = Encoding.GetEncoding(Det.GetDetectedCharset());
                        /*解码后的内容*/
                        htmlText = System.Text.Encoding.GetEncoding(Det.GetDetectedCharset()).GetString(PageBytes);
                    }
                }
            } catch { }
        }
    }

    public class CharsetListener : ICharsetListener {
        public string Charset;
        public void Report(string charset) {
            this.Charset = charset;
        }
    }
}
