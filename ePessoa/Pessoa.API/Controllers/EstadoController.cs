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
             
        protected override void Dispose(bool disposing)
        {
            PessoaCore.DAO.EstadoDAO d = new PessoaCore.DAO.EstadoDAO();
            d.Dispose();
            GC.SuppressFinalize(this);
        }      
    }
}