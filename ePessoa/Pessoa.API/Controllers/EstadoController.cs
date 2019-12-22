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
using PessoaCore.ViewModel;
using PessoaCore.BO;
using PessoaCore.BO.Response;

namespace Pessoa.API.Controllers
{
    public class EstadoController : ApiController
    {        
        private EstadoBO _regra = new EstadoBO();

        // GET: api/Estado
        public List<Estado> Gettbl_estado()
        {
            return _regra.Listar();
        }

        // GET: api/Estado/5
        [ResponseType(typeof(tbl_estado))]
        public IHttpActionResult Gettbl_estado(int id)
        {
            Estado retorno = _regra.BuscarPorId(id);            

            return Ok(retorno);
        }

        [ResponseType(typeof(Estado))]
        public IHttpActionResult Posttbl_estado(Estado obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Estado retorno = new Estado();
            retorno = _regra.Inserir(obj);

            if (!retorno.status.Equals(ResponseStatus.SUCESSO.Texto))
            {
                return Ok(retorno);
            }

            return CreatedAtRoute("DefaultApi", new { id = retorno.cod_estado }, obj);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_cidade(int id, Estado obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            

            obj.cod_estado = id;

            Estado retorno = new Estado();
            retorno = _regra.Alterar(obj);

            return Ok(retorno);
        }

        [ResponseType(typeof(Estado))]
        public IHttpActionResult Deletetbl_estado(int id)
        {
            Estado obj = _regra.BuscarPorId(id);
            if (obj == null)
            {
                return NotFound();
            }

            Estado retorno = new Estado();
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