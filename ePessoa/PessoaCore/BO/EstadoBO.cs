using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PessoaCore.Model;
using PessoaCore.ViewModel;
using AutoMapper;
using PessoaCore.DAO;
using PessoaCore.BO.Response;

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

        public Estado Inserir(Estado obj)
        {
            return db.Inserir(obj);
        }

        public Estado Alterar(Estado obj)
        {
            Estado e = BuscarPorId(obj.cod_estado);
            if (e == null)
            {
                obj.status = ResponseStatus.FALHA.Texto;
                obj.mensagem = ResponseMensagem.MN002.TextoFormatado("ESTADO");
                return obj;
            }
            return db.Alterar(obj);
        }

        public Estado Excluir(Estado obj)
        {
            return db.Excluir(obj);
        }
    }
}
