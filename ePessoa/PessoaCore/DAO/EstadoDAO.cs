using PessoaCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PessoaCore.DAO
{
    public class EstadoDAO : IDisposable
    {
        private DbPessoaEntities _db = new DbPessoaEntities();        

        public List<tbl_estado> Listar()
        {                 
            return _db.tbl_estado.ToList();
        }

        public tbl_estado BuscarPorId(int id)
        {
            return _db.tbl_estado.Find(id);
        }

        public void Dispose()
        {            
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
