using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_PHOTO_GROUP : IDALBase
    {
        bool Exists(int groupid);
        void Add(BASE_PHOTO_GROUP entity);
        bool Update(BASE_PHOTO_GROUP entity);
        bool Delete(int groupid);
        BASE_PHOTO_GROUP GetEntity(int groupid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
