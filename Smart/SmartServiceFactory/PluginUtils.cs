
namespace Smart.ServiceFactory
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 插件Util
    /// </summary>
    public class PluginUtils
    {
        #region private fields
        /// <summary>
        /// 程序集名称
        /// </summary>
        private string assemblerName;
        /// <summary>
        /// 插件名称：不含命名空间
        /// </summary>
        private string pluginName; 
        /// <summary>
        /// 插件命名空间
        /// </summary>
        private string facadeNameSpace;
        /// <summary>
        /// 插件名称：含命名空间
        /// </summary>
        private string fullPluginName;
        #endregion

        /// <summary>
        /// 程序集名称
        /// </summary>
        public string AssemblerName
        {
            get
            {
                return assemblerName;
            }
            set
            {
                assemblerName = value;
            }
        }
        
        /// <summary>
        /// 插件名称
        /// 获取不带命名空间的类名,去除首字母"I"
        /// </summary>
        public string PluginName
        {
            get
            {
                return pluginName;
            }
            set
            {
                pluginName = value;
            }
        }
        /// <summary>
        /// 插件命名空间
        /// </summary>
        public string FacadeNameSpace
        {
            get
            {
                return facadeNameSpace;
            }
            set
            {
                facadeNameSpace = value;
            }
        }
        /// <summary>
        ///  带完整命名空间的插件名称   
        /// </summary>
        /// <returns></returns>
        public string FullPluginName
        {
            get
            {
                return fullPluginName;
            }
            set
            {
                fullPluginName = value;
            }
        }
        /// <summary>
        /// 分割类型名称
        /// 用于从对象类型获取对象名称
        /// 切除"I"的目的是由于面向接口
        /// 分割的结果可能是接口类，而非实现类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ConcisionTypeName<T>()
        {
            string key = typeof(T).Name.ToString();
            //key = key.Substring(key.LastIndexOf("."));
            key = key.TrimStart('.');
            if (key.Substring(0, 1).ToUpper() == "I")
            {
                key = key.Substring(1);
            }
            return key;
        }
    }
}
