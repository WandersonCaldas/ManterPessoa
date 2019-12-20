using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PessoaCore.Model;
using PessoaCore.ViewModel;
using AutoMapper;
using PessoaCore.DAO;
using System.Data.Entity;

namespace PessoaCore.DAO
{
    public class CidadeDAO
    {
        private DbPessoaEntities _db = new DbPessoaEntities();

        public List<tbl_cidade> Listar()
        {
            return _db.tbl_cidade.ToList();
        }

        public tbl_cidade BuscarPorId(int id)
        {
            return _db.tbl_cidade.Find(id);
        }

        public tbl_cidade Inserir(tbl_cidade obj)
        {
            _db.tbl_cidade.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public tbl_cidade Alterar(tbl_cidade obj)
        {
            string sql = "UPDATE tbl_cidade SET txt_cidade = '" + obj.txt_cidade.Trim() + "', cod_estado = " + obj.cod_estado + 
                            " WHERE cod_cidade = " + obj.cod_cidade;
            _db.Database.ExecuteSqlCommand(sql);                       
            return obj;
        }

        public tbl_cidade Excluir(tbl_cidade obj)
        {
            _db.Database.ExecuteSqlCommand("DELETE tbl_cidade WHERE cod_cidade = " + obj.cod_cidade);        
            return obj;
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
