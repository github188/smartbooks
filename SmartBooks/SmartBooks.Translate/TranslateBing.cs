using System;
using System.Collections.Generic;
using System.Text;
using Bing;

namespace SmartBooks.Translate
{
    /// <summary>
    /// Bing翻译API
    /// </summary>
    public class TranslateBing
    {
        /// <summary>
        /// 翻译成功时执行的事件
        /// </summary>
        public event Sucess On_Sucess;
        /// <summary>
        /// 翻译失败时执行的事件
        /// </summary>
        public event Error On_Error;
        /// <summary>
        /// 应用Appid
        /// </summary>
        private string _appID = "B692A148D1624C4E3C1248C8E5DDC209E524D2C4";

        /// <summary>
        /// 翻译
        /// </summary>
        /// <param name="language">语言结构</param>
        public void Translate(LanguageStructure language)
        {
            SearchRequest searchRequest = new SearchRequest();
            searchRequest.AppId = _appID;
            searchRequest.Query = language.OriginalText;
            searchRequest.Market = "en-US"; 
            TranslationRequest transRequest = new TranslationRequest();
            transRequest.SourceLanguage = "En";     //English
            transRequest.TargetLanguage = "zh-CHS"; //China
            TranslationResponse response = API.Translation(searchRequest, transRequest);
            if (response.TranslationResults.Count > 0)
            {
                language.Translation = response.TranslationResults[0].TranslatedTerm;
                On_Sucess(language);
            }
            else
            {
                On_Error("Error");
            }
        }
    }
}