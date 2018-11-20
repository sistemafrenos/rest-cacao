using System;
using System.Collections.Generic;
using System.Linq;

namespace HK.BussinessLogic
{
    interface IUnitOfWork
    {
        //void Load(string id);
        //void Clone(object objeto);
        //void Delete(object objeto);
        //void Clear();
        string Save();
    }
}
