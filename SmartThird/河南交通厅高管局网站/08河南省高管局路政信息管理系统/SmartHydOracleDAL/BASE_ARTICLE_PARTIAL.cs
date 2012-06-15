// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE.cs
// 功能描述:公文信息表 -- 接口实现
//
// 创建标识：王 亚 2012-05-18

namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using System.Data.OracleClient;
    using IDAL;
    
    /// <summary>
    /// 为不影响代码生成的文件类(代码生成的类单独存放一个文件)，用分部类实现类隔离。
    /// </summary>
    public partial class BASE_ARTICLE {
        /// <summary>
        /// 获取发文的回复列表
        /// </summary>
        /// <param name="sendId">发文编号</param>
        /// <returns>回复列表</returns>
        public DataTable GetReplyList(int sendId) {
            string procName = "PKG_ARTICLE_QUERY.proc_getreplylist";
            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter();
            param[1] = new OracleParameter();

            param[0].Direction = ParameterDirection.Input;
            param[0].OracleType = OracleType.Number;
            param[0].ParameterName = "sendid";
            param[0].Value = sendId;

            param[1].Direction = ParameterDirection.Output;
            param[1].OracleType = OracleType.Cursor;
            param[1].ParameterName = "out_cursor";

            return OracleHelper.RunProcedure(procName, param).Tables[0];
        }
        /// <summary>
        /// 获取公文详情
        /// </summary>
        /// <param name="id">公文编号</param>
        /// <returns></returns>
        public DataTable GetDetail(int id) {

            string procName = "PKG_ARTICLE_QUERY.proc_getdetail";
            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter();
            param[1] = new OracleParameter();

            param[0].Direction = ParameterDirection.Input;
            param[0].OracleType = OracleType.Number;
            param[0].ParameterName = "sendid";
            param[0].Value = id;

            param[1].Direction = ParameterDirection.Output;
            param[1].OracleType = OracleType.Cursor;
            param[1].ParameterName = "out_cursor";

            return OracleHelper.RunProcedure(procName, param).Tables[0];
        }
        /// <summary>
        /// 根据部门、分类获取公文列表（发文）
        /// </summary>
        /// <param name="depCode">部门编号</param>
        /// <param name="typeCode">分类编号</param>
        /// <returns>公文列表</returns>
        public DataTable GetPublishList(int depCode, int typeCode) {
            string procName = "PKG_ARTICLE_QUERY.proc_getpublishlist";
            OracleParameter[] param = new OracleParameter[3];

            param[0] = new OracleParameter();
            param[1] = new OracleParameter();
            param[2] = new OracleParameter();

            param[0].Direction = ParameterDirection.Input;
            param[0].OracleType = OracleType.Number;
            param[0].ParameterName = "dptcode";
            param[0].Value = depCode;

            param[1].Direction = ParameterDirection.Input;
            param[1].OracleType = OracleType.Number;
            param[1].ParameterName = "typecode";
            param[1].Value = typeCode;

            param[2].Direction = ParameterDirection.Output;
            param[2].OracleType = OracleType.Cursor;
            param[2].ParameterName = "out_cursor";

            return OracleHelper.RunProcedure(procName, param).Tables[0];
        }
        /// <summary>
        /// 获取我的收文数据
        /// </summary>
        /// <param name="depCode">部门编号</param>
        /// <returns>我的收文数据</returns>
        public DataTable GetAcceptList(int depCode) {
            string procName = "PKG_ARTICLE_QUERY.proc_getacceptlist";
            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter();
            param[1] = new OracleParameter();

            param[0].Direction = ParameterDirection.Input;
            param[0].OracleType = OracleType.Number;
            param[0].ParameterName = "dptnum";
            param[0].Value = depCode;

            param[1].Direction = ParameterDirection.Output;
            param[1].OracleType = OracleType.Cursor;
            param[1].ParameterName = "out_cursor";

            return OracleHelper.RunProcedure(procName, param).Tables[0];
        }

        /// <summary>
        /// checkout operation
        /// </summary>
        /// <param name="dictionary">key=id,value=score</param>
        public void CheckOut(Dictionary<int, int> dictionary) {
            //cycle update this is reply article.
            foreach (KeyValuePair<int, int> entry in dictionary) {
                //build sql update command statement.
                string update = string.Format("update base_article set score={0},status=5 where id={1}",
                    entry.Value.ToString(), entry.Key.ToString());

                //update to database.
                OracleHelper.ExecuteNonQuery(update);
            }
        }
        /// <summary>
        /// update this is aricle state.
        /// </summary>
        /// <param name="state">0已审核，1未审核，2草稿，3已删除，4隐藏，5结贴</param>
        /// <param name="id">primary id</param>
        public void UpdateState(int state, int id) {
            string update = string.Format("update base_article set status={0} where id={1}",
                state, id);
            OracleHelper.ExecuteNonQuery(update);
        }

        /// <summary>
        ///更新公文分数
        /// </summary>
        /// <param name="id">公文编号</param>
        /// <param name="score">分值</param>
        public bool UpdateSocre(int id, int score) {
            string update = string.Format("update base_article set SCORE={0} where id={1}",
                score, id);
            if (OracleHelper.ExecuteNonQuery(update) < 0) {
                return false;
            }
            return true;
        }
    }
}
