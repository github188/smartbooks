namespace SmartSpider {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Config;
    using System.Xml.Serialization;
    using System.IO;

    public partial class FrmTask : Form {
        /// <summary>
        /// 任务单元
        /// </summary>
        private TaskUnit _TaskUnit = new TaskUnit();

        public FrmTask(ref TaskUnit taskUnit) {
            InitializeComponent();
            this._TaskUnit = taskUnit;

            this.SetUnitToUI();
        }

        /// <summary>
        /// 保存任务配置
        /// </summary>
        /// <param name="task">任务配置文件</param>
        /// <param name="path">文件保存路径</param>
        private void SaveTaskConfig(Task task, string path) {
            XmlSerializer xs = new XmlSerializer(typeof(Task));
            Stream writeStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);
            xs.Serialize(writeStream, task);
            writeStream.Close();
            writeStream.Dispose();
        }

        /// <summary>
        /// 绑定任务单元到UI界面,用于新建/修改任务
        /// </summary>
        private void SetUnitToUI() {
            this.txtName.Text = this._TaskUnit.TaskConfig.Name;                                                         //任务名称
            this.txtDescription.Text = this._TaskUnit.TaskConfig.Description;                                           //任务描述
            this.txtCookie.Text = this._TaskUnit.TaskConfig.Cookie;                                                     //Cookie
            this.nudThreadNumber.Value = this._TaskUnit.TaskConfig.ThreadNumber;                                        //线程数量
            this.txtStartingUrlTemplate.Text = this._TaskUnit.TaskConfig.UrlListManager.StartingUrlTemplate;            //起始Url地址模板
            this.txtConnectionString.Text = this._TaskUnit.TaskConfig.ConnectionString;                                 //数据库连接字符串
            this.chbDeleteResultAfterPublication.Checked = this._TaskUnit.TaskConfig.DeleteResultAfterPublication;      //发布结果后删除数据
            this.chbDisableScheduleAfterFinish.Checked = this._TaskUnit.TaskConfig.DisableScheduleAfterFinish;          //取消定时采集
            this.txtPluginPath.Text = this._TaskUnit.TaskConfig.PluginPath;                                             //插件路径
            this.chbUseProcedure.Checked = this._TaskUnit.TaskConfig.UseProcedure;                                      //使用存储过程
            this.chbIgnoreDataColumnNotFound.Checked = this._TaskUnit.TaskConfig.IgnoreDataColumnNotFound;              //忽略不存在的数据列
            this.rdbAutoLogin.Checked = this._TaskUnit.TaskConfig.LoginAutomatically;                                   //自动登录            
            this.chbOutputDetailedLog.Checked = this._TaskUnit.TaskConfig.OutputDetailedLog;                            //输出详细日志
            this.cbxPublicationTarget.Text = this._TaskUnit.TaskConfig.PublicationTarget;                               //发布目标
            this.chbSaveLogToFile.Checked = this._TaskUnit.TaskConfig.SaveLogToFile;                                    //保存日志到文件
            this.chbSaveErrorRows.Checked = this._TaskUnit.TaskConfig.SaveErrorRows;                                    //保存错误行到文件
            this.chbSaveRepeatedRows.Checked = this._TaskUnit.TaskConfig.SaveRepeatedRows;                              //保存重复行到文件
            this.chbUsePluginOfDownloadContentFile.Checked = this._TaskUnit.TaskConfig.UsePluginOfDownloadContentFile;  //使用插件下载内容文件
            this.chbUsePluginOfDownloadSingleFile.Checked = this._TaskUnit.TaskConfig.UsePluginOfDownloadSingleFile;    //使用插件下载独立文件
            this.chbUsePluginOfProcessResultRow.Checked = this._TaskUnit.TaskConfig.UsePluginOfProcessResultRow;        //使用插件处理采集结果数据行
            this.chbUsePluginOfGetWebProxy.Checked = this._TaskUnit.TaskConfig.UsePluginOfGetWebProxy;                  //从插件载入代理服务器
            this.chbUsePluginOfProcessContentFile.Checked = this._TaskUnit.TaskConfig.UsePluginOfProcessContentFile;    //使用插件处理下载后的内容文件
            this.chbUsePluginOfProcessSingleFile.Checked = this._TaskUnit.TaskConfig.UsePluginOfProcessSingleFile;      //使用插件处理单个文件
            this.cbxUrlEncoding.Text = this._TaskUnit.TaskConfig.UrlListManager.UrlEncoding;                            //网址编码
            this.nudHistoryCount.Value = this._TaskUnit.TaskConfig.UrlListManager.HistoryUrlCapacity;                   //历史记录网址最大容量

            #region 数据库类型
            switch (this._TaskUnit.TaskConfig.DatabaseType) {
                case DatabaseType.Access:
                    rdoDataTypeAccess.Checked = true;
                    break;
                case DatabaseType.MySql:
                    rdoDataTypeMySql.Checked = true;
                    break;
                case DatabaseType.Oracle:
                    rdoDataTypeOracle.Checked = true;
                    break;
                case DatabaseType.SqlLite:
                    rdoDataTypeSqlLite.Checked = true;
                    break;
                case DatabaseType.SqlServer:
                    rdoDataTypeSqlServer.Checked = true;
                    break;
            }
            #endregion

            #region 发布结果选项
            if (this._TaskUnit.TaskConfig.PublishResultDircetly) {
                this.rdoResultSaveDB.Checked = true;
                this.rdoResultSaveFile.Checked = false;
            } else {
                this.rdoResultSaveFile.Checked = true;
                this.rdoResultSaveDB.Checked = false;
            }
            #endregion

            #region 采集规则
            this.LivExtractionRule.Items.Clear();
            for (int i = 0; i < this._TaskUnit.TaskConfig.ExtractionRules.Count; i++) {
                Utility.ExtractionRulesItem item = new Utility.ExtractionRulesItem(this._TaskUnit.TaskConfig.ExtractionRules[i], i);
                LivExtractionRule.Items.Add(item);
            }
            #endregion

            #region 导航规则
            this.livNavigationRule.Items.Clear();
            for (int i = 0; i < this._TaskUnit.TaskConfig.UrlListManager.NavigationRules.Count; i++) {
                Utility.NavigationRuleItem item = new Utility.NavigationRuleItem(this._TaskUnit.TaskConfig.UrlListManager.NavigationRules[i], i);
                this.livNavigationRule.Items.Add(item);
            }
            #endregion

            #region 起始地址列表
            this.libStartingUrlList.Items.Clear();
            foreach (string url in this._TaskUnit.TaskConfig.UrlListManager.StartingUrlList) {
                this.libStartingUrlList.Items.Add(url);
            }
            foreach (PagedUrlPatterns p in this._TaskUnit.TaskConfig.UrlListManager.PagedUrlPattern) {
                this.libStartingUrlList.Items.Add(p.PagedUrlPattern);
            }
            #endregion
        }

        /// <summary>
        /// 获取当前已修改的UI界面任务配置设置
        /// </summary>
        /// <returns>任务配置对象</returns>
        private Task GetUiConfig() {
            Task t = new Task();
            #region 保存任务设置
            t.Name = this.txtName.Text;
            t.Description = this.txtDescription.Text;
            t.ThreadNumber = Convert.ToInt32(this.nudThreadNumber.Value);
            t.UrlListManager.UrlEncoding = this.cbxUrlEncoding.Text;
            t.UrlListManager.HistoryUrlCapacity = Convert.ToInt32(this.nudHistoryCount.Value);
            t.OutputDetailedLog = this.chbOutputDetailedLog.Checked;
            t.SaveLogToFile = this.chbSaveLogToFile.Checked;
            t.LoginAutomatically = this.rdbAutoLogin.Checked;
            t.Cookie = this.txtCookie.Text;
            t.ScheduleEnabled = this.chbScheduleEnabled.Checked;
            t.ScheduleLimitTimeRange = this.chbScheduleLimitTimeRange.Checked;
            t.DisableScheduleAfterFinish = this.chbDisableScheduleAfterFinish.Checked;
            t.ScheduleDays = Convert.ToInt32(this.nudScheduleDays.Value);
            t.ScheduleHours = Convert.ToInt32(this.nudScheduleHours.Value);
            t.ScheduleMinutes = Convert.ToInt32(this.nudScheduleHours.Value);
            t.UseProcedure = this.chbUseProcedure.Checked;
            t.PublicationTarget = this.cbxPublicationTarget.Text;
            t.ConnectionString = this.txtConnectionString.Text;
            t.DeleteResultAfterPublication = this.chbDeleteResultAfterPublication.Checked;
            t.ElapsedTime = 0;
            t.IgnoreDataColumnNotFound = this.chbIgnoreDataColumnNotFound.Checked;
            t.SaveRepeatedRows = this.chbSaveRepeatedRows.Checked;
            t.SaveErrorRows = this.chbSaveErrorRows.Checked;
            t.PluginPath = this.txtPluginPath.Text;
            t.UsePluginOfProcessContentFile = this.chbUsePluginOfProcessContentFile.Checked;
            t.UsePluginOfProcessSingleFile = this.chbUsePluginOfProcessSingleFile.Checked;
            t.UsePluginOfDownloadContentFile = this.chbUsePluginOfDownloadContentFile.Checked;
            t.UsePluginOfDownloadSingleFile = this.chbUsePluginOfDownloadSingleFile.Checked;
            t.UsePluginOfProcessResultRow = this.chbUsePluginOfProcessResultRow.Checked;
            t.UsePluginOfGetWebProxy = this.chbUsePluginOfGetWebProxy.Checked;
            #endregion

            #region 发布结果选项
            if (this.rdoResultSaveFile.Checked) {
                t.PublishResultDircetly = false;
            } else {
                t.PublishResultDircetly = true;
            }
            #endregion

            #region 数据库类型
            if (this.rdoDataTypeAccess.Checked) {
                t.DatabaseType = DatabaseType.Access;
            } else if (this.rdoDataTypeMySql.Checked) {
                t.DatabaseType = DatabaseType.MySql;
            } else if (this.rdoDataTypeOracle.Checked) {
                t.DatabaseType = DatabaseType.Oracle;
            } else if (this.rdoDataTypeSqlLite.Checked) {
                t.DatabaseType = DatabaseType.SqlLite;
            } else if (this.rdoDataTypeSqlServer.Checked) {
                t.DatabaseType = DatabaseType.SqlServer;
            }
            #endregion

            #region 起始地址 {start, end, step}
            foreach (string url in this.libStartingUrlList.Items) {
                MatchCollection regexMatch = Regex.Matches(url, "{[0-9,-]*}");
                if (regexMatch.Count != 0) {
                    string[] v = regexMatch[0].Value.Replace("}", "").Replace("{","").Split(',');
                    PagedUrlPatterns p = new PagedUrlPatterns();
                    p.Format = PagedUrlPatternsMode.Increment;
                    p.PagedUrlPattern = url;
                    p.StartPage = Convert.ToDouble(v[0]);
                    p.EndPage = Convert.ToDouble(v[1]);
                    if (v.Length >= 3) {
                        p.Step = Convert.ToDouble(v[2]);
                    }
                    if (p.StartPage > p.EndPage) {
                        p.Format = PagedUrlPatternsMode.Decreasing;
                    }
                    t.UrlListManager.PagedUrlPattern.Add(p);
                } else {
                    t.UrlListManager.StartingUrlList.Add(url);
                }
            }
            #endregion

            #region 导航地址
            foreach (Utility.NavigationRuleItem item in this.livNavigationRule.Items) {
                t.UrlListManager.NavigationRules.Add(item.rule);
            }
            #endregion

            #region 采集规则
            foreach (Utility.ExtractionRulesItem item in this.LivExtractionRule.Items) {
                t.ExtractionRules.Add(item.rule);
            }
            #endregion

            return t;
        }

        #region 窗体事件
        //应用
        private void btnAccept_Click(object sender, EventArgs e) {
            Task t = GetUiConfig();
            if (!this._TaskUnit.TaskConfig.Equals(t)) {
                if (MessageBox.Show("配置文件已更改，是否保存配置文件？", "保存提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                    System.Windows.Forms.DialogResult.Yes) {
                    this.SaveTaskConfig(t, this._TaskUnit.ConfigPath);
                }
            }
            this.Close();
            this.Dispose();
        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
            this.Dispose();
        }
        //确定
        private void btnSubmit_Click(object sender, EventArgs e) {
            Task t = GetUiConfig();
            if (!this._TaskUnit.TaskConfig.Equals(t)) {
                if (MessageBox.Show("配置文件已更改，是否保存配置文件？", "保存提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                    System.Windows.Forms.DialogResult.Yes) {
                    this.SaveTaskConfig(t, this._TaskUnit.ConfigPath);
                }
            }
            this.Close();
            this.Dispose();
        }
        #endregion
    }
}