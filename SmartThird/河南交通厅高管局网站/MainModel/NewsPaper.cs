using System;
using System.Collections.Generic;
using System.Text;

namespace MainModel
{
    /// <summary>
    /// 服务区行业报刊实体类
    /// </summary>
  [ Serializable]
  public  class NewsPaper
    {
      /// <summary>
      /// 编号
      /// </summary>
        private int n_ID;

        public int N_ID
        {
            get { return n_ID; }
            set { n_ID = value; }
        }
      /// <summary>
      /// 标题
      /// </summary>
        private string n_Title;

        public string N_Title
        {
            get { return n_Title; }
            set { n_Title = value; }
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
      /// 第一版图片
      /// </summary>
        private string n_AImg;

        public string N_AImg
        {
            get { return n_AImg; }
            set { n_AImg = value; }
        }
      /// <summary>
      /// 第一版图片缩略图
      /// </summary>
        private string n_AImgView;

        public string N_AImgView
        {
            get { return n_AImgView; }
            set { n_AImgView = value; }
        }
      /// <summary>
      /// 第二版图片
      /// </summary>
        private string n_BImg;

        public string N_BImg
        {
            get { return n_BImg; }
            set { n_BImg = value; }
        }
      /// <summary>
      /// 第二版图片缩略图
      /// </summary>
        private string n_BImgView;

        public string N_BImgView
        {
            get { return n_BImgView; }
            set { n_BImgView = value; }
        }
      /// <summary>
      /// 第三版图片
      /// </summary>
        private string n_CImg;

        public string N_CImg
        {
            get { return n_CImg; }
            set { n_CImg = value; }
        }
      /// <summary>
      /// 第三版图片缩略图
      /// </summary>
        private string n_CImgView;

        public string N_CImgView
        {
            get { return n_CImgView; }
            set { n_CImgView = value; }
        }
      /// <summary>
      /// 第四版图片
      /// </summary>
        private string n_DImg;

        public string N_DImg
        {
            get { return n_DImg; }
            set { n_DImg = value; }
        }
      /// <summary>
      /// 第四版图片缩略图
      /// </summary>
        private string n_DImgView;

        public string N_DImgView
        {
            get { return n_DImgView; }
            set { n_DImgView = value; }
        }
    }
}
