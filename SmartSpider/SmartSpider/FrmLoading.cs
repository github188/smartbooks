namespace SmartSpider {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Xml.Serialization;
    using Config;

    public partial class FrmLoading : Form {
        public FrmLoading() {
            InitializeComponent();
            Task t = new Task();
            t.Name = "新浪新闻-国内";
            t.UrlListManager.PagedUrlPattern.Add(new PagedUrlPatterns() {
                PagedUrlPattern = @"http://roll.news.sina.com.cn/news/gjxw/hqqw/index_{1,1,5}.shtml",
                Format = PagedUrlPatternsMode.Increment,
                StartPage = 0,
                EndPage = 5,
                Step = 1
            });
            t.UrlListManager.NavigationRules.Add(new NavigationRule() {
                Name = "列表页",
                NextLayerUrlPattern = @"http://[a-z.]*\.sina\.com\.cn/w[0-9a-zA-Z-_/]*\.[a-z]+",
                ExtractionStartFlag = "<html>",
                ExtractionEndFlag = "</html>"
            });
            t.ExtractionRules.Add(new ExtractionRule() {
                Name = "标题",
                PreviousFlag = "<title>",
                FollowingFlag = "</title>"
            });
            t.ExtractionRules.Add(new ExtractionRule() {
                Name = "内容",
                PreviousFlag = @"<!-- 正文内容 begin -->",
                FollowingFlag = @"<!-- 分享 begin -->"
            });
            t.ExtractionRules.Add(new ExtractionRule() {
                Name = "网址",
                UrlAsResult = true
            });

            XmlSerializer xs = new XmlSerializer(typeof(Task));
            Stream readStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "task\\sin.xml", FileMode.Create, FileAccess.Write, FileShare.Write);
            xs.Serialize(readStream, t);
            readStream.Close();
            readStream.Dispose();
        }

        private void FrmLoading_Load(object sender, EventArgs e) {
            this.timerLoading.Interval = 1800;
            this.timerLoading.Start();
        }

        private void timerLoading_Tick(object sender, EventArgs e) {
            if (this.Opacity % 1 == 0) {
                this.Opacity += 0.001;
            } else {
                this.timerLoading.Stop();
                this.Hide();
                FrmMain main = new FrmMain();
                main.Show();
            }
        }
    }
}
