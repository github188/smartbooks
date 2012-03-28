using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartPoms.Api {
    /// <summary>
    /// AddArticle 的摘要说明
    /// </summary>
    public class AddArticle : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;
            try {
                #region 获取post请求参数
                /*获取参数 POST请求方式*/
                string title = context.Request.Form["title"];
                string detail = context.Request.Form["detail"];
                string stime = context.Request.Form["stime"];
                string media = context.Request.Form["media"];
                string author = context.Request.Form["author"];
                string clicknum = context.Request.Form["clicknum"];
                string commentnum = context.Request.Form["commentnum"];
                string url = context.Request.Form["url"];
                string extractiontime = context.Request.Form["extractiontime"];
                string score = context.Request.Form["score"];
                string sitename = context.Request.Form["sitename"];
                string urlhash = context.Request.Form["urlhash"];
                #endregion

                #region 校验参数
                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(detail) || string.IsNullOrEmpty(media) ||
                    string.IsNullOrEmpty(url) || string.IsNullOrEmpty(sitename)) {
                        throw new Exception("参数不合法");
                }
                stime = string.IsNullOrEmpty(stime) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : stime;
                extractiontime = string.IsNullOrEmpty(extractiontime) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : extractiontime;
                clicknum = string.IsNullOrEmpty(clicknum) ? "0" : clicknum;
                score = string.IsNullOrEmpty(score) ? "0" : score;
                commentnum = string.IsNullOrEmpty(commentnum) ? "0" : commentnum;
                urlhash = string.IsNullOrEmpty(urlhash) ? Smart.Security.MD5.MD5Encrypt(url) : urlhash;
                #endregion

                SmartPoms.SqlServerDAL.Service.ArticleService article = new SqlServerDAL.Service.ArticleService();
                    article.Add(title, detail, DateTime.Parse(stime), media, author,
                        clicknum, commentnum, url, DateTime.Parse(extractiontime), score, sitename, urlhash);
                result = "ok";
            } catch (Exception ex) {
                result = ex.Message;
            }
            context.Response.Write(result);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}