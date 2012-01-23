
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SmartCampus.IDAL;

    public class BASE_PHOTO : IBASE_PHOTO
    {
        #region IBASE_PHOTO 成员

        public bool Exists(int photoid)
        {
            throw new NotImplementedException();
        }

        public void Add(SmartCampus.Entity.BASE_PHOTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SmartCampus.Entity.BASE_PHOTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int photoid)
        {
            throw new NotImplementedException();
        }

        public SmartCampus.Entity.BASE_PHOTO GetEntity(int photoid)
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
