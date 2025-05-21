using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Application.Interfaz
{
    public interface IGestionUOW
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        int Save();
    }
}
