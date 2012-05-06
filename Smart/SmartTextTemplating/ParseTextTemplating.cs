using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.VisualStudio.TextTemplating;

namespace Smart.TextTemplating
{
    public class ParseTextTemplating
    {
        #region 私有变量
        private string _templateContent;
        private string _saveRootPath;
        private string _startFlag;
        private string _extension;
        private List<object> _data = new List<object>();
        #endregion

        public ParseTextTemplating(string saveRootPath, string startFlag, string extension, List<object> data, string templatefilePath)
        {
            this._saveRootPath = saveRootPath;
            this._startFlag = startFlag;
            this._extension = extension;
            this._data = data;

            if (string.IsNullOrEmpty(_saveRootPath))
            {
                _saveRootPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            if (string.IsNullOrEmpty(_extension))
            {
                _extension = ".html";
            }
            if (string.IsNullOrEmpty(templatefilePath) || !File.Exists(templatefilePath))
            {
                this._templateContent = "";
            }
            else
            {
                this._templateContent = File.ReadAllText(templatefilePath);
            }
        }

        public void Parse()
        {
            foreach (object key in _data)
            {
                SmartTextTemplatingEngineHost host = new SmartTextTemplatingEngineHost();
                host.Session = new TextTemplatingSession();
                host.Session["data"] = key;
                Engine engine = new Engine();
                string content = engine.ProcessTemplate(_templateContent, host);
                if (!string.IsNullOrEmpty(content) && host.Errors.Count == 0)
                {
                    string filePath = string.Format("{0}{1}{2}{3}",
                        _saveRootPath,
                        _startFlag,
                        DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString("d4"),
                        _extension);
                    File.WriteAllText(filePath, content, Encoding.UTF8);
                }

                foreach (CompilerError er in host.Errors)
                {
                    File.AppendAllText(_saveRootPath + "error.txt",
                        er.ToString() + "\r\n\r\n",
                        Encoding.UTF8);
                }
            }
        }
    }
}
