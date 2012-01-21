//调用示例IAreaService area = ComponentFactory<IAreaService>.GetBLLPlugin();
namespace SmartCampus.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 服务接口基类
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// 服务描述
        /// </summary>
        string Description
        {
            get;
        }
    }
}
