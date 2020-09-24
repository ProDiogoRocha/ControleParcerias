using ControleDeParcerias.Data.Interfaces.Servicos;
using ControleDeParcerias.Web.Mappers;
using ControleDeParcerias.Web.ViewModels;
using ControleParcerias.Dominio.Entidades;
using System;
using System.Net;
using System.Web.Mvc;

namespace ControleDeParcerias.Web.Controllers
{
    public class ParceriaController : Controller
    {
        private readonly IParceriaService _parceriaService;
        private readonly ParceriaMapperProfile _parceriaMapperProfile;

        public ParceriaController(IParceriaService parceriaService)
        {
            _parceriaService = parceriaService;
            _parceriaMapperProfile = new ParceriaMapperProfile();
        }

        public ActionResult Index()
        {
            return View(_parceriaMapperProfile.EntityToViewModel(_parceriaService.GetTodos()));
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParceriaViewModel parceriaViewModel = _parceriaMapperProfile.MapperConfig.Map<Parceria, ParceriaViewModel>(_parceriaService.GetPorId(id));
            if (parceriaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(parceriaViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Titulo,Descricao,URLPagina,Empresa,DataInicio,DataTermino,QtdLikes,DataHoraCadastro")] ParceriaViewModel parceriaViewModel)
        {
            parceriaViewModel.DataHoraCadastro = DateTime.Now;
            if (ModelState.IsValid)
            {
                _parceriaService.Adicionar(_parceriaMapperProfile.MapperConfig.Map<ParceriaViewModel, Parceria>(parceriaViewModel));
                return RedirectToAction("Index");
            }

            return View(parceriaViewModel);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParceriaViewModel parceriaViewModel = _parceriaMapperProfile.MapperConfig.Map<Parceria, ParceriaViewModel>(_parceriaService.GetPorId(id));
            if (parceriaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(parceriaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Titulo,Descricao,URLPagina,Empresa,DataInicio,DataTermino,QtdLikes,DataHoraCadastro")] ParceriaViewModel parceriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _parceriaService.Atualizar(_parceriaMapperProfile.MapperConfig.Map<ParceriaViewModel, Parceria>(parceriaViewModel));
                return RedirectToAction("Index");
            }
            return View(parceriaViewModel);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            _parceriaService.Deletar(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public bool BuscarTituloParceria(string titulo)
        {
            return _parceriaService.VerificarNomeTitulo(titulo);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _parceriaService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
