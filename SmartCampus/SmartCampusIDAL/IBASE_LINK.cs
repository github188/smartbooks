using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_LINK : IDALBase
    {
        bool Exists(int linkid);
        void Add(BASE_LINK entity);
        bool Update(BASE_LINK entity);
        bool Delete(int linkid);
        BASE_LINK GetEntity(int linkid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
