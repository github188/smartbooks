using System;
using System.Collections.Generic;
using System.Text;
using StationModel;

namespace RoadEntity
{
    /// <summary>
    /// 路政单位信息实体类
    /// </summary>
    [Serializable]
    public class RoadDepart
    {
        /// <summary>
        /// 单位编号
        /// </summary>
        private int rD_ID;

        public int RD_ID
        {
            get { return rD_ID; }
            set { rD_ID = value; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        private string rD_Name;

        public string RD_Name
        {
            get { return rD_Name; }
            set { rD_Name = value; }
        }
        /// <summary>
        /// 单位负责人
        /// </summary>
        private string rD_Manager;

        public string RD_Manager
        {
            get { return rD_Manager; }
            set { rD_Manager = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        private string rD_Phone;

        public string RD_Phone
        {
            get { return rD_Phone; }
            set { rD_Phone = value; }
        }
        /// <summary>
        /// 单位传真
        /// </summary>
        private string rD_Fax;

        public string RD_Fax
        {
            get { return rD_Fax; }
            set { rD_Fax = value; }
        }
        /// <summary>
        /// 电子邮件
        /// </summary>
        private string rD_Email;

        public string RD_Email
        {
            get { return rD_Email; }
            set { rD_Email = value; }
        }


        /// <summary>
        /// 邮政编码
        /// </summary>
        private string rD_PostCode;

        public string RD_PostCode
        {
            get { return rD_PostCode; }
            set { rD_PostCode = value; }
        }


        /// <summary>
        /// 单位QQ
        /// </summary>
        private string rD_QQ;

        public string RD_QQ
        {
            get { return rD_QQ; }
            set { rD_QQ = value; }
        }
        /// <summary>
        /// 所属地市信息实体类对象
        /// </summary>
        private CityInfo rD_City;

        public CityInfo RD_City
        {
            get { return rD_City; }
            set { rD_City = value; }
        }
        /// <summary>
        /// 单位地址
        /// </summary>
        private string rD_Address;

        public string RD_Address
        {
            get { return rD_Address; }
            set { rD_Address = value; }
        }
        /// <summary>
        /// 荣誉称号
        /// </summary>
        private string rD_Honour;

        public string RD_Honour
        {
            get { return rD_Honour; }
            set { rD_Honour = value; }
        }
        /// <summary>
        /// 宣传标语、口号
        /// </summary>
        private string rD_Slogon;

        public string RD_Slogon
        {
            get { return rD_Slogon; }
            set { rD_Slogon = value; }
        }
        /// <summary>
        /// 单位简介
        /// </summary>
        private string rD_Remark;

        public string RD_Remark
        {
            get { return rD_Remark; }
            set { rD_Remark = value; }
        }
        /// <summary>
        /// 路政单位照片大图
        /// </summary>
        private string rD_MainPhoto;

        public string RD_MainPhoto
        {
            get { return rD_MainPhoto; }
            set { rD_MainPhoto = value; }
        }
        /// <summary>
        /// 路政单位照片缩略图
        /// </summary>
        private string rD_ViewPhoto;

        public string RD_ViewPhoto
        {
            get { return rD_ViewPhoto; }
            set { rD_ViewPhoto = value; }
        }
        /// <summary>
        /// 单位网站头部Logo
        /// </summary>
        private string rD_Logo;

        public string RD_Logo
        {
            get { return rD_Logo; }
            set { rD_Logo = value; }
        }
        /// <summary>
        /// 举报电话
        /// </summary>
        private string rD_Report;

        public string RD_Report
        {
            get { return rD_Report; }
            set { rD_Report = value; }
        }
    }
}
