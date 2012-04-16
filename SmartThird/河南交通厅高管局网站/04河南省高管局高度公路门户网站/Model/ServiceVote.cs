using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 服务区在线调查信息
    /// </summary>
   public class ServiceVote
    {
       /// <summary>
       /// 投票编号
       /// </summary>
        private int sV_ID;

        public int SV_ID
        {
            get { return sV_ID; }
            set { sV_ID = value; }
        }
       /// <summary>
       /// 服务区编号
       /// </summary>
       private int sV_SID;

       public int SV_SID
       {
           get { return sV_SID; }
           set { sV_SID = value; }
       }
       /// <summary>
       /// 综合评价
       /// </summary>
       private string sV_ZH;

        public string SV_ZH
        {
          get { return sV_ZH; }
          set { sV_ZH = value; }
        }

       /// <summary>
       /// 公益服务
       /// </summary>
        private string sV_GY;

        public string SV_GY
        {
            get { return sV_GY; }
            set { sV_GY = value; }
        }
       /// <summary>
       /// 收费标准
       /// </summary>
        private string sV_SF;

        public string SV_SF
        {
            get { return sV_SF; }
            set { sV_SF = value; }
        }
       /// <summary>
       /// 环境卫生
       /// </summary>
        private string sV_HJ;

        public string SV_HJ
        {
            get { return sV_HJ; }
            set { sV_HJ = value; }
        }
       /// <summary>
       /// 停车场
       /// </summary>
        private string sV_TC;

        public string SV_TC
        {
            get { return sV_TC; }
            set { sV_TC = value; }
        }
       /// <summary>
       /// 管理情况
       /// </summary>
        private string sV_GL;

        public string SV_GL
        {
            get { return sV_GL; }
            set { sV_GL = value; }
        }
       /// <summary>
       /// 夜间是否得到有效服务
       /// </summary>
        private string sV_YJ;

        public string SV_YJ
        {
            get { return sV_YJ; }
            set { sV_YJ = value; }
        }
       /// <summary>
       /// 治安情况
       /// </summary>
        private string sV_ZA;

        public string SV_ZA
        {
            get { return sV_ZA; }
            set { sV_ZA = value; }
        }
       /// <summary>
       /// 硬件设施
       /// </summary>
        private string sV_SS;

        public string SV_SS
        {
            get { return sV_SS; }
            set { sV_SS = value; }
        }
       /// <summary>
       ///公厕设施
       /// </summary>
        private string sV_GC;

        public string SV_GC
        {
            get { return sV_GC; }
            set { sV_GC = value; }
        }
       /// <summary>
       /// 超市
       /// </summary>
        private string sV_CS;

        public string SV_CS
        {
            get { return sV_CS; }
            set { sV_CS = value; }
        }
       /// <summary>
       /// 餐饮
       /// </summary>
        private string sV_CY;

        public string SV_CY
        {
            get { return sV_CY; }
            set { sV_CY = value; }
        }
       /// <summary>
       /// 客房
       /// </summary>
        private string sV_KF;

        public string SV_KF
        {
            get { return sV_KF; }
            set { sV_KF = value; }
        }
       /// <summary>
       /// 加油
       /// </summary>
        private string sV_JY;

        public string SV_JY
        {
            get { return sV_JY; }
            set { sV_JY = value; }
        }
       /// <summary>
       /// 汽修
       /// </summary>
        private string sV_QX;

        public string SV_QX
        {
            get { return sV_QX; }
            set { sV_QX = value; }
        }
       /// <summary>
       /// 意见建议
       /// </summary>
        private string sV_Remark;

        public string SV_Remark
        {
            get { return sV_Remark; }
            set { sV_Remark = value; }
        }
       /// <summary>
       /// 提交时间
       /// </summary>
        private string sV_Time;

        public string SV_Time
        {
            get { return sV_Time; }
            set { sV_Time = value; }
        }

    }
}
