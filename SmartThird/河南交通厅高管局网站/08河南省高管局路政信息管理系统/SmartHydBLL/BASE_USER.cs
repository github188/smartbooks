using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_USER {
        private OracleDAL.BASE_USER dal = new OracleDAL.BASE_USER();

        public DataTable GetAllUser() {
            return dal.GetAllList();
        }

        public void Add(Entity.BASE_USER model) {
            dal.Add(model);
        }

        public DataTable GetList(string strWhere)
        { 
          return dal.GetList(strWhere).Tables[0];
        }
        public Entity.BASE_USER GetUser(int userId) {
            return dal.GetEntity(userId);
        }

        public Entity.BASE_USER GetUser(string username, string pwd) {
            Entity.BASE_USER model = new Entity.BASE_USER();
            var dt = dal.GetList(string.Format("USERNAME='{0}' AND USERPWD='{1}'",
                username,
                pwd)).Tables[0];
            if (dt != null && dt.Rows.Count != 0) {
                model.BIRTHDAY = (DateTime)dt.Rows[0]["BIRTHDAY"];
                model.DEGREE = dt.Rows[0]["DEGREE"].ToString();
                model.DEPTID = Convert.ToInt32(dt.Rows[0]["DEPTID"].ToString());
                model.FACE = dt.Rows[0]["FACE"].ToString();
                model.IDNUMBER = dt.Rows[0]["IDNUMBER"].ToString();
                model.JOBNUMBER = dt.Rows[0]["JOBNUMBER"].ToString();
                model.PARENTID = Convert.ToInt32( dt.Rows[0]["PARENTID"].ToString());
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
            } else {
                return null;
            }            
        }
    }
}
