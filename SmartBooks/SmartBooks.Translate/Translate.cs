namespace SmartBooks.Translate
{
    /// <summary>
    /// 语言结构
    /// </summary>
    public struct LanguageStructure
    {
        /// <summary>
        /// 原始语言
        /// </summary>
        public string OriginalText { get; set; }
        /// <summary>
        /// 译文
        /// </summary>
        public string Translation { get; set; }
    }

    /// <summary>
    /// 翻译成功委托
    /// </summary>
    /// <param name="langeuage">语言结构</param>
    public delegate void Sucess(LanguageStructure langeuage);
    /// <summary>
    /// 翻译失败委托
    /// </summary>
    /// <param name="error">错误消息</param>
    public delegate void Error(string error);
}