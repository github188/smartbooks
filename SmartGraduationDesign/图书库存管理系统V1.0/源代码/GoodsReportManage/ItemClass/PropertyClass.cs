using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsReportManage.ItemClass
{
    class PropertyClass
    {
        private static string sendnamevalue;
        /// <summary>
        /// ���ݵ�¼��Ա�˺�
        /// </summary>
        public static string SendNameValue
        {
            set
            {
                sendnamevalue = value;
            }
            get
            {
                return sendnamevalue;
            }
        }

        private static string sendpopedomvalue;
        /// <summary>
        /// �����û�Ȩ��
        /// </summary>
        public static string SendPopedomValue
        {
            set
            {
                sendpopedomvalue = value;
            }
            get
            {
                return sendpopedomvalue;
            }
        }

        private static string senduseridvalue;
        /// <summary>
        /// �����û�ID����
        /// </summary>
        public static string SendUserIDValue
        {
            set
            {
                senduseridvalue = value;
            }
            get
            {
                return senduseridvalue;
            }
        }

        private static string getdgvdata;
        /// <summary>
        /// ��ȡDataGridView�ؼ����ݹ�����ֵ
        /// </summary>
        public static string GetDgvData
        {
            set
            {
                getdgvdata = value;
            }
            get
            {
                return getdgvdata;
            }
        }

        private static string savepassword;
        /// <summary>
        /// ��ȡ�û���¼����
        /// </summary>
        public static string SavePassword
        {
            set
            {
                savepassword = value;
            }
            get
            {
                return savepassword;
            }
        }

        private static string goodsid;
        /// <summary>
        /// ��ȡͼ��ID
        /// </summary>
        public static string GetGoodsID
        {
            set
            {
                goodsid = value;
            }
            get
            {
                return goodsid;
            }
        }

        private static string stocknum;
        /// <summary>
        /// ����������
        /// </summary>
        public static string StockNum
        {
            set
            {
                stocknum = value;
            }
            get
            {
                return stocknum;
            }
        }

        private static string stockname;
        /// <summary>
        /// ��ȡ�ֿ�����
        /// </summary>
        public static string StockName
        {
            set
            {
                stockname = value;
            }
            get
            {
                return stockname;
            }
        }

        private static string stockid;
        /// <summary>
        /// ��ȡ���ID
        /// </summary>
        public static string GetStockID
        {
            set
            {
                stockid = value;
            }
            get
            {
                return stockid;
            }
        }

        private static string companyname;
        /// <summary>
        /// ��ȡ��Ӧ������
        /// </summary>
        public static string GetCompanyName
        {
            set
            {
                companyname = value;
            }
            get
            {
                return companyname;
            }
        }

        private static string stockunit;
        /// <summary>
        /// ��ȡͼ�鵥λ
        /// </summary>
        public static string GetStockUnit
        {
            set
            {
                stockunit = value;
            }
            get
            {
                return stockunit;
            }
        }

        private static string stockspec;
        /// <summary>
        /// ��ȡͼ����
        /// </summary>
        public static string GetStockSpec
        {
            set
            {
                stockspec = value;
            }
            get
            {
                return stockspec;
            }
        }

        private static string goodsinprice;
        /// <summary>
        /// ��ȡͼ�����
        /// </summary>
        public static string GetGoodsInPrice
        {
            set
            {
                goodsinprice = value;
            }
            get
            {
                return goodsinprice;
            }
        }

        private static string sellprice;
        /// <summary>
        /// ��ȡͼ���ۼ�
        /// </summary>
        public static string GetSellPrice
        {
            set
            {
                sellprice = value;
            }
            get
            {
                return sellprice;
            }
        }
    }
}
