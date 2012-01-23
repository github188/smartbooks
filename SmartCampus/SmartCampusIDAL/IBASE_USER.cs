using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_USER : IDALBase
    {
        bool Exists(int userid);
        void Add(BASE_USER entity);
        bool Update(BASE_USER entity);
        bool Delete(int userid);
        BASE_USER GetEntity(int userid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
