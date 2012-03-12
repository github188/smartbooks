
namespace Smart.ServiceFactory
{
    using System.Configuration;
    using System.IO;
    using System.Reflection;
    using System.Web;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// 插件配置数据的读取
    /// </summary>
    public class PluginConfig
    {
        /// <summary>
        /// 缓存配置对象
        /// </summary>
        private static XmlDocument doc = null;

        /// <summary>
        /// 加载插件配置数据
        /// 如果数据已经加载，则删除，重新加载
        /// 否则，直接加载数据
        /// </summary>
        /// <returns>加载的XML配置:XmlDocument</returns>
        public static XmlDocument LoadPluginData()
        {
            string fileName = GetConfigFile();

            if (doc == null)
                doc = new XmlDocument();
            else
                doc.RemoveAll();

            doc.Load(fileName);
            return doc;
        }

        /// <summary>
        /// 获取已经加载的插件数据
        /// 
        /// 如果未加载，则直接加载
        /// </summary>   
        /// <returns>加载的XML配置:XmlDocument</returns>
        public static XmlDocument GetPluginData()
        {
            if (doc == null)
                return LoadPluginData();
            else
                return doc;
        }

        /// <summary>
        /// 从ComponentFactory配置节点获取插件信息
        /// </summary>
        /// <param name="nodeName">配置节点名称</param>
        /// <returns>配置对象PluginUtils</returns>
        public static PluginUtils GetComponentAssemblerInfo(string nodeName)
        {
            if (doc == null)
                GetPluginData();

            XmlNode root = doc.DocumentElement;
            XmlNode node = root.SelectSingleNode("ComponentFactory/" + nodeName);
            PluginUtils util = new PluginUtils();
            util.AssemblerName = node.Attributes["LoadFromAssembly"].Value;
            util.FacadeNameSpace = node.Attributes["FacadeNameSpace"].Value;
            return util;
        }

        /// <summary>
        /// 获取配置文件名（带全路径）
        /// </summary>
        /// <returns>配置文件名</returns>
        private static string GetConfigFile()
        {
            string fileName = ConfigurationManager.AppSettings["PluginConfig"];
            fileName = System.Web.HttpContext.Current.Server.MapPath(fileName);
            if (fileName != null && fileName.Trim() != "" && File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                string path = "~/PluginConfig.xml";
                return System.Web.HttpContext.Current.Server.MapPath(path);
            }
        }
    }
}
