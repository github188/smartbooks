﻿namespace SmartSpider.Utility {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using Config;

    public class NavigationRuleItem : ListViewItem {
        /// <summary>
        /// 导航规则
        /// </summary>
        public NavigationRule rule;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rule">导航规则</param>
        /// <param name="index">层析编号</param>
        public NavigationRuleItem(NavigationRule rule, int index) {
            this.SubItems.Clear();
            this.rule = rule;
            this.Text = index.ToString();
            this.ImageKey = "";
            this.SubItems.Add(new ListViewSubItem(this, rule.Name));    //层次名称
            this.SubItems.Add(new ListViewSubItem(this, rule.Terminal.ToString())); //最终页面            
            this.SubItems.Add(new ListViewSubItem(this, rule.PickNextLayerUrls.ToString()));    //提取下一层网址
            this.SubItems.Add(new ListViewSubItem(this, rule.NextLayerUrlPattern)); //下一层网址模板
            this.SubItems.Add(new ListViewSubItem(this, rule.PickNextPageUrl.ToString()));  //提取下一页
        }
    }
}