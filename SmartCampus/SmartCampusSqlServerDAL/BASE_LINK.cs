
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SmartCampus.IDAL;

    public class BASE_LINK : IBASE_LINK
    {
        #region IBASE_LINK 成员

        public bool Exists(int linkid)
        {
            throw new NotImplementedException();
        }

        public void Add(SmartCampus.Entity.BASE_LINK entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SmartCampus.Entity.BASE_LINK entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int linkid)
        {
            throw new NotImplementedException();
        }

        public SmartCampus.Entity.BASE_LINK GetEntity(int linkid)
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
