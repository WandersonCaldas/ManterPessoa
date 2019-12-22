using PessoaCore.BO.Response;
using PessoaCore.Model;
using PessoaCore.ViewModel;
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

        public Estado Alterar(Estado obj)
        {
            try
            {
                string sql = "UPDATE tbl_estado SET txt_estado = '" + obj.txt_estado.Trim() + "', txt_sigla = '" + 
                    obj.txt_sigla.Trim() + "' WHERE cod_estado = " + obj.cod_estado;
                _db.Database.ExecuteSqlCommand(sql);            
                obj.status = ResponseStatus.SUCESSO.Texto;
            }
            catch (Exception ex)
            {
                obj.status = ResponseStatus.FALHA.Texto;
                obj.mensagem = ResponseErro.ErroOperacao(ex);
            }
            return obj;
        }

        public Estado Inserir(Estado obj)
        {
            try
            {
                string sql = "INSERT INTO tbl_estado(txt_estado, txt_sigla) VALUES('" + obj.txt_estado.Trim() + "','" + obj.txt_sigla.Trim() + "'); SELECT SCOPE_IDENTITY()";                
                obj.cod_estado = Convert.ToInt32(_db.Database.SqlQuery<decimal>(sql).Single());
                obj.status = ResponseStatus.SUCESSO.Texto;
            } catch (Exception ex)
            {
                obj.status = ResponseStatus.FALHA.Texto;
                obj.mensagem = ResponseErro.ErroOperacao(ex);
            }            
            return obj;
        }

        public Estado Excluir(Estado obj)
        {
            try
            {
                _db.Database.ExecuteSqlCommand("DELETE tbl_estado WHERE cod_estado = " + obj.cod_estado);
                obj.status = ResponseStatus.SUCESSO.Texto;
            }
            catch (Exception ex)
            {
                obj.status = ResponseStatus.FALHA.Texto;
                obj.mensagem = ResponseErro.ErroOperacao(ex);
            }            
            return obj;
        }

        public void Dispose()
        {            
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
