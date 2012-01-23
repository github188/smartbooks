using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_CRET_LEVAL : IDALBase
    {
        bool Exists(int cretlevalid);
        void Add(BASE_CRET_LEVAL entity);
        bool Update(BASE_CRET_LEVAL entity);
        bool Delete(int cretlevalid);
        BASE_CRET_LEVAL GetEntity(int cretlevalid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
