using Newtonsoft.Json;
using ParceriaWebAPI.Dominio.Entidades;
using ParceriaWebAPI.Repositorio.Interfaces;
using ParceriaWebAPI.Repositorio.Repositorios;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ParceriasWebAPI.Controllers
{
    [RoutePrefix("api/parceria")]
    public class ParceriaController : ApiController
    {
        private IParceriaRepository _Db;
        public ParceriaController()
        {
            _Db = new ParceriaRepository();
        }


        [HttpGet]
        [Route("RetornaLista")]
        public string RetornaLista()
        {
            return JsonConvert.SerializeObject(_Db.RetornaLista());
        }

        [HttpGet]
        [Route("PesquisaParceria/{pesquisa}")]
        public string PesquisaParceria(string pesquisa)
        {
            return JsonConvert.SerializeObject(_Db.PesquisaParceria(pesquisa));
        }

        [HttpGet]
        [Route("RetornaParceria/{codigo}")]
        public string RetornaParceria(int codigo)
        {
            return JsonConvert.SerializeObject(_Db.RetornaParceria(codigo));
        }

        [HttpGet]
        [Route("CadastraLike/{codigoParceria}")]
        public string CadastraLike(int codigoParceria)
        {
            try
            {
                _Db.CadastraLike(codigoParceria);

                return "Cadastro Realizado com sucesso";
            }
            catch (Exception e)
            {
                return "Houve erro ao cadastrar Like! "+e.Message;
            }
        }
    }
}