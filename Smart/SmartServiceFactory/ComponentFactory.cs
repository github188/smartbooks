
namespace Smart.ServiceFactory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;
    using System.Reflection;
    using System.Configuration;
    using System.Xml;

    /// <summary>
    /// 从组件工厂配置节点获取实例化对象
    /// 通过对组件的加载，来实例化插件
    /// 
    /// 约束： 实现必须和接口同名
    ///        例如 INewsService的实现类必须是NewsService
    ///        否则，如果没对接口进行配置，从组件中反射出对象是接口，非实现
    /// </summary>
    /// <typeparam name="T">构造的类型</typeparam>
    public static class ComponentFactory<T>
    {
        /// <summary>
        /// 获取业务逻辑插件
        /// 
        /// 从节点ComponentFactory加载
        /// </summary>
        /// <returns>构造的对象</returns>
        public static T GetBLLPlugin()
        {
            return GetPlugin("BLL");
        }

        /// <summary>
        /// 获取数据访问插件
        /// 
        /// 从节点ComponentFactory加载
        /// </summary>
        /// <returns>构造的对象</returns>
        public static T GetDALPlugin()
        {
            return GetPlugin("DAL");
        }

        /// <summary>
        /// 通过反射构造对象
        /// </summary>
        /// <param name="componentNodeName">配置节点名称</param>
        /// <returns>构造的对象</returns>
        private static T GetPlugin(string componentNodeName)
        {
            T plugin = (T)PluginBuilder.GetPlugin(typeof(T));

            if (null == plugin)
            {
                string key = PluginUtils.ConcisionTypeName<T>();
                plugin = GetPluginFromComponentNode(componentNodeName, key);
            }
            return plugin;
        }

        /// <summary>
        /// 从ComponentFactory配置节点建立对象
        /// </summary>
        /// <param name="componentNodeName">配置节点名称</param>
        /// <param name="typeName">反射对象类型：不含父路径</param>
        /// <returns>构造的对象</returns>
        private static T GetPluginFromComponentNode(string componentNodeName, string typeName)
        {
            PluginUtils util = PluginConfig.GetComponentAssemblerInfo(componentNodeName);
            util.PluginName = typeName;
            util.FullPluginName = util.FacadeNameSpace + "." + util.PluginName;
            return (T)PluginBuilder.GetPlugin(util.AssemblerName, util.FullPluginName);
        }
    }
}
