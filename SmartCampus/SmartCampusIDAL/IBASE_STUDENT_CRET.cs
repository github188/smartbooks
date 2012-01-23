using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_STUDENT_CRET : IDALBase
    {
        bool Exists(int studentcretid);
        void Add(BASE_STUDENT_CRET entity);
        bool Update(BASE_STUDENT_CRET entity);
        bool Delete(int studentcretid);
        BASE_STUDENT_CRET GetEntity(int studentcretid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
