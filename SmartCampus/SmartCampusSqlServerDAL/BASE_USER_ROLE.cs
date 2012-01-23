
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SmartCampus.IDAL;

    public class BASE_USER_ROLE : IBASE_USER_ROLE
    {
        #region IBASE_USER_ROLE 成员

        public bool Exists(int roleid)
        {
            throw new NotImplementedException();
        }

        public void Add(SmartCampus.Entity.BASE_USER_ROLE entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SmartCampus.Entity.BASE_USER_ROLE entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int roleid)
        {
            throw new NotImplementedException();
        }

        public SmartCampus.Entity.BASE_USER_ROLE GetEntity(int roleid)
        {
            throw new NotImplementedException();
        }

        public DataSet GetList(string strWhere)
        {
            throw new NotImplementedException();
        }

        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
