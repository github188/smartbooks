using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace SmartSpider.Config {
    /// <summary>
    /// 当增加一个导航地址时产生的事件委托
    /// </summary>
    public delegate void onSingleComplete(object sender, string url);

    /// <summary>
    /// 解析起始和导航规则
    /// </summary>
    public class ParseNavigationRules {
        public ParseNavigationRules(UrlListManager urlItem) {
            this._urlItem = urlItem;
        }

        /// <summary>
        /// 执行解析导航规则
        /// </summary>
        public void Exec() {
            StringCollection urls = new StringCollection();
            //解析起始地址            
            urls = ParseStartingUrl(this._urlItem.StartingUrlList, this._urlItem.PagedUrlPattern);

            //解析导航地址
            urls = ParseNavigationRuleItem(urls);

            //引发增加一条网址事件
            if (onSingleComplete != null) {
                this.onSingleComplete(this, "");
            }
        }

        //private
        
        /// <summary>
        /// 解析导航规则
        /// </summary>
        /// <param name="startingUrl">起始地址</param>
        /// <returns>导航地址</returns>
        private StringCollection ParseNavigationRuleItem(StringCollection startingUrl) {
            StringCollection urls = new StringCollection();

            foreach (string u in startingUrl) {
                foreach (NavigationRule rule in _urlItem.NavigationRules) {                    
                    if (rule.Terminal) {
                        //最终页面直接加入导航地址
                        urls.Add(u);
                    } else {
                        //发送Http请求获取导航地址
                    }
                }
            }

            return urls;
        }

        /// <summary>
        /// 解析起始地址Url
        /// </summary>
        /// <param name="commonUrl">普通Url地址</param>
        /// <param name="templateUrl">模板Url地址(分页递增模式地址)</param>
        /// <returns></returns>
        private StringCollection ParseStartingUrl(List<string> commonUrl, List<PagedUrlPatterns> templateUrl) {
            StringCollection urlList = new StringCollection();

            //先加载列表地址
            foreach (string url in commonUrl) {
                urlList.Add(url);
            }

            //加载模板网址
            //匹配：{[0-9,-]*} {100,1,-1}            
            foreach (PagedUrlPatterns pageUrl in templateUrl) {
                MatchCollection regexMatch = Regex.Matches(pageUrl.PagedUrlPattern, "{[0-9,-]*}");
                if (pageUrl.Format == PagedUrlPatternsMode.Increment) { //递增模式
                    for (double i = pageUrl.StartPage; i <= pageUrl.EndPage; i += pageUrl.Step) {
                        string url = pageUrl.PagedUrlPattern;
                        if (regexMatch.Count != 0) {
                            url = url.Replace(regexMatch[0].Value, i.ToString());
                        }
                        urlList.Add(url);
                    }
                } else if (pageUrl.Format == PagedUrlPatternsMode.Decreasing) { //递减模式
                    for (double i = pageUrl.EndPage; i >= pageUrl.StartPage; i -= pageUrl.Step) {
                        string url = pageUrl.PagedUrlPattern;
                        if (regexMatch.Count != 0) {
                            url = url.Replace(regexMatch[0].Value, i.ToString());
                        }
                        urlList.Add(url);
                    }
                }
            }
            return urlList;
        }

        /// <summary>
        /// 当增加一个导航地址时发生的事件
        /// </summary>
        private event onSingleComplete onSingleComplete;

        /// <summary>
        /// url列表
        /// </summary>
        private UrlListManager _urlItem;
        /// <summary>
        /// Http请求助手
        /// </summary>
        private HttpHelper _HttpHelper;
    }
}
