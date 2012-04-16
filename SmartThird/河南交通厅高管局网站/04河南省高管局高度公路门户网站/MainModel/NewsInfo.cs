using System;
using System.Collections.Generic;
using System.Text;

namespace MainModel
{
    /// <summary>
    /// �Ż���վ������Ϣʵ����
    /// </summary>
    public  class NewsInfo
    {
        /// <summary>
        /// ���ű��
        /// </summary>
        private int n_ID;

        public int N_ID
        {
            get { return n_ID; }
            set { n_ID = value; }
        }
        /// <summary>
        /// ���ű���
        /// </summary>
        private string n_Title;

        public string N_Title
        {
            get { return n_Title; }
            set { n_Title = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        private string n_Content;

        public string N_Content
        {
            get { return n_Content; }
            set { n_Content = value; }
        }
        /// <summary>
        /// ����ͼƬ
        /// </summary>
        private string n_ImgPath;

        public string N_ImgPath
        {
            get { return n_ImgPath; }
            set { n_ImgPath = value; }
        }
        /// <summary>
        /// ����ͼƬ����ͼ
        /// </summary>
        private string n_ImgView;

        public string N_ImgView
        {
            get { return n_ImgView; }
            set { n_ImgView = value; }
        }
        /// <summary>
        /// ������Դ
        /// </summary>
        private string n_From;

        public string N_From
        {
            get { return n_From; }
            set { n_From = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        private string n_Time;

        public string N_Time
        {
            get { return n_Time; }
            set { n_Time = value; }
        }
        /// <summary>
        /// �ȵ�����ͼ��
        /// </summary>
        private string n_HotIco;

        public string N_HotIco
        {
            get { return n_HotIco; }
            set { n_HotIco = value; }
        }
        /// <summary>
        /// ͼƬ����ͼ��
        /// </summary>
        private string n_PicIco;

        public string N_PicIco
        {
            get { return n_PicIco; }
            set { n_PicIco = value; }
        }   
        /// <summary>
        /// �����
        /// </summary>
        private int n_ClickCount;

        public int N_ClickCount
        {
            get { return n_ClickCount; }
            set { n_ClickCount = value; }
        }
        /// <summary>
        /// �������ͱ��
        /// </summary>
        private int n_TID;

        public int N_TID
        {
            get { return n_TID; }
            set { n_TID = value; }
        }
    }
}
