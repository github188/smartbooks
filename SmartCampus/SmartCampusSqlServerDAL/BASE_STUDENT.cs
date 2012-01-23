
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SmartCampus.IDAL;

    public class BASE_STUDENT : IBASE_STUDENT
    {
        #region IBASE_STUDENT 成员

        public bool Exists(int studentid)
        {
            throw new NotImplementedException();
        }

        public void Add(SmartCampus.Entity.BASE_STUDENT entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SmartCampus.Entity.BASE_STUDENT entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int studentid)
        {
            throw new NotImplementedException();
        }

        public SmartCampus.Entity.BASE_STUDENT GetEntity(int studentid)
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
