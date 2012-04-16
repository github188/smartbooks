using System;
using System.Collections.Generic;
using System.Text;

namespace StationModel
{
    /// <summary>
    /// 收费站信息数据实体类
    /// </summary>
    [Serializable]
  public  class TollStation
    {
        /// <summary>
        /// 收费站编号
        /// </summary>
        private int tS_ID;

        public int TS_ID
        {
            get { return tS_ID; }
            set { tS_ID = value; }
        }
        /// <summary>
        /// 收费站名称
        /// </summary>
        private string tS_Name;

        public string TS_Name
        {
            get { return tS_Name; }
            set { tS_Name = value; }
        }
        /// <summary>
        /// 收费站拼音
        /// </summary>
        private string tS_PinYin;

        public string TS_PinYin
        {
            get { return tS_PinYin; }
            set { tS_PinYin = value; }
        }
        /// <summary>
        /// 里程桩号
        /// </summary>
        private string tS_Stake;

        public string TS_Stake
        {
            get { return tS_Stake; }
            set { tS_Stake = value; }
        }
        /// <summary>
        /// 里程数
        /// </summary>
        private double tS_StakeNum;

        public double TS_StakeNum
        {
            get { return tS_StakeNum; }
            set { tS_StakeNum = value; }
        }
        /// <summary>
        /// 负责人
        /// </summary>
        private string tS_Manager;

        public string TS_Manager
        {
            get { return tS_Manager; }
            set { tS_Manager = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        private string tS_Phone;

        public string TS_Phone
        {
            get { return tS_Phone; }
            set { tS_Phone = value; }
        }
        /// <summary>
        /// 荣誉称号
        /// </summary>
        private string tS_Honour;

        public string TS_Honour
        {
            get { return tS_Honour; }
            set { tS_Honour = value; }
        }
        /// <summary>
        /// 评定星级
        /// </summary>
        private string tS_Star;

        public string TS_Star
        {
            get { return tS_Star; }
            set { tS_Star = value; }
        }
        /// <summary>
        /// 欢迎辞
        /// </summary>
        private string tS_Welcome;

        public string TS_Welcome
        {
            get { return tS_Welcome; }
            set { tS_Welcome = value; }
        }
        /// <summary>
        /// 高速公路对象
        /// </summary>
        private HighwayInfo tS_Highway;

        public HighwayInfo TS_Highway
        {
            get { return tS_Highway; }
            set { tS_Highway = value; }
        }
        /// <summary>
        /// 地市信息对象
        /// </summary>
        private CityInfo tS_City;

        public CityInfo TS_City
        {
            get { return tS_City; }
            set { tS_City = value; }
        }
        /// <summary>
        /// 管理公司对象
        /// </summary>
        private CompanyInfo tS_Company;

        public CompanyInfo TS_Company
        {
            get { return tS_Company; }
            set { tS_Company = value; }
        }
        /// <summary>
        /// 车道数
        /// </summary>
        private string tS_LaneNum;

        public string TS_LaneNum
        {
            get { return tS_LaneNum; }
            set { tS_LaneNum = value; }
        }
        /// <summary>
        /// 出口道路及城镇
        /// </summary>
        private string tS_ExitToRoad;

        public string TS_ExitToRoad
        {
            get { return tS_ExitToRoad; }
            set { tS_ExitToRoad = value; }
        }
        /// <summary>
        /// 收费站照片
        /// </summary>
        private string tS_MainPhoto;

        public string TS_MainPhoto
        {
            get { return tS_MainPhoto; }
            set { tS_MainPhoto = value; }
        }
        /// <summary>
        /// 收费站缩略图
        /// </summary>
        private string tS_ViewPhoto;

        public string TS_ViewPhoto
        {
            get { return tS_ViewPhoto; }
            set { tS_ViewPhoto = value; }
        }
        /// <summary>
        /// 收费站LoGo
        /// </summary>
        private string tS_Logo;

        public string TS_Logo
        {
            get { return tS_Logo; }
            set { tS_Logo = value; }
        }
        /// <summary>
        /// 收费站简介
        /// </summary>
        private string tS_Remark;

        public string TS_Remark
        {
            get { return tS_Remark; }
            set { tS_Remark = value; }
        }
    }
}
