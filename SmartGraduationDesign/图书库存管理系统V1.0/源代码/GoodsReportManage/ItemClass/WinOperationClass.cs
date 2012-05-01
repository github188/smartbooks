using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;  //�������
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

        SqlBaseClass G_SqlExecute = new SqlBaseClass();   //�������ݿ���������
        private string encryptkey = "Oyea";    //��Կ  

        #region  ִ�С�Ŀ¼���ؼ��е������
        /// <summary>
        /// ִ�С�Ŀ¼���ؼ��е������
        /// </summary>
        /// <param name="control">�ؼ�����</param>
        /// <param name="form">��������</param>
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
                    form.Dispose();   //�ͷŴ�����Դ
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

        #region  ���ݰ�ComboBox�ؼ�
        /// <summary>
        /// ���ݰ�ComboBox�ؼ�
        /// </summary>
        /// <param name="cmdtxt">Ҫ��ѯ��SQL���</param>
        /// <param name="cbxname">�󶨵�ComboBox�ؼ�������</param>
        /// <param name="bindmember">Ҫ�󶨵����ݱ��е��ֶ�</param>
        public void BindComboBox(string cmdtxt, ComboBox cbxname,string bindmember)
        {
            cbxname.BeginUpdate();
            cbxname.DataSource = G_SqlExecute.GetDs(cmdtxt).Tables[0];
            cbxname.DisplayMember = bindmember;
            cbxname.ValueMember = bindmember;
            cbxname.EndUpdate();
        }
        #endregion

        #region  �󶨱���
        /// <summary>
        /// �󶨱���
        /// </summary>
        /// <param name="crystalreportname">��������</param>
        /// <param name="selectionFormula">Ҫִ�е����</param>
        /// <returns></returns>
        public ReportDocument CrystalReports(string crystalreportname , string selectionFormula)
        {
            ReportDocument P_Doc = new ReportDocument();
            string reportPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            reportPath += @"\CrystalReport\ReportDoc\"+crystalreportname;   //��ȡ����·��
            P_Doc.Load(reportPath);   //���ر���

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

        #region   �����ݽ��м���
        /// <summary>
        /// �����ݽ��м���
        /// </summary>
        /// <param name="encryptstring">��Ҫ���ܵ�����</param>
        /// <returns></returns>
        public string DESEncrypt(string encryptstring)
        {
            string strRtn;
            try
            {
                DESCryptoServiceProvider desc = new DESCryptoServiceProvider();//des���м���
                byte[] key = System.Text.Encoding.Unicode.GetBytes(encryptkey);
                byte[] data = System.Text.Encoding.Unicode.GetBytes(encryptstring);
                MemoryStream ms = new MemoryStream();//�洢���ܺ������
                CryptoStream cs = new CryptoStream(ms, desc.CreateEncryptor(key, key), CryptoStreamMode.Write);
                cs.Write(data, 0, data.Length);//���м���
                cs.FlushFinalBlock();
                strRtn = Convert.ToBase64String(ms.ToArray());
                return strRtn;
            }

            catch (Exception ex)
            {
                MessageBox.Show("����" + ex.Message, "������Ϣ��ʾ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion

        #region   �����ݽ��н���
        /// <summary>
        /// �����ݽ��н���
        /// </summary>
        /// <param name="decryptstring">��Ҫ���ܵ�����</param>
        /// <returns></returns>
        public string DESDecrypt(string decryptstring)
        {
			string strRtn;
            try
            {
                DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
                byte[] key = System.Text.Encoding.Unicode.GetBytes(encryptkey);
                byte[] data = Convert.FromBase64String(decryptstring);
                MemoryStream ms = new MemoryStream();//�洢���ܺ������
                CryptoStream cs = new CryptoStream(ms, desc.CreateDecryptor(key, key), CryptoStreamMode.Write);
                cs.Write(data, 0, data.Length);//��������
                cs.FlushFinalBlock();
                strRtn = System.Text.Encoding.Unicode.GetString(ms.ToArray());
                return strRtn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("����" + ex.Message, "������Ϣ��ʾ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion

        #region �ж��Ƿ�Ϊ����
        /// <summary>
        /// �ж������ַ��Ƿ�Ϊ����
        /// </summary>
        /// <param name="strCode">��Ҫ�жϵ��ַ���</param>
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
