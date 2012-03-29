using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 服务区信息
    /// </summary>
  [Serializable]
  public  class ServiceInfo
    {
      /// <summary>
      /// 服务区编号
      /// </summary>
        private int s_ID;

        public int S_ID
        {
            get { return s_ID; }
            set { s_ID = value; }
        }
      /// <summary>
      /// 服务区名称
      /// </summary>
        private string s_Name;

        public string S_Name
        {
            get { return s_Name; }
            set { s_Name = value; }
        }
      /// <summary>
      /// 服务区星级
      /// </summary>
        private string s_Star;

        public string S_Star
        {
            get { return s_Star; }
            set { s_Star = value; }
        }
      /// <summary>
      /// 服务区类型(服务区、停车区)
      /// </summary>
        private string s_Type;

        public string S_Type
        {
            get { return s_Type; }
            set { s_Type = value; }
        }
      /// <summary>
      /// 所属高速公路
      /// </summary>
        private int s_HID;

        public int S_HID
        {
            get { return s_HID; }
            set { s_HID = value; }
        }
      /// <summary>
      /// 里程桩号
      /// </summary>
        private string s_Stake;

        public string S_Stake
        {
            get { return s_Stake; }
            set { s_Stake = value; }
        }
      /// <summary>
      /// 里程数
      /// </summary>
        private double s_StakeNum;

        public double S_StakeNum
        {
            get { return s_StakeNum; }
            set { s_StakeNum = value; }
        }
      /// <summary>
      /// 服务项目
      /// </summary>
        private string s_Service;

        public string S_Service
        {
            get { return s_Service; }
            set { s_Service = value; }
        }
      /// <summary>
      /// 联系电话
      /// </summary>
        private string s_Phone;

        public string S_Phone
        {
            get { return s_Phone; }
            set { s_Phone = value; }
        }
      /// <summary>
      /// 服务区简介
      /// </summary>
        private string s_Remark;

        public string S_Remark
        {
            get { return s_Remark; }
            set { s_Remark = value; }
        }
      /// <summary>
      /// 服务区图片
      /// </summary>
        private string s_Image;

        public string S_Image
        {
            get { return s_Image; }
            set { s_Image = value; }
        }
      /// <summary>
      /// 餐饮简介
      /// </summary>
        private string s_CYRemark;

        public string S_CYRemark
        {
            get { return s_CYRemark; }
            set { s_CYRemark = value; }
        }
      /// <summary>
      /// 餐饮图片
      /// </summary>
        private string s_CYImage;

        public string S_CYImage
        {
            get { return s_CYImage; }
            set { s_CYImage = value; }
        }
      /// <summary>
      /// 超市简介
      /// </summary>
        private string s_CSRemark;

        public string S_CSRemark
        {
            get { return s_CSRemark; }
            set { s_CSRemark = value; }
        }
      /// <summary>
      /// 超市图片
      /// </summary>
        private string s_CSImage;

        public string S_CSImage
        {
            get { return s_CSImage; }
            set { s_CSImage = value; }
        }
      /// <summary>
      /// 加油站简介
      /// </summary>
        private string s_JYZRemark;

        public string S_JYZRemark
        {
            get { return s_JYZRemark; }
            set { s_JYZRemark = value; }
        }
      /// <summary>
      /// 加油站图片
      /// </summary>
        private string s_JYZImage;

        public string S_JYZImage
        {
            get { return s_JYZImage; }
            set { s_JYZImage = value; }
        }
      /// <summary>
      /// 住宿简介
      /// </summary>
        private string s_ZSRemark;

        public string S_ZSRemark
        {
            get { return s_ZSRemark; }
            set { s_ZSRemark = value; }
        }
      /// <summary>
      /// 住宿图片
      /// </summary>
        private string s_ZSImage;

        public string S_ZSImage
        {
            get { return s_ZSImage; }
            set { s_ZSImage = value; }
        }
      /// <summary>
      /// 汽修简介
      /// </summary>
        private string s_QXRemark;

        public string S_QXRemark
        {
            get { return s_QXRemark; }
            set { s_QXRemark = value; }
        }
      /// <summary>
      /// 汽修图片
      /// </summary>
        private string s_QXImage;

        public string S_QXImage
        {
            get { return s_QXImage; }
            set { s_QXImage = value; }
        }
      /// <summary>
      /// 停车场简介
      /// </summary>
        private string s_TCSRemark;

        public string S_TCSRemark
        {
            get { return s_TCSRemark; }
            set { s_TCSRemark = value; }
        }
      /// <summary>
      /// 停车场图片
      /// </summary>
        private string s_TCSImage;

        public string S_TCSImage
        {
            get { return s_TCSImage; }
            set { s_TCSImage = value; }
        }
      /// <summary>
      /// 卫生间备注
      /// </summary>
        private string s_WSJRemark;

        public string S_WSJRemark
        {
            get { return s_WSJRemark; }
            set { s_WSJRemark = value; }
        }
      /// <summary>
      /// 卫生间图片
      /// </summary>
        private string s_WSJImage;

        public string S_WSJImage
        {
            get { return s_WSJImage; }
            set { s_WSJImage = value; }
        }
      /// <summary>
      /// 服务队伍备注
      /// </summary>
        private string s_FWDWRemark;

        public string S_FWDWRemark
        {
            get { return s_FWDWRemark; }
            set { s_FWDWRemark = value; }
        }
      /// <summary>
      /// 服务队伍图片
      /// </summary>
        private string s_FWDWImage;

        public string S_FWDWImage
        {
            get { return s_FWDWImage; }
            set { s_FWDWImage = value; }
        }
     /// <summary>
     /// 季度排名
     /// </summary>
        private int s_QuarterRank;

        public int S_QuarterRank
        {
            get { return s_QuarterRank; }
            set { s_QuarterRank = value; }
        }
      /// <summary>
      /// 服务区网站主页头部图片
      /// </summary>
        private string s_HeaderImg;

        public string S_HeaderImg
        {
            get { return s_HeaderImg; }
            set { s_HeaderImg = value; }
        }
      /// <summary>
      /// 所属地市
      /// </summary>
      private string s_City;

      public string S_City
      {
          get { return s_City; }
          set { s_City = value; }
      }
      /// <summary>
      /// 服务区欢迎词
      /// </summary>
      private string s_Welcome;

      public string S_Welcome
      {
          get { return s_Welcome; }
          set { s_Welcome = value; }
      }
    }
}
