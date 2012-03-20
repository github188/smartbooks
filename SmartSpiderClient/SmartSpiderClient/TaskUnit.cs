using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data;

namespace Smart.Spider.Client {
    public class TaskUnit {
        #region 公共字段
        public HttpHelper http;
        public System.Windows.Forms.Timer Time;
        public List<string> UrlRegx;
        public List<string> FirstCache;
        public string Url;
        public string ConnectionString;
        #endregion

        List<SmartPoms.Entity.BASE_WORD> word = new List<SmartPoms.Entity.BASE_WORD>();
        List<SmartPoms.Entity.BASE_EVENTWORD> eventword = new List<SmartPoms.Entity.BASE_EVENTWORD>();

        public TaskUnit(string url) {
            http = new HttpHelper();
            Time = new System.Windows.Forms.Timer();
            UrlRegx = new List<string>();
            Url = url;
            FirstCache = new List<string>();

            Time.Tick += new EventHandler(Time_Tick);
            Time.Interval = 1000 * 10; //10分钟

            BindWords();
            Time.Start();
        }

        public List<string> ParseHtmlTextUrl(string htmlText) {
            List<string> url = new List<string>();

            foreach (string reg in UrlRegx) {
                MatchCollection coll = Regex.Matches(htmlText, reg);
                foreach (Match match in coll) {
                    url.Add(match.Value);
                }
            }

            return url;
        }

        public List<string> ClearRepeatedElement(List<string> cache, List<string> current) {
            List<string> newsUrl = new List<string>();
            foreach (string u in current) {
                if (!cache.Contains(u)) {
                    newsUrl.Add(u);
                }
            }
            return newsUrl;
        }
        
        public void Exec(object url) {
            //3.抓取下一层url
            string u = (string)url;
            string content = http.RequestResult(u);
            string title = "";

            //4.纯汉字
            content = string.Empty;
            MatchCollection coll = Regex.Matches(content, @"[\u4E00-\u9FA5]");
            foreach (Match m in coll) {
                content += m.Value;
            }

            //5.自动分类
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

            //6.Add to db(截取标题 摘要,加入数据库)
            if (content.Length > 80) {
                title = content.Substring(0, 80);
            } else {
                title = content;
            }
            if (content.Length > 8000) {
                content = content.Substring(0, 7999);
            }

            SmartPoms.SQLServerDAL.BASE_ARTICLE art = new SmartPoms.SQLServerDAL.BASE_ARTICLE();
            art.Add(new SmartPoms.Entity.BASE_ARTICLE() {
                Title = title,
                Detail = content,
                Url = this.http.WebRequest.RequestUri.AbsoluteUri
            });
            string sec = string.Format("SELECT top 1 articleid from base_article where Title='{0}'", title);
            DataTable dt = Smart.DBUtility.SqlServerHelper.Query(sec).Tables[0];
            if (dt != null && dt.Rows.Count != 0) {
                int maxid = Convert.ToInt32(dt.Rows[0][0].ToString());
                SmartPoms.SQLServerDAL.BASE_EVENTARTICLE eventArticle = new SmartPoms.SQLServerDAL.BASE_EVENTARTICLE();
                foreach (int e in eventId) {
                    eventArticle.Add(new SmartPoms.Entity.BASE_EVENTARTICLE() {
                        ArticleID = maxid,
                        EventID = e
                    });
                }
            }
        }

        private void Time_Tick(object sender, EventArgs e) {
            //1.请求
            string content = http.RequestResult(Url);

            List<string> currentUrl = ParseHtmlTextUrl(content);

            //2.cache url重复过滤
            currentUrl = ClearRepeatedElement(FirstCache, currentUrl);

            foreach (string u in currentUrl) {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Exec), u);
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
    }
}
