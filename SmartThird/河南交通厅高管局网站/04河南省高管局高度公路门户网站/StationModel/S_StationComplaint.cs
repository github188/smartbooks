using System;
using System.Collections.Generic;
using System.Text;

namespace StationModel
{
    public class S_StationComplaint
    {
        private int sC_ID;//投诉编号
        private string sC_CptName;//投诉人
        private string sC_CptContent;//投诉内容
        private string sC_Phone;//电话
        private string sC_Address;//地址
        private string sC_Reply;//投诉回复
        private bool sC_Open;//是否发布
        private int sC_TSID;//收费站编号
        private string sC_CreateTime;//投诉时间
        private string sC_ReplyTime;//回复时间

        public int SC_ID
        {
            get { return sC_ID; }
            set { sC_ID = value; }
        }

        public string SC_CptName
        {
            get { return sC_CptName; }
            set { sC_CptName = value; }
        }

        public string SC_CptContent
        {
            get { return sC_CptContent; }
            set { sC_CptContent = value; }
        }

        public string SC_Phone
        {
            get { return sC_Phone; }
            set { sC_Phone = value; }
        }

        public string SC_Address
        {
            get { return sC_Address; }
            set { sC_Address = value; }
        }

        public string SC_Reply
        {
            get { return sC_Reply; }
            set { sC_Reply = value; }
        }

        public bool SC_Open
        {
            get { return sC_Open; }
            set { sC_Open = value; }
        }

        public int SC_TSID
        {
            get { return sC_TSID; }
            set { sC_TSID = value; }
        }

        public string SC_ReplyTime
        {
            get { return sC_ReplyTime; }
            set { sC_ReplyTime = value; }
        }
        public string SC_CreateTime
        {
            get { return sC_CreateTime; }
            set { sC_CreateTime = value; }
        }
    }
}
