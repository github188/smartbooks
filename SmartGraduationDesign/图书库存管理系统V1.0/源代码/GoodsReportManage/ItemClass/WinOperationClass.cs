using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;  //添加引用
using GoodsReportManage.ItemClass;
using GoodsReportManage.Goods;
using GoodsReportManage.BaseRecord;
using GoodsReportManage.Sell;
using GoodsReportManage.CrystalReport;
using GoodsReportManage.Stock;
using CrystalDecisions.CrystalReports.Engine; 
using CrystalDecisions.Shared;
using GoodsReportManage.SysManage;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;


namespace GoodsReportManage.ItemClass
{
    class WinOperationClass
    {
        public WinOperationClass()
        {

        }

        SqlBaseClass G_SqlExecute = new SqlBaseClass();   //声明数据库操作类对象
        private string encryptkey = "Oyea";    //密钥  

        #region  执行“目录”控件中的项操作
        /// <summary>
        /// 执行“目录”控件中的项操作
        /// </summary>
        /// <param name="control">控件类型</param>
        /// <param name="form">所属窗体</param>
        public void ShowForm(ToolStripMenuItem control, Form form)
        {
            switch (control.Tag.ToString())
            {
                case "1":
                    EmployeeInfo employee = new EmployeeInfo();
                    employee.MdiParent = form;
                    employee.StartPosition = FormStartPosition.CenterScreen;
                    employee.Show();
                    break;
                case "2":
                    CompanyInfo company = new CompanyInfo();
                    company.MdiParent = form;
                    company.StartPosition = FormStartPosition.CenterScreen;
                    company.Show();
                    break;
                case "3":
                    Login login = new Login();
                    login.StartPosition = FormStartPosition.CenterScreen;
                    login.ShowDialog();
                    form.Dispose();   //释放窗体资源
                    break;
                case "5":
                    GoodsIn goodsin = new GoodsIn();
                    goodsin.MdiParent = form;
                    goodsin.StartPosition = FormStartPosition.CenterScreen;
                    goodsin.Show();
                    break;
                case "6":
                    ReGoods regoods = new ReGoods();
                    regoods.MdiParent = form;
                    regoods.StartPosition = FormStartPosition.CenterScreen;
                    regoods.Show();
                    break;
                case "7":
                    GoodsFind stockfind = new GoodsFind();
                    stockfind.MdiParent = form;
                    stockfind.StartPosition = FormStartPosition.CenterScreen;
                    stockfind.Show();
                    break;
                case "8":
                    s sellgoods = new s();
                    sellgoods.MdiParent = form;
                    sellgoods.StartPosition = FormStartPosition.CenterScreen;
                    sellgoods.Show();
                    break;
                case "9":
                    CustomerReGoods customerregoods = new CustomerReGoods();
                    customerregoods.MdiParent = form;
                    customerregoods.StartPosition = FormStartPosition.CenterScreen;
                    customerregoods.Show();
                    break;
                case "10":
                    SellFind sellfind = new SellFind();
                    sellfind.MdiParent = form;
                    sellfind.StartPosition = FormStartPosition.CenterScreen;
                    sellfind.Show();
                    break;
                case "11":
                    ChangeGoods changegoods = new ChangeGoods();
                    changegoods.MdiParent = form;
                    changegoods.StartPosition = FormStartPosition.CenterScreen;
                    changegoods.Show();
                    break;
                case "12":
                    StockAlarm stockalarm = new StockAlarm();
                    stockalarm.MdiParent = form;
                    stockalarm.StartPosition = FormStartPosition.CenterScreen;
                    stockalarm.Show();
                    break;
                case "13":
                    StockFind stockfindall = new StockFind();
                    stockfindall.MdiParent = form;
                    stockfindall.StartPosition = FormStartPosition.CenterScreen;
                    stockfindall.Show();
                    break;
                case "14":
                    EmployeeReport employeereport = new EmployeeReport();
                    employeereport.MdiParent = form;
                    employeereport.StartPosition = FormStartPosition.CenterScreen;
                    employeereport.Show();
                    break;
                case "15":
                    CompanyReport companyreport = new CompanyReport();
                    companyreport.MdiParent = form;
                    companyreport.StartPosition = FormStartPosition.CenterScreen;
                    companyreport.Show();
                    break;
                case "16":
                    GoodsInReport goodsinreport = new GoodsInReport();
                    goodsinreport.MdiParent = form;
                    goodsinreport.StartPosition = FormStartPosition.CenterScreen;
                    goodsinreport.Show();
                    break;
                case "17":
                    GoodsInAnalysisReport sellgodsreport = new GoodsInAnalysisReport();
                    sellgodsreport.MdiParent = form;
                    sellgodsreport.StartPosition = FormStartPosition.CenterScreen;
                    sellgodsreport.Show();
                    break;
                case "18":
                    EmployeeSellReport employeesellreport = new EmployeeSellReport();
                    employeesellreport.MdiParent = form;
                    employeesellreport.StartPosition = FormStartPosition.CenterScreen;
                    employeesellreport.Show();
                    break;
                case "19":
                    GoodsInAnalysisReport goodsinana = new GoodsInAnalysisReport();
                    goodsinana.MdiParent = form;
                    goodsinana.StartPosition = FormStartPosition.CenterScreen;
                    goodsinana.Show();
                    break;
                case "20":
                    SellGoodsAnalysisReport sellana = new SellGoodsAnalysisReport();
                    sellana.MdiParent = form;
                    sellana.StartPosition = FormStartPosition.CenterScreen;
                    sellana.Show();
                    break;
                case "21":
                    SetPopedom setpopedom = new SetPopedom();
                    setpopedom.MdiParent = form;
                    setpopedom.StartPosition = FormStartPosition.CenterScreen;
                    setpopedom.Show();
                    break;
                case "22":
                    ChangePwd changepwd = new ChangePwd();
                    changepwd.MdiParent = form;
                    changepwd.StartPosition = FormStartPosition.CenterScreen;
                    changepwd.Show();
                    break;
                case "23":
                    BakData bakdata = new BakData();
                    bakdata.MdiParent = form;
                    bakdata.StartPosition = FormStartPosition.CenterScreen;
                    bakdata.Show();
                    break;
                case "24":
                    ReBakData rebakdata = new ReBakData();
                    rebakdata.MdiParent = form;
                    rebakdata.StartPosition = FormStartPosition.CenterScreen;
                    rebakdata.Show();
                    break;
                case "25":
                    SysUser sysuser = new SysUser();
                    sysuser.MdiParent = form;
                    sysuser.StartPosition = FormStartPosition.CenterScreen;
                    sysuser.Show();
                    break;
                case "30":
                    CustomerInfo customer = new CustomerInfo();
                    customer.MdiParent = form;
                    customer.StartPosition = FormStartPosition.CenterScreen;
                    customer.Show();
                    break;
                case "31":
                    EmployeeSellAnalysisReport sell= new EmployeeSellAnalysisReport();
                    sell.MdiParent = form;
                    sell.StartPosition = FormStartPosition.CenterScreen;
                    sell.Show();
                    break;
                default:
                    break;
            }
        }

        //private DialogResult MessageBox(string p, string p_2, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}
        #endregion

        #region  数据绑定ComboBox控件
        /// <summary>
        /// 数据绑定ComboBox控件
        /// </summary>
        /// <param name="cmdtxt">要查询的SQL语句</param>
        /// <param name="cbxname">绑定的ComboBox控件的名称</param>
        /// <param name="bindmember">要绑定的数据表中的字段</param>
        public void BindComboBox(string cmdtxt, ComboBox cbxname,string bindmember)
        {
            cbxname.BeginUpdate();
            cbxname.DataSource = G_SqlExecute.GetDs(cmdtxt).Tables[0];
            cbxname.DisplayMember = bindmember;
            cbxname.ValueMember = bindmember;
            cbxname.EndUpdate();
        }
        #endregion

        #region  绑定报表
        /// <summary>
        /// 绑定报表
        /// </summary>
        /// <param name="crystalreportname">报表名称</param>
        /// <param name="selectionFormula">要执行的语句</param>
        /// <returns></returns>
        public ReportDocument CrystalReports(string crystalreportname , string selectionFormula)
        {
            ReportDocument P_Doc = new ReportDocument();
            string reportPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            reportPath += @"\CrystalReport\ReportDoc\"+crystalreportname;   //获取报表路径
            P_Doc.Load(reportPath);   //加载报表

            P_Doc.DataDefinition.RecordSelectionFormula = selectionFormula;


            //Set Database Logon to main report 
            foreach (CrystalDecisions.Shared.IConnectionInfo connection in P_Doc.DataSourceConnections)
            {
                connection.SetConnection(
                       ConfigurationManager.AppSettings["ServerName"],
                       ConfigurationManager.AppSettings["DataBase"],
                       ConfigurationManager.AppSettings["UserName"],
                       ConfigurationManager.AppSettings["Pwd"]);
            }

            //Set Database Logon to subreport 
            foreach (CrystalDecisions.CrystalReports.Engine.ReportDocument subreport in P_Doc.Subreports)
            {
                foreach (CrystalDecisions.Shared.IConnectionInfo connection in subreport.DataSourceConnections)
                {
                    connection.SetConnection(
                       ConfigurationManager.AppSettings["ServerName"],
                       ConfigurationManager.AppSettings["DataBase"],
                       ConfigurationManager.AppSettings["UserName"],
                       ConfigurationManager.AppSettings["Pwd"]);
                }
            } 
            return P_Doc;
        }
        #endregion

        #region   对数据进行加密
        /// <summary>
        /// 对数据进行加密
        /// </summary>
        /// <param name="encryptstring">需要加密的数据</param>
        /// <returns></returns>
        public string DESEncrypt(string encryptstring)
        {
            string strRtn;
            try
            {
                DESCryptoServiceProvider desc = new DESCryptoServiceProvider();//des进行加密
                byte[] key = System.Text.Encoding.Unicode.GetBytes(encryptkey);
                byte[] data = System.Text.Encoding.Unicode.GetBytes(encryptstring);
                MemoryStream ms = new MemoryStream();//存储加密后的数据
                CryptoStream cs = new CryptoStream(ms, desc.CreateEncryptor(key, key), CryptoStreamMode.Write);
                cs.Write(data, 0, data.Length);//进行加密
                cs.FlushFinalBlock();
                strRtn = Convert.ToBase64String(ms.ToArray());
                return strRtn;
            }

            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex.Message, "错误消息提示框", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion

        #region   对数据进行解密
        /// <summary>
        /// 对数据进行解密
        /// </summary>
        /// <param name="decryptstring">需要解密的数据</param>
        /// <returns></returns>
        public string DESDecrypt(string decryptstring)
        {
			string strRtn;
            try
            {
                DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
                byte[] key = System.Text.Encoding.Unicode.GetBytes(encryptkey);
                byte[] data = Convert.FromBase64String(decryptstring);
                MemoryStream ms = new MemoryStream();//存储解密后的数据
                CryptoStream cs = new CryptoStream(ms, desc.CreateDecryptor(key, key), CryptoStreamMode.Write);
                cs.Write(data, 0, data.Length);//解密数据
                cs.FlushFinalBlock();
                strRtn = System.Text.Encoding.Unicode.GetString(ms.ToArray());
                return strRtn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex.Message, "错误消息提示框", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion

        #region 判断是否为数字
        /// <summary>
        /// 判断数据字符是否为数字
        /// </summary>
        /// <param name="strCode">需要判断的字符串</param>
        /// <returns></returns>
        public bool IsNumeric(string strCode)
        {

            if (strCode == null || strCode.Length == 0)
            {
                return false;
            }
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] byteStr = ascii.GetBytes(strCode);
            foreach (byte code in byteStr)
            {

                if (code < 48 || code > 57)

                    return false;
            }
            return true;
        }

        #endregion
    }
}
