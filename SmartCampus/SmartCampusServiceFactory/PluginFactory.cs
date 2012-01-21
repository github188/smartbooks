
namespace SmartCampus.ServiceFactory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;
    using System.Reflection;

    /// <summary>
    /// 泛型插件工厂
    /// 注意：缓存的对象，由插件工厂返回时，是同一个对象，
    ///       如果要new多个对象，需要使用GetPluginNew()
    /// </summary>
    /// <typeparam name="T">泛型对象</typeparam>
    /*public*/ internal static class PluginFactory<T>// where T : new()
    {
        #region private fields
        /// <summary>
        /// 缓存对象工厂
        /// </summary>
        private static Hashtable cache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 缓存对象互斥量
        /// </summary>
        private static readonly object syncObj = new object();
        #endregion
        /// <summary>
        /// 构造
        /// </summary>
        static PluginFactory()
        {  
        
        }   
        /// <summary>
        /// 获取指定类型插件
        /// 如果没有Cache，则Create
        /// </summary>
        /// <returns>构造的对象</returns>
        public static T GetPlugin()
        {
            string key = PluginUtils.ConcisionTypeName<T>(); 
            T plugin = (T)cache[key];

            lock (syncObj)
            {
                if (null == plugin)
                {                         
                    plugin = BuildPlugin();  
                    if (plugin != null)
                        cache[key] = plugin;
                }
            }
            return plugin;
        }
        /// <summary>
        /// 获取新插件对象
        /// </summary>
        /// <returns>构造的对象</returns>
        public static T GetPluginNew()
        {
            return (T)System.Activator.CreateInstance(GetPlugin().GetType());
        }

        #region private 
        /// <summary>
        /// 构造插件
        /// </summary>
        /// <returns>构造的对象</returns>
        private static T BuildPlugin()
        {
            return (T)PluginBuilder.GetPlugin(typeof(T));
        }
        #endregion

    }
}
