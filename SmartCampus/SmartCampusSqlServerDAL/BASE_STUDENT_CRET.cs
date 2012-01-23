
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SmartCampus.IDAL;

    public class BASE_STUDENT_CRET : IBASE_STUDENT_CRET
    {
        #region IBASE_STUDENT_CRET 成员

        public bool Exists(int studentcretid)
        {
            throw new NotImplementedException();
        }

        public void Add(SmartCampus.Entity.BASE_STUDENT_CRET entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SmartCampus.Entity.BASE_STUDENT_CRET entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int studentcretid)
        {
            throw new NotImplementedException();
        }

        public SmartCampus.Entity.BASE_STUDENT_CRET GetEntity(int studentcretid)
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
