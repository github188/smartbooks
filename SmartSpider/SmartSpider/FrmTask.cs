﻿namespace SmartSpider {
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
        private TaskUnit _TaskUnit = new TaskUnit();
        private List<Replacement> _Replacement = new List<Replacement>();
        private List<HtmlMark> _htmlMakes = new List<HtmlMark>();

        public FrmTask(ref TaskUnit taskUnit) {
            InitializeComponent();
            this._TaskUnit = taskUnit;

            //保存任务配置信息
            taskUnit.SaveTaskConfiguration(@"c:\01.xml");

            this.SetUnitToUI();
        }

        #region 初始化、获取、保存任务配置信息

        /// <summary>
        /// 绑定任务单元到UI界面,用于新建/修改任务
        /// </summary>
        private void SetUnitToUI() {
            #region 常规选项设置
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
            this.chbStartingUrlEncoded.Checked = this._TaskUnit.TaskConfig.UrlListManager.StartingUrlEncoded;           //起始地址已编码
            this.lblUrlAddressCount.Text = "地址总数 " + this._TaskUnit.TaskConfig.UrlListManager.StartingUrlList.Count.ToString(); //地址总数
            //未设置(使用插件对采集结果进行筛选,将在软件内置筛选之后进行)
            #endregion

            #region 定时采集（任务调度）
            //调度模式
            if (this._TaskUnit.TaskConfig.ScheduleMode == ScheduleMode.Time) {
                //每隔时间段
                rdoScheduleModeTime.Checked = true;
                rdoScheduleModeDay.Checked = false;

                this.nudScheduleDays.Value = this._TaskUnit.TaskConfig.ScheduleDays;    //天
                this.nudScheduleHours.Value = this._TaskUnit.TaskConfig.ScheduleHours;  //时
                this.nudScheduleMinutes.Value = this._TaskUnit.TaskConfig.ScheduleMinutes;  //分
            } else {
                //（每当模式）
                rdoScheduleModeTime.Checked = false;
                rdoScheduleModeDay.Checked = true;

                //每当时间
                //this._TaskUnit.TaskConfig.ScheduleFromDayOfWeek; //每当星期几开始
                //this._TaskUnit.TaskConfig.ScheduleFromDay; //每当星期几开始
                //this._TaskUnit.TaskConfig.ScheduleFromHour; //每当X小时调度

                //预定时间
                //this._TaskUnit.TaskConfig.ScheduleFromDayOfWeek; //预定星期几结束
                //this._TaskUnit.TaskConfig.ScheduleToDay; //预定天
                //this._TaskUnit.TaskConfig.ScheduleToHour; //预定小时
            }
            #endregion

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
            t.ElapsedTime = this._TaskUnit.TaskConfig.ElapsedTime;    /*运行时间等于原任务时间*/
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

            #region 获取定时采集调度设置

            //每隔时间段
            if (rdoScheduleModeTime.Checked) {
                t.ScheduleMode = ScheduleMode.Time;
                t.ScheduleDays = (int)this.nudScheduleDays.Value;
                t.ScheduleHours = (int)this.nudScheduleHours.Value;
                t.ScheduleMinutes = (int)this.nudScheduleMinutes.Value;
            }

            //（每当模式/*该功能留在V2.0实现*/）
            if (rdoScheduleModeDay.Checked) {
                t.ScheduleMode = ScheduleMode.Day;
                //每当时间
                t.ScheduleFromDayOfWeek = this._TaskUnit.TaskConfig.ScheduleFromDayOfWeek; //每当星期几开始
                t.ScheduleFromDay = this._TaskUnit.TaskConfig.ScheduleFromDay; //每当星期几开始
                t.ScheduleFromHour = this._TaskUnit.TaskConfig.ScheduleFromHour; //每当X小时调度

                //预定时间
                t.ScheduleFromDayOfWeek = this._TaskUnit.TaskConfig.ScheduleFromDayOfWeek; //预定星期几结束
                t.ScheduleToDay = this._TaskUnit.TaskConfig.ScheduleToDay; //预定天
                t.ScheduleToHour = this._TaskUnit.TaskConfig.ScheduleToHour; //预定小时
            }

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
                    string[] v = regexMatch[0].Value.Replace("}", "").Replace("{", "").Split(',');
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

        #endregion

        #region 导航规则选项卡方法定义
        /// <summary>
        /// 重置导航规则选项卡
        /// </summary>
        private void ResetNavigationTabElement() {
            this.cbxLayerName.Text = "";
            this.cbxLayerName.Focus();
            this.rdoTerminal.Checked = true;
            this.txtNextLayerUrlPattern.Clear();
            this.chbUseRegularExpression.Checked = false;
            this.chbHistoryUrlEnabled.Checked = false;
            this.chbHistoryUrlOptimization.Checked = false;
            this.txtProccessScripts.Clear();
            this.chbProccessScripts.Checked = false;
            this.nudNextPageLargest.Value = 1;
            this.txtPickingStartFlag.Clear();
            this.txtPickingEndFlag.Clear();
            this.txtExtractionStartFlag.Clear();
            this.txtExtractionEndFlag.Clear();
            this.txtIterationFlag.Clear();
            this.nudRestInterval.Value = 1;
            this.cbxContentEncoding.Text = "utf-8";
            this.chbUsePluginOfVisit.Checked = false;
            this.chbJsDecoding.Checked = false;
            this.txtNextLayerUrlReferer.Clear();
            this.chbNextLayerUrlEncoded.Checked = false;
            this.cbxSkipToIfPickingFailed.Text = "最终页面";
            this.chbUsePluginOfPickNextLayerUrls.Checked = false;
            this.chbUsePluginOfPickNextPageUrl.Checked = false;
        }
        /// <summary>
        /// 获取导航规则对象
        /// </summary>
        /// <returns>导航规则</returns>
        private NavigationRule GetNavigation() {
            NavigationRule n = new NavigationRule();
            n.ContentEncoding = this.cbxContentEncoding.Text;   //内容编码
            n.ExtractionEndFlag = this.txtExtractionEndFlag.Text;   //内容采集范围结束标志
            n.ExtractionStartFlag = this.txtExtractionStartFlag.Text; //内容采集范围开始标志
            n.HistoryUrlEnabled = false;    //是否允许历史网址重复
            n.HistoryUrlOptimization = this.chbHistoryUrlOptimization.Checked;    //是否优化历史网址记录
            n.IterationFlag = txtIterationFlag.Text;   //循环标志
            n.JsDecoding = chbJsDecoding.Checked;   //对源文件进行JS解密
            n.Name = cbxLayerName.Text;    //层次名称
            n.NextLayerUrlEncoded = chbNextLayerUrlEncoded.Checked;  //下一层网址已编码
            n.NextLayerUrlPattern = txtNextLayerUrlPattern.Text; //下一层网址模板
            n.NextLayerUrlReferer = txtNextLayerUrlReferer.Text; //下一次呢过网址的referer
            n.NextPageLargest = Convert.ToInt32(nudNextPageLargest.Value);  //最大页数
            n.NextPageUrlPattern = txtProccessScripts.Text;  //下一页网址模板
            n.PickingEndFlag = txtPickingEndFlag.Text;  //网址提取范围结束标志
            n.PickingStartFlag = txtPickingStartFlag.Text;    //网址提取范围开始标志
            n.PickNextLayerUrls = false;    //是否提取下一层的网址
            n.PickNextPageUrl = false;  //是否提取下一页的网址
            n.ProccessScripts = chbProccessScripts.Checked;  //是否开启下一页网址提取标记            
            n.RestInterval = Convert.ToInt32(nudRestInterval.Value); //访问休息间隔(秒)
            n.SkipToIfPickingFailed = cbxSkipToIfPickingFailed.Text;   //下一层网址提取失败跳转到层？
            n.Terminal = rdoTerminal.Checked; //终端页面
            n.UsePluginOfPickNextLayerUrls = chbUsePluginOfPickNextLayerUrls.Checked; //使用插件提取下一层网址
            n.UsePluginOfPickNextPageUrl = chbUsePluginOfPickNextPageUrl.Checked;   //使用插件提取下一页网址
            n.UsePluginOfVisit = chbUsePluginOfVisit.Checked; //使用插件访问本层Url
            n.UseRegularExpression = chbUseRegularExpression.Checked; //使用正则表达式
            n.Replacements = this._Replacement;  //源文件替换
            this._Replacement.Clear();
            return n;
        }
        #endregion

        #region 采集规则选项卡方法定义
        /// <summary>
        /// 重置采集规则选项卡
        /// </summary>
        private void ResetExtractionTabElement() {
            this.cbxName.Text = "";
            this.cbxName.Focus();
            this.cbxLayer.Text = "";
            this.cbxDataColumn.Text = "";
            this.chbDataUnique.Checked = false;
            this.txtPreviousFlag.Clear();
            this.txtFollowingFlag.Clear();
            this.chbGlobal.Checked = false;
            this.chbStatic.Checked = false;
            this.chkKeyRule.Checked = false;
            this.chbUsePlugin.Checked = false;
            this.chbDownloadImages.Checked = false;
            this.chbDownloadFlashes.Checked = false;
            this.chkDownloadSingleFile.Checked = false;
            this.chbDetectRealUrl.Checked = false;
            this.chbDownloadAttachments.Checked = false;
            this.cbxAttachmentUrlIdentifier.Text = "";
            this.txtDownloadDirectory.Text = "";
            this.txtVirtualPath.Text = "";
            this.chbUseRandomFileName.Checked = false;
            this.cbxFileNameExtension.Text = "";
            this.chbCreateSubDirectories.Checked = false;
            this.nudFilesPerSubDirectory.Value = 1;
            this.chbUseClassDirectory.Checked = false;
            this.cbxClassDirectory.Text = "";
            this.chbSkipIfFileExisted.Checked = false;
            this.rdoSaveSingleHtmlMake.Checked = false;
            this.rdoReserveAllHtmlMarks.Checked = true;
            this.chbUrlAsResult.Checked = false;
            this.chbPostParametersAsResult.Checked = false;
            this.chbTimeAsResult.Checked = false;
            this.chkLinkTextAsResult.Checked = false;
            this.chbResponseHeaderAsResult.Checked = false;
            this.cbxResponseHeaderName.Text = "";
            this.chbFixedAsResult.Checked = false;
            this.txtFixeValue.Text = "";
            this.chbMergePages.Checked = false;
            this.txtMergenceSeparator.Text = "";
        }
        /// <summary>
        /// 获取采集规则
        /// </summary>
        /// <returns>采集规则</returns>
        private ExtractionRule GetExtraction() {
            ExtractionRule e = new ExtractionRule();
            e.AttachmentUrlIdentifier = cbxAttachmentUrlIdentifier.Text; //附件网址标志
            e.ClassDirectoryField = cbxClassDirectory.Text;
            e.ConstantAsResult = chbFixedAsResult.Checked; //固定值作为结果
            e.ConstantValue = txtFixeValue.Text;   //固定值作为结果【值】
            e.CreateSubDirectories = chbCreateSubDirectories.Checked; //创建子目录
            e.CurrentSubDirectory = ""; //当前子目录
            e.DataColumn = cbxDataColumn.Text;  //数据库字段
            e.DataUnique = chbDataUnique.Checked;   //唯一数据
            e.DetectRealUrl = chbDetectRealUrl.Checked;    //探测真实Url
            e.DownloadAttachments = chbDownloadAttachments.Checked;  //下载附件
            e.DownloadDirectory = txtDownloadDirectory.Text;   //下载目录
            e.DownloadFlashes = chbDownloadFlashes.Checked;  //下载FLASH
            e.DownloadImages = chbDownloadImages.Checked;   //下载图片
            e.Essential = chkKeyRule.Checked;    //必要规则
            e.FileNameExtension = cbxFileNameExtension.Text;   //文件扩展名
            e.FilesPerSubDirectory = Convert.ToInt32(nudFilesPerSubDirectory.Value); //每隔子目录文件数量
            e.Filters = null;   //过滤选项
            e.FollowingFlag = txtFollowingFlag.Text;   //信息后标志
            e.Global = chbGlobal.Checked;   //全局规则
            e.IsDownloadUrl = false;    //下载网址
            e.Layer = Layer.Terminator; //页面层次
            e.LinkTextAsResult = chkLinkTextAsResult.Checked; //连接文本作为结果
            e.MergenceSeparator = txtMergenceSeparator.Text;   //合并后的页面分隔符
            e.MergePages = chbMergePages.Checked;   //合并分页
            e.Name = cbxName.Text;    //规则名称
            e.PostParametersAsResult = chbPostParametersAsResult.Checked;   //POST参数作为结果
            e.PreviousFlag = txtPreviousFlag.Text; //信息前标志
            e.Replacements = this._Replacement; //采集结果替换
            e.ReserveAllHtmlMarks = rdoReserveAllHtmlMarks.Checked;  //保留所有Html标记
            e.ReservedHtmlMarks = this._htmlMakes; //保留的Html标志
            e.ResponseHeaderAsResult = chbResponseHeaderAsResult.Checked;   //http头作为响应结果
            e.ResponseHeaderName = cbxResponseHeaderName.Text;  //响应头名
            e.SkipIfFileExisted = chbSkipIfFileExisted.Checked;    //文件存在则跳过
            e.Static = chbStatic.Checked;   //静态规则
            e.TimeAsResult = chbTimeAsResult.Checked; //记录采集时间
            e.UrlAsResult = chbUrlAsResult.Checked;  //记录当前网址
            e.UseClassDirectory = chbUseClassDirectory.Checked;    //使用分类目录
            e.UsePlugin = chbUsePlugin.Checked;    //使用插件采集数据
            e.UseRandomFileName = chbUseRandomFileName.Checked;    //使用随机文件名
            e.VirtualPath = txtVirtualPath.Text; //虚拟路径

            return e;
        }
        #endregion

        #region 全局提交操作
        //应用
        private void btnAccept_Click(object sender, EventArgs e) {
            Task t = GetUiConfig();

            //保存任务配置信息
            _TaskUnit.SaveTaskConfiguration(@"c:\02.xml", true, t);

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
                string filePath = _TaskUnit.ConfigPath;
                if (string.IsNullOrEmpty(t.Name) || string.IsNullOrEmpty(_TaskUnit.ConfigPath)) {
                    filePath = string.Format("{0}task\\{1}.xml", AppDomain.CurrentDomain.BaseDirectory, t.Name);
                }
                this.SaveTaskConfig(t, filePath);
            }
            this.Close();
            this.Dispose();
        }
        #endregion

        #region 起始地址选项卡
        //插入
        private void btnInsert_Click(object sender, EventArgs e) {

        }
        //捕获
        private void btnCapture_Click(object sender, EventArgs e) {

        }
        //添加
        private void btnAdd_Click(object sender, EventArgs e) {
            this.libStartingUrlList.Items.Add(this.txtStartingUrlTemplate.Text);
        }
        //修改
        private void btnModify_Click(object sender, EventArgs e) {
            int index = this.libStartingUrlList.SelectedIndex;
            this.libStartingUrlList.Items[index] = this.txtStartingUrlTemplate.Text;
        }
        //浏览
        private void btnBrowse_Click(object sender, EventArgs e) {

        }
        //删除
        private void btnDelete_Click(object sender, EventArgs e) {
            foreach (ListBox.SelectedObjectCollection cell in libStartingUrlList.SelectedItems) {
                libStartingUrlList.Items.Remove(cell);
            }
        }
        //清除
        private void btnClear_Click(object sender, EventArgs e) {
            this.libStartingUrlList.Items.Clear();
        }
        //上移
        private void btnMoveUP_Click(object sender, EventArgs e) {
            int index = libStartingUrlList.SelectedIndex;
            libStartingUrlList.Items.Remove(libStartingUrlList.Items[index]);
            libStartingUrlList.Items.Insert(index - 1, libStartingUrlList.Items[index]);
        }
        //下移
        private void btnMoveDown_Click(object sender, EventArgs e) {
            int index = libStartingUrlList.SelectedIndex;
            libStartingUrlList.Items.Remove(libStartingUrlList.Items[index]);
            libStartingUrlList.Items.Insert(index + 1, libStartingUrlList.Items[index]);
        }
        //导入
        private void btnImport_Click(object sender, EventArgs e) {

        }
        //导出
        private void btnExport_Click(object sender, EventArgs e) {

        }
        //双击起始地址列表选项卡
        private void libStartingUrlList_MouseDoubleClick(object sender, MouseEventArgs e) {
            int index = libStartingUrlList.SelectedIndex;
            this.txtStartingUrlTemplate.Text = libStartingUrlList.Items[index].ToString();
        }
        #endregion

        #region 导航规则选项卡
        //新建
        private void btnNavCreate_Click(object sender, EventArgs e) {
            ResetNavigationTabElement();
        }
        //保存
        private void btnNavSave_Click(object sender, EventArgs e) {
            this.livNavigationRule.Items.Add(new Utility.NavigationRuleItem(GetNavigation(),
                this.livNavigationRule.Items.Count + 1));
        }
        //删除
        private void btnNavDelete_Click(object sender, EventArgs e) {
            foreach (Utility.NavigationRuleItem item in this.livNavigationRule.SelectedItems) {
                this.livNavigationRule.Items.Remove(item);
            }
        }
        //上移
        private void btnNavMoveUp_Click(object sender, EventArgs e) {

        }
        //下移
        private void btnNavMoveDown_Click(object sender, EventArgs e) {

        }
        //需要提取下一页标记
        private void btnProccessScripts_Click(object sender, EventArgs e) {

        }
        //提取下一页选项卡
        private void chbPickNextPageUrl_CheckedChanged(object sender, EventArgs e) {
            if (this.chbProccessScripts.Checked) {
                this.txtProccessScripts.Enabled = true;
                this.btnProccessScripts.Enabled = true;
                this.nudNextPageLargest.Enabled = true;
            } else {
                this.txtProccessScripts.Enabled = false;
                this.btnProccessScripts.Enabled = false;
                this.nudNextPageLargest.Enabled = false;
            }
        }
        //源文件替换选项卡
        private void tabControl3_Selecting(object sender, TabControlCancelEventArgs e) {
            if (e.TabPageIndex == 5) {
                this._Replacement.Clear();
                FrmReplace r = new FrmReplace();
                r.Text = "源文件替换";
                r.ShowDialog();
            }
        }
        //双击导航规则
        private void livNavigationRule_MouseDoubleClick(object sender, MouseEventArgs e) {
            foreach (Utility.NavigationRuleItem item in livNavigationRule.SelectedItems) {
                #region 初始化
                cbxLayerName.Text = item.rule.Name; //层次名称
                txtNextLayerUrlPattern.Text = item.rule.NextLayerUrlPattern;    //下一层网址模板
                chbUseRegularExpression.Checked = item.rule.UseRegularExpression;   //使用正则表达式
                chbHistoryUrlEnabled.Checked = item.rule.HistoryUrlEnabled;     //是否允许历史网址重复
                chbHistoryUrlOptimization.Checked = item.rule.HistoryUrlOptimization;   //是否优化历史网址记录
                chbPickNextPageUrl.Checked = item.rule.PickNextPageUrl; //是否提取下一页的网址
                chbProccessScripts.Checked = item.rule.ProccessScripts; //提取下一页网址-是否提取（下一页标志）
                txtProccessScripts.Text = item.rule.NextPageUrlPattern; //下一页网址模板
                nudNextPageLargest.Value = item.rule.NextPageLargest;   //最大页数
                txtPickingStartFlag.Text = item.rule.PickingStartFlag;  //网址提取范围-开始标志
                txtPickingEndFlag.Text = item.rule.PickingEndFlag;  //网址提取范围-结束标志
                txtExtractionStartFlag.Text = item.rule.ExtractionStartFlag;    //内容采集范围-开始标志
                txtExtractionEndFlag.Text = item.rule.ExtractionEndFlag;    //内容采集范围-结束标志
                txtIterationFlag.Text = item.rule.IterationFlag;    //循环标志
                nudRestInterval.Value = item.rule.RestInterval;     //访问休息间隔（秒）
                cbxContentEncoding.Text = item.rule.ContentEncoding;    //内容编码
                txtNextLayerUrlReferer.Text = item.rule.NextLayerUrlReferer;    //下一层网址的Referer
                chbNextLayerUrlEncoded.Checked = item.rule.NextLayerUrlEncoded; //下一层网址已编码
                chbJsDecoding.Checked = item.rule.JsDecoding;   //对源文件进行JS解密
                cbxSkipToIfPickingFailed.Text = item.rule.SkipToIfPickingFailed;    //如果下一层网址提取失败则跳转到层？
                chbUsePluginOfVisit.Checked = item.rule.UsePluginOfVisit;   //使用插件请求本层URL
                chbUsePluginOfPickNextLayerUrls.Checked = item.rule.UsePluginOfPickNextLayerUrls;   //使用插件提取下一层网址]
                chbUsePluginOfPickNextPageUrl.Checked = item.rule.UsePluginOfPickNextPageUrl;   //使用插件提取下一页网址
                #endregion

                #region 是否终端页面
                if (item.rule.Terminal) {
                    rdoTerminal.Checked = true;
                    rdoCenterPage.Checked = false;
                } else {
                    rdoTerminal.Checked = false;
                    rdoCenterPage.Checked = true;
                }
                #endregion
            }
        }
        //监测源文件替换选项卡
        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl3.SelectedTab.Text.Equals("源文件替换")) {
                foreach (Utility.NavigationRuleItem item in livNavigationRule.SelectedItems) {
                    FrmReplace rp = new FrmReplace(item.rule.Replacements);
                    rp.ShowDialog();
                    item.rule.Replacements = rp.Replace;
                }
            }
        }
        #endregion

        #region 采集规则选项卡
        //新建
        private void btnExtrcCreate_Click(object sender, EventArgs e) {
            ResetExtractionTabElement();
        }
        //保存
        private void btnExtrcSave_Click(object sender, EventArgs e) {
            this.LivExtractionRule.Items.Add(new Utility.ExtractionRulesItem(GetExtraction(),
                this.LivExtractionRule.Items.Count + 1));
        }
        //删除
        private void btnExtrcDelete_Click(object sender, EventArgs e) {
            foreach (Utility.ExtractionRulesItem item in this.LivExtractionRule.SelectedItems) {
                this.LivExtractionRule.Items.Remove(item);
            }
        }
        //上移
        private void btnExtrcMoveUp_Click(object sender, EventArgs e) {

        }
        //下移
        private void btnExtrcMoveDown_Click(object sender, EventArgs e) {

        }
        //清空
        private void btnExtrcClear_Click(object sender, EventArgs e) {
            this.LivExtractionRule.Items.Clear();
        }
        //导入
        private void btnExtrcImport_Click(object sender, EventArgs e) {

        }
        //导出
        private void btnExtrcExport_Click(object sender, EventArgs e) {

        }
        //采集结果替换
        private void tabControl4_Selecting(object sender, TabControlCancelEventArgs e) {
            if (e.TabPageIndex == 4) {
                this._Replacement.Clear();
                FrmReplace r = new FrmReplace();
                r.Text = "采集结果替换";
                r.ShowDialog();
            }
        }
        #endregion

        #region 采集结果选项卡
        private void btnResultSeting_Click(object sender, EventArgs e) {

        }
        #endregion

        #region 插件设置选项卡
        private void btnPluginBrowse_Click(object sender, EventArgs e) {

        }

        private void btnPluginSeting_Click(object sender, EventArgs e) {

        }
        #endregion
    }
}