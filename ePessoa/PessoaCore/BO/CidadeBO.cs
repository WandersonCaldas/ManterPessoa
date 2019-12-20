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
    public class CidadeBO
    {
        private CidadeDAO db = new CidadeDAO();        
        public List<Cidade> Listar()
        {
            List<Cidade> retorno = Mapper.Map<List<tbl_cidade>, List<Cidade>>(db.Listar());
            return retorno;
        }

        public Cidade BuscarPorId(int id)
        {
            return Mapper.Map<tbl_cidade, Cidade>(db.BuscarPorId(id));
        }

        public Cidade Inserir(Cidade obj)
        {

            using (EstadoDAO dbEstado = new EstadoDAO())
            {
                if(dbEstado.BuscarPorId(obj.cod_estado) == null)
                {
                    obj.status = ResponseStatus.FALHA.Texto;
                    obj.mensagem = ResponseMensagem.MN002.TextoFormatado("ESTADO " + obj.cod_estado);
                    return obj;
                }                
            }
            if (db.Listar().Where(x => x.cod_estado == obj.cod_estado && x.txt_cidade.Trim().ToUpper() == obj.txt_cidade.Trim().ToUpper()).ToList().Count > 0)
            {
                obj.status = ResponseStatus.FALHA.Texto;
                obj.mensagem = ResponseMensagem.MN003.TextoFormatado("CIDADE " + obj.txt_cidade);
                return obj;
            }
            return Mapper.Map<tbl_cidade, Cidade>(db.Inserir(Mapper.Map<Cidade, tbl_cidade>(obj)));
        }

        public Cidade Alterar(Cidade obj)
        {
            using (EstadoDAO dbEstado = new EstadoDAO())
            {
                if (dbEstado.BuscarPorId(obj.cod_estado) == null)
                {
                    obj.status = ResponseStatus.FALHA.Texto;
                    obj.mensagem = ResponseMensagem.MN002.TextoFormatado("ESTADO " + obj.cod_estado);
                    return obj;
                }
            }
            if (db.Listar().Where(x => x.cod_cidade != obj.cod_cidade && x.cod_estado == obj.cod_estado && x.txt_cidade.Trim().ToUpper() == obj.txt_cidade.Trim().ToUpper()).ToList().Count > 0)
            {
                obj.status = ResponseStatus.FALHA.Texto;
                obj.mensagem = ResponseMensagem.MN003.TextoFormatado("CIDADE " + obj.txt_cidade);
                return obj;
            }
            return Mapper.Map<tbl_cidade, Cidade>(db.Alterar(Mapper.Map<Cidade, tbl_cidade>(obj)));            
        }

        public Cidade Excluir(Cidade obj)
        {
            return Mapper.Map<tbl_cidade, Cidade>(db.Excluir(Mapper.Map<Cidade, tbl_cidade>(obj)));
        }
    }
}
