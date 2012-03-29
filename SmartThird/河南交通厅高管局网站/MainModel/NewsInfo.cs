using System;
using System.Collections.Generic;
using System.Text;

namespace MainModel
{
    /// <summary>
    /// 门户网站新闻信息实体类
    /// </summary>
    public  class NewsInfo
    {
        /// <summary>
        /// 新闻编号
        /// </summary>
        private int n_ID;

        public int N_ID
        {
            get { return n_ID; }
            set { n_ID = value; }
        }
        /// <summary>
        /// 新闻标题
        /// </summary>
        private string n_Title;

        public string N_Title
        {
            get { return n_Title; }
            set { n_Title = value; }
        }
        /// <summary>
        /// 新闻内容
        /// </summary>
        private string n_Content;

        public string N_Content
        {
            get { return n_Content; }
            set { n_Content = value; }
        }
        /// <summary>
        /// 新闻图片
        /// </summary>
        private string n_ImgPath;

        public string N_ImgPath
        {
            get { return n_ImgPath; }
            set { n_ImgPath = value; }
        }
        /// <summary>
        /// 新闻图片缩略图
        /// </summary>
        private string n_ImgView;

        public string N_ImgView
        {
            get { return n_ImgView; }
            set { n_ImgView = value; }
        }
        /// <summary>
        /// 新闻来源
        /// </summary>
        private string n_From;

        public string N_From
        {
            get { return n_From; }
            set { n_From = value; }
        }
        /// <summary>
        /// 发布日期
        /// </summary>
        private string n_Time;

        public string N_Time
        {
            get { return n_Time; }
            set { n_Time = value; }
        }
        /// <summary>
        /// 热点新闻图标
        /// </summary>
        private string n_HotIco;

        public string N_HotIco
        {
            get { return n_HotIco; }
            set { n_HotIco = value; }
        }
        /// <summary>
        /// 图片新闻图标
        /// </summary>
        private string n_PicIco;

        public string N_PicIco
        {
            get { return n_PicIco; }
            set { n_PicIco = value; }
        }   
        /// <summary>
        /// 点击率
        /// </summary>
        private int n_ClickCount;

        public int N_ClickCount
        {
            get { return n_ClickCount; }
            set { n_ClickCount = value; }
        }
        /// <summary>
        /// 新闻类型编号
        /// </summary>
        private int n_TID;

        public int N_TID
        {
            get { return n_TID; }
            set { n_TID = value; }
        }
    }
}
