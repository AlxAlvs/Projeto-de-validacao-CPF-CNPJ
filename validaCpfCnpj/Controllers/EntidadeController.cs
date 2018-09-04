using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using validaCpfCnpj.Filtros;
using validaCpfCnpj.Models;
using validaCpfCnpj.Repositorio;

namespace validaCpfCnpj.Controllers
{
    [RoutePrefix("api/entidade")]
    public class EntidadeController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Entidade entidade)
        {
            if (!CpfCnpjUtils.IsValid(entidade.CpfOuCnpj))
            {
                ModelState.AddModelError("", "O cpf ou cnpj é inválido");
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            EntidadeContexto.Add(entidade);
            return Request.CreateResponse(HttpStatusCode.Created, EntidadeContexto.ConsultarTodos());
        }

        [Route("cpf")]
        [HttpGet]
        public HttpResponseMessage GeraCpf()
        {
            {
                var cpf = CpfCnpjUtils.GerarCpf();
                return Request.CreateResponse(HttpStatusCode.OK, cpf);
            }
        }

        [Route("cnpj")]
        [HttpGet]
        public HttpResponseMessage GeraCnpj()
        {
            {
                var cnpj = CpfCnpjUtils.GerarCnpj();
                return Request.CreateResponse(HttpStatusCode.OK, cnpj);
            }
        }
    }
}
