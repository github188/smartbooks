using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SmartHyd.BLL
{
   public class BASE_HANDLING
    {
       private OracleDAL.BASE_HANDLING dal = new OracleDAL.BASE_HANDLING();
       /// <summary>
       /// 根据指定条件获取巡查处理情况列表
       /// </summary>
       /// <param name="strwhere"></param>
       /// <returns></returns>
        public DataTable GetList(string strwhere)
        {
            //
            DataSet ds = dal.GetList(strwhere);
            return ds.Tables[0];
        }
       /// <summary>
       /// 获取当前日期下记录的数量
       /// </summary>
       /// <returns></returns>
        public int getCount()
        {
            return dal.GetCount();
        }
        /// <summary>
        /// 添加巡查处理情况
        /// </summary>
        /// <param name="model">巡查处理情况实体</param>
        public int Add(Entity.BASE_HANDLING model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        /// <param name="HID"></param>
        /// <returns></returns>
        public bool Exists(decimal HID)
        {
            if (dal.Exists(HID))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据HID获取巡查处理情况实体数据
        /// </summary>
        /// <param name="HID">巡查处理情况编号</param>
        /// <returns></returns>
        public Entity.BASE_HANDLING Getmodel(decimal HID)
        {
            return dal.GetEntity(HID);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_HANDLING model)
        {
            if (dal.Update(model))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除日志数据
        /// </summary>
        /// <param name="HID"></param>
        /// <returns></returns>
        public bool Del(decimal HID)
        {
            return dal.Delete(HID);
        }
    }
}
