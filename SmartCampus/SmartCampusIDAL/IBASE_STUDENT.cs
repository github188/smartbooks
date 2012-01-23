using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_STUDENT : IDALBase
    {
        bool Exists(int studentid);
        void Add(BASE_STUDENT entity);
        bool Update(BASE_STUDENT entity);
        bool Delete(int studentid);
        BASE_STUDENT GetEntity(int studentid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
