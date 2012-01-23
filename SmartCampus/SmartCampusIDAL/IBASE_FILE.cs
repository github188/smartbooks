using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_FILE : IDALBase
    {
        bool Exists(int fileid);
        void Add(BASE_FILE entity);
        bool Update(BASE_FILE entity);
        bool Delete(int fileid);
        BASE_FILE GetEntity(int fileid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
