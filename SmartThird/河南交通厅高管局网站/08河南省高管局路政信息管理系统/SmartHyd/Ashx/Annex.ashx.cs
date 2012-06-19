using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;

namespace SmartHyd.Ashx {
    /// <summary>
    /// Document 的摘要说明
    /// </summary>
    public class Annex : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "application/json";
            string result = "";
            try {
                if (context.Request.QueryString["id"] != null) {
                    string[] id = context.Request.QueryString["id"].Split(',');
                    for (int i = 0; i < id.Length; i++) {
                        Convert.ToDecimal(id[i].ToString());
                    }

                    BLL.BASE_ANNEX bll = new BLL.BASE_ANNEX();
                    DataTable dt = new DataTable();

                    string where = string.Format("id in({0})", context.Request.QueryString["id"]);
                    dt = bll.GetList(where);

                    result = JsonConvert.SerializeObject(dt);
                }
            }
            catch (Exception ex) {
                result = ex.Message;
            }
            finally {
                context.Response.Write(result);
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}