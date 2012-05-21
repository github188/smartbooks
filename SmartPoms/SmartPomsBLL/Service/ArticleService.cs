
namespace SmartPoms.BLL.Service {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;

    public class ArticleService {
        public DataTable GetEventArticle(string beginDate, string endDate, string[] siteName, string[] keys, int sortType) {
            SqlParameter[] param = new SqlParameter[2];
            SqlParameter p0 = new SqlParameter();
            SqlParameter p1 = new SqlParameter();

            p0.ParameterName = "@begintime";
            p0.Value = beginDate;
            p0.SqlDbType = SqlDbType.DateTime;
            p0.Direction = ParameterDirection.Input;

            p1.ParameterName = "@endtime";
            p1.Value = endDate;
            p1.SqlDbType = SqlDbType.DateTime;
            p1.Direction = ParameterDirection.Input;

            param[0] = p0;
            param[1] = p1;

            /*构造Sql语句*/
            StringBuilder sql = new StringBuilder();
            sql.Append("select a.sendtime,a.title,a.media,a.author,a.clicknum,a.commentnum,a.sitename,a.url from Base_Article a ");
            sql.Append("where a.sendtime >= @begintime AND a.SendTime <= @endtime");
            /*构造网站名称条件*/
            string whereStr = string.Empty;
            for (int i = 0; i < siteName.Length; i++) {
                /*当前元素非空*/
                if (!string.IsNullOrEmpty(siteName[i])) {
                    /*当前元素非元素总数-1个*/
                    if (i <= siteName.Length - 2) {
                        whereStr += string.Format(" '{0}', ", siteName[i].ToString());
                    } else {
                        whereStr += string.Format(" '{0}' ", siteName[i].ToString());
                    }
                }
            }
            if (!string.IsNullOrEmpty(whereStr)) {
                sql.Append(string.Format(" AND a.sitename in ({0})", whereStr));
            }

            /*构造关键字条件*/
            for (int i = 0; i < keys.Length; i++) {
                /*当前元素非null*/
                if (!string.IsNullOrEmpty(keys[i])) {
                    /*文章标题包含关键字*/
                    sql.Append(string.Format(" AND a.title like ('%{0}%') ", keys[i].ToString()));
                    /*文章内容包含关键字*/
                    sql.Append(string.Format(" AND a.detail like ('%{0}%') ", keys[i].ToString()));
                }
            }

            sql.Append(" order by a.sendtime desc ");
            /*构造结果排序条件*/
            //switch (sortType) {
            //    case 0:
            //        /*点击数量降序*/
            //        sql.Append(" order by a.clicknum desc ");
            //        break;
            //    case 1:
            //        /*点击数量升序*/
            //        sql.Append(" order by a.clicknum ASC ");
            //        break;
            //    case 2:
            //        /*评论数量降序*/
            //        sql.Append(" order by a.commentnum desc ");
            //        break;
            //    case 3:
            //        /*评论数量升序*/
            //        sql.Append(" order by a.commentnum desc ");
            //        break;
            //    default:
            //        /*发布时间降序*/
            //        sql.Append(" order by a.sendtime desc ");
            //        break;
            //}
            /*获取数据集*/
            return Smart.DBUtility.SqlServerHelper.Query(sql.ToString(), param).Tables[0];
        }
    }
}