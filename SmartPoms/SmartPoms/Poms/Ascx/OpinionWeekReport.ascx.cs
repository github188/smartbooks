

namespace SmartPoms.Poms.Ascx {
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Net.Mail;

    public partial class OpinionWeekReport : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindYears();
                BindWeeks();
            }
        }

        private void BindYears() {
            this.ddlYears.Items.Clear();
            for (int i = DateTime.Now.Year; i > 2010; i--) {
                this.ddlYears.Items.Add(new ListItem(string.Format("{0}年", i), i.ToString()));
            }
            this.ddlYears.SelectedIndex = 0;
        }

        private void BindWeeks() {
            ddlWeeks.Items.Clear();
            int year = Convert.ToInt32(this.ddlYears.SelectedValue);
            int week = DateTime.IsLeapYear(year) ? 366 : 365;
            week = week / 7;
            for (int i = 1; i <= week; i++) {
                ddlWeeks.Items.Add(new ListItem(string.Format("第{0}周", i),i.ToString()));
            }
            if (year == DateTime.Now.Year) {
                ddlWeeks.SelectedIndex = DateTime.Now.DayOfYear / 7;
            } else {
                this.ddlWeeks.SelectedIndex = 0;
            }
        }

        protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e) {
            BindWeeks();
        }

        protected void btnDownload_Click(object sender, EventArgs e) {
            #region 变量初始化
            DateTime beginDate;
            DateTime endDate;
            DataTable eventDt = new DataTable();
            string getEvent = "select a.eventid,a.eventName,a.score from Base_Event a where a.enable=0 order by score desc";
            string fileTemplate = Server.MapPath("~/Template/OpinionWeekReport.docx");
            string rootPath = Server.MapPath("~/Files");
            string fileName = string.Format("\\{0}年{1:d2}周-舆情周报.docx", ddlYears.SelectedValue, ddlWeeks.SelectedValue);
            string weekFileName = rootPath + fileName;
            BLL.BuildWord.ReportParam pam = new BLL.BuildWord.ReportParam();
            BLL.Service.ArticleService articleService = new BLL.Service.ArticleService();
            #endregion

            #region 获取当前周的起止日期
            Smart.Utility.Date.WeekService.GetDaysOfWeeks(
                Convert.ToInt32(ddlYears.SelectedValue),
                Convert.ToInt32(ddlWeeks.SelectedValue),
                System.Globalization.CalendarWeekRule.FirstFourDayWeek,
                out beginDate,
                out endDate);
            #endregion

            #region 获取统计数据
            //获取专题
            eventDt = Smart.DBUtility.SqlServerHelper.Query(getEvent).Tables[0];
            #endregion

            #region 编写正文内容
            pam.BodyContent = string.Format("{0}至{1}期间，主要监测舆情分类为：", 
                beginDate.ToString("yyyy年MM月dd日"), 
                endDate.ToString("yyyy年MM月dd日"));
            foreach (DataRow eventRow in eventDt.Rows) {
                pam.BodyContent += string.Format("{0}、", eventRow["eventName"].ToString());
            }
            foreach (DataRow eventRow in eventDt.Rows) {
                #region 获取该分类下文章
                DataTable articleDt = articleService.GetEventArticle(
                    beginDate.ToString("yyyy-MM-dd"),
                    endDate.ToString("yyyy-MM-dd"), 
                    Convert.ToInt32(eventRow["eventid"]));

                pam.BodyContent += string.Format("其中在舆情监测分类 {0} 下,本周共监测到 {1} 条舆情信息。",
                    eventRow["eventName"].ToString(),
                    articleDt.Rows.Count.ToString());

                #region 编写舆情分类下内容
                if (articleDt.Rows.Count != 0) {
                    pam.BodyContent += "其中负面比值较高的舆情信息为以下几条：";
                    for (int i = 0; i < articleDt.Rows.Count; i++) {
                        if (i < 10) {
                            pam.BodyContent += string.Format("{0}.{1}。",
                                (i + 1).ToString(),
                                articleDt.Rows[i]["文章标题"].ToString());
                        } else if (i > 10) {
                            break;
                        }
                    }
                    pam.BodyContent += "。";
                }
                #endregion
                #endregion
            }
            #endregion

            #region 初始化简报内容并生成简报文件
            pam.AnnexContent = "附件内容";
            //pam.BodyContent = "正文内容";
            pam.KeyWord = new List<string>();
            pam.CreateDate = DateTime.Now.ToLongDateString();
            pam.PublishDate = DateTime.Now.ToLongDateString();
            pam.FileName = fileName;
            pam.PublishWord = "高管局发";
            pam.Tel = "0371-87166989";
            pam.Author = "郑州豫图信息技术有限公司";
            pam.Tile = "河南省高速公路管理局舆情简报";
            pam.UnitName = "河南省高速公路管理局";
            pam.Year = ddlYears.SelectedValue;
            pam.Number = ddlWeeks.SelectedValue;
            pam.SubTitle = string.Format("{0}年{1}周网络舆情简报", ddlYears.SelectedValue, ddlWeeks.SelectedValue);

            SmartPoms.BLL.BuildWord.WordService.BuildWeekWordFile(fileTemplate, weekFileName, pam);
            #endregion

            #region 下载简报文件
            Stream stream = new FileStream(weekFileName, FileMode.Open);
            Encoding code = Encoding.GetEncoding("gb2312");
            Response.ContentEncoding = code;
            Response.HeaderEncoding = code;
            Response.AddHeader("Content-Type", "application/msword");
            Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            Response.BinaryWrite(bytes);
            stream.Close();
            stream.Dispose();
            Response.End();
            #endregion
        }
    }
}