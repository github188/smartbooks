
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SmartCampus.IDAL;

    public class BASE_PHOTO_GROUP : IBASE_PHOTO_GROUP
    {
        #region IBASE_PHOTO_GROUP 成员

        public bool Exists(int groupid)
        {
            throw new NotImplementedException();
        }

        public void Add(SmartCampus.Entity.BASE_PHOTO_GROUP entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SmartCampus.Entity.BASE_PHOTO_GROUP entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int groupid)
        {
            throw new NotImplementedException();
        }

        public SmartCampus.Entity.BASE_PHOTO_GROUP GetEntity(int groupid)
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
