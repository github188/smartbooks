
namespace SmartPoms.AppFacade {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SmartPoms.ServiceInterfaces;
    using System.Data;
    using System.Data.SqlClient;
    using SmartPoms;

    public class ArticleService : IArticleService {
        public DataTable GetEventArticle(string beginDate, string endDate, int eventId) {
            string procName = "pro_geteventarticle";
            SqlParameter[] param = new SqlParameter[4];
            SqlParameter p0 = new SqlParameter();
            SqlParameter p1 = new SqlParameter();
            SqlParameter p2 = new SqlParameter();
            SqlParameter p3 = new SqlParameter();

            p0.ParameterName = "@begintime";
            p0.Value = beginDate;
            p0.Direction = ParameterDirection.Input;

            p1.ParameterName = "@endtime";
            p1.Value = endDate;
            p1.Direction = ParameterDirection.Input;

            p2.ParameterName = "@eventid";
            p2.Value = eventId;
            p2.Direction = ParameterDirection.Input;

            p3.ParameterName = "@out_cursor";
            p3.Direction = ParameterDirection.Output;

            param[0] = p0;
            param[1] = p1;
            param[2] = p2;
            param[3] = p3;

            return Smart.DBUtility.SqlServerHelper.RunProcedure(procName, param, "a").Tables["a"];
        }

        public string Description {
            get { return "提供文章服务"; }
        }
    }
}
