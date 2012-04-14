﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Net;

namespace SmartSpider.Config {
    /// <summary>
    /// 解析内容采集规则
    /// </summary>
    public class ParseExtractRoles {

        public ParseExtractRoles(List<ExtractionRule> rule, string htmlText, HttpWebResponse response) {
            this._excRule = rule;
            this._htmlText = htmlText;
            this._response = response;
        }

        /// <summary>
        /// 执行采集规则返回采集结果
        /// </summary>
        /// <returns>提取结果行</returns>
        public string[] Exec() {
            string[] result = new string[_excRule.Count];
            for (int i = 0; i < this._excRule.Count; i++) {
                result[i] = ExtractionColumn(this._excRule[i]);
            }
            return result;
        }

        /// <summary>
        /// 提取采集规则返回一个单元格
        /// </summary>
        /// <param name="rule">采集规则</param>
        /// <returns>采集结果</returns>
        private string ExtractionColumn(ExtractionRule r) {
            string result = _htmlText;

            //采集时间作为结果
            if (r.TimeAsResult) {
                return DateTime.Now.ToString();
            }
            //将固定值最为结果
            if (r.ConstantAsResult) {
                return r.ConstantValue;
            }
            //记录当前网址
            if (r.UrlAsResult) {
                return _response.ResponseUri.AbsoluteUri;
            }
            //响应头作为结果
            if (r.ResponseHeaderAsResult) {
                return _response.Headers[r.ResponseHeaderName];
            }
            //if(extractionRule.PostParametersAsResult) return this.HttpHelper.WebRequest.GetRequestStream();   //POST参数作为结果
            //if (extractionRule.LinkTextAsResult) return ""; //链接文本作为结果

            //截取内容
            result = SubString(result, r.PreviousFlag, r.FollowingFlag);

            //采集结果替换
            result = ResultReplace(result, r.Replacements);

            //过滤Html标记
            result = FilterHtmlMark(result, r.ReservedHtmlMarks);

            return result;
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="htmlText">源字符串</param>
        /// <param name="PreviousFlag">信息前标志</param>
        /// <param name="FollowingFlag">信息后标志</param>
        /// <returns>截取结果</returns>
        private string SubString(string htmlText, string PreviousFlag, string FollowingFlag) {
            string result = htmlText;
            int indexPreviousFlag = result.IndexOf(PreviousFlag);    //信息前标志
            int indexFollowingFlag = result.IndexOf(FollowingFlag);  //信息后标志
            int indexLength = indexFollowingFlag - indexPreviousFlag;
            if (indexLength > 1 && indexLength >= FollowingFlag.Length) {
                result = result.Substring(
                    indexPreviousFlag + PreviousFlag.Length,
                    indexLength - FollowingFlag.Length);
            }
            return result;
        }

        /// <summary>
        /// 采集结果替换
        /// </summary>
        /// <param name="htmlText">html文本</param>
        /// <param name="Replacement">替换元素</param>
        /// <returns>替换结果</returns>
        private string ResultReplace(string htmlText, List<Replacement> Replacement) {
            string result = htmlText;
            if (result.Length == 0) return result;
            foreach (Replacement r in Replacement) {
                if (r.UseRegex) {
                    // 使用正则表达式替换结果
                    MatchCollection matchs = Regex.Matches(result, r.OldValue);
                    foreach (Match match in matchs) {
                        result = result.Replace(match.Value, r.NewValue);
                    }
                } else {
                    //直接替换
                    result = result.Replace(r.OldValue, r.NewValue);
                }
            }

            return result;
        }

        /// <summary>
        /// 过滤Html标记
        /// </summary>
        /// <param name="htmlText">html文本</param>
        /// <returns>过滤结果</returns>
        private string FilterHtmlMark(string htmlText, List<HtmlMark> htmlMarks) {
            string result = htmlText;
            if (result.Length == 0) return result;
            //<p ([^>]+)>([^<]+)</p>
            List<HtmlMarkDictionary> element = new List<HtmlMarkDictionary>();
            foreach (HtmlMark htmlMark in htmlMarks) {
                MatchCollection matchs = Regex.Matches(result, htmlMark.RegexText, RegexOptions.IgnoreCase);
                foreach (Match match in matchs) {
                    HtmlMarkDictionary directory = new HtmlMarkDictionary();
                    directory.Index = match.Index;
                    directory.Text = match.Value;
                    element.Add(directory);
                }
            }
            if (element.Count != 0) {
                element.Sort();
                result = "";
                foreach (HtmlMarkDictionary elm in element) {
                    result += elm.Text;
                }
            }
            return result;
        }

        /// <summary>
        /// 采集规则
        /// </summary>
        private List<ExtractionRule> _excRule;
        /// <summary>
        /// Html文本
        /// </summary>
        private string _htmlText;
        /// <summary>
        /// http响应结果
        /// </summary>
        private HttpWebResponse _response;
    }
}
