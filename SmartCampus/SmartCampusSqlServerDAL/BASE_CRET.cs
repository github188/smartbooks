
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SmartCampus.IDAL;

    public class BASE_CRET : IBASE_CRET
    {
        #region IBASE_CRET 成员

        public bool Exists(int cretid)
        {
            throw new NotImplementedException();
        }

        public void Add(SmartCampus.Entity.BASE_CRET entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SmartCampus.Entity.BASE_CRET entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int cretid)
        {
            throw new NotImplementedException();
        }

        public SmartCampus.Entity.BASE_CRET GetEntity(int cretid)
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
