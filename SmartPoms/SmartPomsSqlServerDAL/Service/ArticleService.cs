
namespace SmartPoms.SqlServerDAL.Service {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;

    public class ArticleService {

        public void Add(string title, string detail, DateTime stime, string media, string author, string clicknum, string commentnum, string url, DateTime extractiontime, string score, string sitename, string urlhansh) {
            string proc = "pro_addarticle";

            SqlParameter[] pam = new SqlParameter[]{
                new SqlParameter(),
                new SqlParameter(),
                new SqlParameter(),
                new SqlParameter(),
                new SqlParameter(),
                new SqlParameter(),
                new SqlParameter(),
                new SqlParameter(),
                new SqlParameter(),
                new SqlParameter(),
                new SqlParameter(),
                new SqlParameter(),
            };

            pam[0].ParameterName = "@title";
            pam[0].Value = title;
            pam[0].SqlDbType = SqlDbType.VarChar;
            pam[0].Direction = ParameterDirection.Input;

            pam[1].ParameterName = "@Detail";
            pam[1].Value = detail;
            pam[1].SqlDbType = SqlDbType.Text;
            pam[1].Direction = ParameterDirection.Input;

            pam[2].ParameterName = "@SendTime";
            pam[2].Value = stime;
            pam[2].SqlDbType = SqlDbType.DateTime;
            pam[2].Direction = ParameterDirection.Input;

            pam[3].ParameterName = "@Media";
            pam[3].Value = media;
            pam[3].SqlDbType = SqlDbType.VarChar;
            pam[3].Direction = ParameterDirection.Input;

            pam[4].ParameterName = "@Author";
            pam[4].Value = author;
            pam[4].SqlDbType = SqlDbType.VarChar;
            pam[4].Direction = ParameterDirection.Input;

            pam[5].ParameterName = "@ClickNum";
            pam[5].Value = Convert.ToInt32(clicknum);
            pam[5].SqlDbType = SqlDbType.Int;
            pam[5].Direction = ParameterDirection.Input;

            pam[6].ParameterName = "@CommentNum";
            pam[6].Value = Convert.ToInt32(commentnum);
            pam[6].SqlDbType = SqlDbType.Int;
            pam[6].Direction = ParameterDirection.Input;

            pam[7].ParameterName = "@Url";
            pam[7].Value = url;
            pam[7].SqlDbType = SqlDbType.VarChar;
            pam[7].Direction = ParameterDirection.Input;

            pam[8].ParameterName = "@ExtractionTime";
            pam[8].Value = extractiontime;
            pam[8].SqlDbType = SqlDbType.DateTime;
            pam[8].Direction = ParameterDirection.Input;

            pam[9].ParameterName = "@Score";
            pam[9].Value = Convert.ToDecimal(score);
            pam[9].SqlDbType = SqlDbType.Float;
            pam[9].Direction = ParameterDirection.Input;

            pam[10].ParameterName = "@SiteName";
            pam[10].Value = sitename;
            pam[10].SqlDbType = SqlDbType.VarChar;
            pam[10].Direction = ParameterDirection.Input;

            pam[11].ParameterName = "@UrlHash";
            pam[11].Value = urlhansh;
            pam[11].SqlDbType = SqlDbType.VarChar;
            pam[11].Direction = ParameterDirection.Input;

            Smart.DBUtility.SqlServerHelper.RunProcedure(proc, pam);
        }
    }
}
