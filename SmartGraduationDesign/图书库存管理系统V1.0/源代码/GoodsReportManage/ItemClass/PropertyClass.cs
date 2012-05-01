using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsReportManage.ItemClass
{
    class PropertyClass
    {
        private static string sendnamevalue;
        /// <summary>
        /// 传递登录人员账号
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
        /// 传递用户权限
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
        /// 传递用户ID属性
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
        /// 获取DataGridView控件传递过来的值
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
        /// 获取用户登录密码
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
        /// 获取图书ID
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
        /// 保存库存数量
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
        /// 获取仓库名称
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
        /// 获取库存ID
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
        /// 获取供应商名称
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
        /// 获取图书单位
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
        /// 获取图书规格
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
        /// 获取图书进价
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
        /// 获取图书售价
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
