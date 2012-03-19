using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace Smart.Spider.Client
{
    public class TaskUnit
    {
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

        public TaskUnit(string url)
        {
            http = new HttpHelper();
            Time = new System.Windows.Forms.Timer();
            UrlRegx = new List<string>();
            Url = url;
            FirstCache = new List<string>();

            Time.Tick +=new EventHandler(Time_Tick);
            Time.Interval = 1000 * 60 * 10; //10分钟
        }

        public List<string> ParseHtmlTextUrl(string htmlText)
        {
            List<string> url = new List<string>();

            foreach (string reg in UrlRegx)
            {
                MatchCollection coll = Regex.Matches(htmlText, reg);
                foreach (Match match in coll)
                {
                    url.Add(match.Value);
                }
            }

            return url;
        }

        public List<string> ClearRepeatedElement(List<string> cache, List<string> current)
        {
            List<string> newsUrl = new List<string>();
            foreach (string u in current)
            {
                if (!cache.Contains(u))
                {
                    newsUrl.Add(u);
                }
            }
            return newsUrl;
        }

        public void ParseContent(string htmlText)
        {
            
        }

        public void Exec(object url)
        {
            //3.抓取下一层url
            string u = (string)url;
            string content = http.RequestResult(u);

            //4.纯汉字
            content = Regex.Match(content, "").Value;

            //5.自动分类
            List<SmartPoms.Entity.BASE_WORD> c = new List<SmartPoms.Entity.BASE_WORD>();
            foreach (SmartPoms.Entity.BASE_WORD w in word)
            {
                if (content.Contains(w.WordName))
                {
                    c.Add(w);
                }
            }
            List<int> eventId = new List<int>();    //文章所属分类ID
            foreach (SmartPoms.Entity.BASE_EVENTWORD e in eventword)
            {
                foreach (SmartPoms.Entity.BASE_WORD w in c)
                {
                    if (e.WordID == w.WordID)
                    {
                        eventId.Add(e.EventID);
                    }
                }
            }

            //6.Add to db(截取标题 摘要加入数据库)
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            //1.请求
            string content = http.RequestResult(Url);

            List<string> currentUrl = ParseHtmlTextUrl(content);

            //2.cache url重复过滤
            currentUrl = ClearRepeatedElement(FirstCache, currentUrl);

            foreach(string u in currentUrl)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Exec), u);
            }
        }
    }
}
