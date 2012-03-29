using System;
using System.Collections.Generic;
using System.Text;
using PubClass;
using System.Data;

namespace RoadService
{
    /// <summary>
    /// 路政单位文章信息数据访问类
    /// </summary>
  public  class NewsInfoService
    {
        /// <summary>
        /// 获得文章视图信息列表
        /// </summary>
        public static DataTable Get_NewsViewList(int RD_ID, int T_ID, int listSize)
        {
            string sqlStr = "";
            if (listSize == 0)
            {
                sqlStr = "select * from R_NewsView where N_RDID='" + RD_ID + "' and T_ID='" + T_ID + "' order by N_Date desc,N_ID desc";
            }
            else
            {
                sqlStr = "select top " + listSize + " * from R_NewsView where N_RDID='" + RD_ID + "' and T_ID='" + T_ID + "' order by N_Date desc,N_ID desc";
            }
            return DBHelper.GetDataSet(sqlStr);
        }
        /// <summary>
        /// 获得文章视图信息
        /// </summary>
        /// <param name="N_ID"></param>
        /// <returns></returns>
        public static DataTable Get_NewsView(int N_ID)
        {
            string sqlStr = "select * from R_NewsView where N_ID='" + N_ID + "'";
            return DBHelper.GetDataSet(sqlStr);
        }
        /// <summary>
        /// 获得最新头若干条图片新闻视图信息
        /// </summary>
        public static DataTable Get_TopAnyImgNewsViewList(int RD_ID, int T_ID,int listSize)
        {
            string sqlStr = "select top "+listSize+" * from R_NewsView where N_RDID='" + RD_ID + "' and T_ID='" + T_ID + "' and N_ImgPath is not null and N_ImgPath<>'' and N_ImgView is not null and N_ImgView<>'' order by N_Date desc,N_ID desc";
            return DBHelper.GetDataSet(sqlStr);
        }
    }
}
