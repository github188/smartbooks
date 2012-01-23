using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_USER_ROLE : IDALBase
    {
        bool Exists(int roleid);
        void Add(BASE_USER_ROLE entity);
        bool Update(BASE_USER_ROLE entity);
        bool Delete(int roleid);
        BASE_USER_ROLE GetEntity(int roleid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
