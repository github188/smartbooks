
namespace Smart.ServiceFactory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using System.Reflection;

    /// <summary>
    /// 插件Builder
    /// 构建插件对象，用于提供在运行时加载接口对象方法
    /// </summary>
    public sealed class PluginBuilder
    {
        /// <summary>
        /// 配置缓存对象
        /// </summary>
        private static XmlDocument xdConfig = null;

        /// <summary>
        /// 构造
        /// </summary>
        static PluginBuilder()
        {
            LoadPluginConfig();
        }

        /// <summary>
        /// 获取指定类型的对象
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Object GetPlugin(Type t)
        {
            if (xdConfig == null)
                throw new ConfigNotFindException("PluginConfig未加载！");

            XmlNode root = xdConfig.DocumentElement;
            XmlNode Node = null;
            try
            {
                Node = root.SelectSingleNode("InterfaceMapping/" + t.Name);
            }
            catch (TypeInitializationException)
            {
                return null;
            }

            if (Node != null)
            {
                System.Runtime.Remoting.ObjectHandle objHandle = null;
                objHandle = System.Activator.CreateInstance(Node.Attributes["LoadFromAssembly"].Value, Node.InnerText);
                return objHandle.Unwrap();
            }
            else
                return null;
        }

        /// <summary>
        /// 从指定程序集加载指定类型对象
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <param name="typeName">类名称</param>
        /// <returns></returns>
        public static Object GetPlugin(string assemblyName, string typeName)
        {
            System.Runtime.Remoting.ObjectHandle objHandle = System.Activator.CreateInstance(assemblyName, typeName);
            if (objHandle != null)
                return objHandle.Unwrap();
            else
                throw new ApplicationException("从程序集" + assemblyName + "反射对象" + typeName + "时，构件对象为NULL");
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <returns></returns>
        public static void LoadPluginConfig()
        {
            xdConfig = PluginConfig.GetPluginData();
        }
    }
}

 
