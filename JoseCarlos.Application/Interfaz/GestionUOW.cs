using JoseCarlos.Infraestructure.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace JoseCarlos.Application.Interfaz
{
    public class GestionUOW : IGestionUOW, IDisposable
    {
        private GestionContext _context;
        public GestionUOW(GestionContext context)
        {
            this._context = context;
        }
        public void BeginTransaction()
        {
            if (this._context.Database.CurrentTransaction != null)
                throw new TransactionException("No se puede iniciar, hay otra ya en curso");
            this._context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (this._context.Database.CurrentTransaction == null)
                throw new TransactionException("No se puede hacer coomit, no existe la transaccion");
            this._context.Database.CurrentTransaction.Commit();
        }

      

        public void Rollback()
        {
            if (this._context.Database.CurrentTransaction == null)
                throw new TransactionException("No se puede hacer rollback, no existe la transaccion");
            this._context.Database.CurrentTransaction.Rollback();
        }

        public int Save()
        {
            int rowsAffected = this._context.SaveChanges();
            this._context.DetachAllEntities();
            return rowsAffected;
        }

        public void Dispose()
        {
            if (this._context != null)
            {
                this._context.DisposeAsync();
            }
        }
    }
}
