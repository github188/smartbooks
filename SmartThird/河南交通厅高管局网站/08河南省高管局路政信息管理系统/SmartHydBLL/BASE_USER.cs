using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL
{
    public class BASE_USER
    {
        private OracleDAL.BASE_USER dal = new OracleDAL.BASE_USER();
        /// <summary>
        /// 确定用户是否存在
        /// </summary>
        /// <param name="USERID"></param>
        /// <returns></returns>
        public bool exists(decimal USERID)
        {
            return dal.Exists(USERID);
        }
        /// <summary>
        /// 查找用户名是否重复
        /// </summary>
        /// <param name="username"></param>
        /// <returns>true:用户名已存在</returns>
        public bool FindUserName(string username)
        {
            if (GetList("USERNAME='" + username + "'").Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取所有用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUser()
        {
            return dal.GetAllList();
        }

        public int Add(Entity.BASE_USER model)
        {
           return dal.Add(model);
        }
        /// <summary>
        /// 根据指定条件查询用户数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere).Tables[0];
        }
        /// <summary>
        /// 根据用户编号获取用户实体信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public Entity.BASE_USER GetUser(int userId)
        {
            return dal.GetEntity(userId);
        }
        public Entity.BASE_USER GetUser(string username, string pwd)
        {
            Entity.BASE_USER model = new Entity.BASE_USER();
            var dt = dal.GetList(string.Format("USERNAME='{0}' AND USERPWD='{1}'",
                username,
                pwd)).Tables[0];
            if (dt != null && dt.Rows.Count != 0)
            {
                model.BIRTHDAY = (DateTime)dt.Rows[0]["BIRTHDAY"];
                model.DEGREE = dt.Rows[0]["DEGREE"].ToString();
                model.DEPTID = Convert.ToInt32(dt.Rows[0]["DEPTID"].ToString());
                model.FACE = dt.Rows[0]["FACE"].ToString();
                model.IDNUMBER = dt.Rows[0]["IDNUMBER"].ToString();
                model.JOBNUMBER = dt.Rows[0]["JOBNUMBER"].ToString();
                model.PARENTID = Convert.ToInt32(dt.Rows[0]["PARENTID"].ToString());
                model.PHONE = dt.Rows[0]["PHONE"].ToString();
                model.PHOTO = dt.Rows[0]["PHOTO"].ToString();
                model.PROF = dt.Rows[0]["PROF"].ToString();
                model.REMARK = dt.Rows[0]["REMARK"].ToString();
                model.SEX = Convert.ToInt32(dt.Rows[0]["SEX"].ToString());
                model.STSTUS = Convert.ToInt32(dt.Rows[0]["STSTUS"].ToString());
                model.USERID = Convert.ToInt32(dt.Rows[0]["USERID"].ToString());
                model.USERNAME = dt.Rows[0]["USERNAME"].ToString();
                model.USERPWD = dt.Rows[0]["USERPWD"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        public bool Update(Entity.BASE_USER user)
        {
            return dal.Update(user);
        }
        /// <summary>
        /// 从数据库中根据用户编号删除一条数据
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public bool Del(decimal UserID)
        {
            return dal.Delete(UserID);
        }
    }
}
