using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_CRET_CROUP : IDALBase
    {
        bool Exists(int cretgroupid);
        void Add(BASE_CRET_CROUP entity);
        bool Update(BASE_CRET_CROUP entity);
        bool Delete(int cretgroupid);
        BASE_CRET_CROUP GetEntity(int cretgroupid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
