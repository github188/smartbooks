using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_MENU : IDALBase
    {
        bool Exists(int menuid);
        void Add(BASE_MENU entity);
        bool Update(BASE_MENU entity);
        bool Delete(int menuid);
        BASE_MENU GetEntity(int menuid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
