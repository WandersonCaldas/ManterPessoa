using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PessoaCore.Model;
using PessoaCore.ViewModel;
using AutoMapper;
using PessoaCore.DAO;

namespace PessoaCore.BO
{
    public class EstadoBO
    {
        private EstadoDAO db = new EstadoDAO();
        public List<Estado> Listar()
        {            
            List<Estado> retorno = Mapper.Map<List<tbl_estado>, List<Estado>>(db.Listar());
            return retorno;
        }

        public Estado BuscarPorId(int id)
        {            
            return Mapper.Map<tbl_estado, Estado>(db.BuscarPorId(id)); 
        }
    }
}
