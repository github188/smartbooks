using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_PHOTO : IDALBase
    {
        bool Exists(int photoid);
        void Add(BASE_PHOTO entity);
        bool Update(BASE_PHOTO entity);
        bool Delete(int photoid);
        BASE_PHOTO GetEntity(int photoid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
