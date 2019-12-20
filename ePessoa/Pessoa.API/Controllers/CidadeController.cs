using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PessoaCore.Model;
using PessoaCore.BO;
using PessoaCore.ViewModel;
using PessoaCore.BO.Response;

namespace Pessoa.API.Controllers
{
    public class CidadeController : ApiController
    {
        private DbPessoaEntities db = new DbPessoaEntities();
        private CidadeBO _regra = new CidadeBO();

        // GET: api/Cidade
        public IList<Cidade> Gettbl_cidade()
        {
            return _regra.Listar();
        }

        // GET: api/Cidade/5
        [ResponseType(typeof(Cidade))]
        public IHttpActionResult Gettbl_cidade(int id)
        {
            Cidade retorno = _regra.BuscarPorId(id);

            return Ok(retorno);            
        }

        // PUT: api/Cidade/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_cidade(int id, Cidade obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cidade c = _regra.BuscarPorId(id);
            if (c == null)
            {
                return NotFound();
            }

            obj.cod_cidade = id;            

            Cidade retorno = new Cidade();
            retorno = _regra.Alterar(obj);
            
            return Ok(retorno);
        }

        // POST: api/Cidade
        [ResponseType(typeof(Cidade))]
        public IHttpActionResult Posttbl_cidade(Cidade obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            

            Cidade retorno = new Cidade();
            retorno = _regra.Inserir(obj);

            if (retorno.status != null && !retorno.status.Equals(ResponseStatus.SUCESSO.Texto)) {                
                return Ok(retorno);
            }

            return CreatedAtRoute("DefaultApi", new { id = retorno.cod_cidade }, obj);
        }

        // DELETE: api/Cidade/5
        [ResponseType(typeof(Cidade))]
        public IHttpActionResult Deletetbl_cidade(int id)
        {
            Cidade obj = _regra.BuscarPorId(id);            
            if (obj == null)
            {
                return NotFound();
            }

            Cidade retorno = new Cidade();
            retorno = _regra.Excluir(obj);            

            return Ok(obj);
        }

        protected override void Dispose(bool disposing)
        {
            PessoaCore.DAO.EstadoDAO d = new PessoaCore.DAO.EstadoDAO();
            d.Dispose();
            GC.SuppressFinalize(this);
        }
        
    }
}