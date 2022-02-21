using AutoMapper;
using Dominio.Advogado;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Implementacao;
using System;
using System.Collections.Generic;
using Teste_CGV.ViewModels;

namespace Teste_CGV.Controllers
{
    //[Authorize]
    public class AdvogadoController : Controller
    {
        private readonly IAdvogadoRepositorio _repo;
        IMapper _mapper;

        public AdvogadoController(IAdvogadoRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }



        // GET: AdvogadoController
        public ActionResult Index()
        {
            var advogadoViewModel = _mapper.Map<IEnumerable<Advogado>, IEnumerable<AdvogadoViewModel>>(_repo.GetAll());
            return View(advogadoViewModel);
        }

        // GET: AdvogadoController/Details/5
        public ActionResult Details(Guid id)
        {
            Advogado _result = _repo.GetbyId(id);
            var advogadoVM = _mapper.Map<Advogado, AdvogadoViewModel>(_result);
            return View(advogadoVM);
        }

        // GET: AdvogadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvogadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdvogadoViewModel advogado)
        {
            if (!ModelState.IsValid)
                throw new System.Exception();

            try
            {
                var advogadoDomain = _mapper.Map<AdvogadoViewModel, Advogado>(advogado);
                _repo.Add(advogadoDomain);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(advogado);
            }
        }

        // GET: AdvogadoController/Edit/5
        public ActionResult Edit(Guid id)
        {
            Advogado _result = _repo.GetbyId(id);
            var advogadoVM = _mapper.Map<Advogado, AdvogadoViewModel>(_result);
            return View(advogadoVM);
        }

        // POST: AdvogadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdvogadoViewModel advogado)
        {
            if (!ModelState.IsValid)
                throw new System.Exception();

            try
            {
                var advogadoDomain = _mapper.Map<AdvogadoViewModel, Advogado>(advogado);
                _repo.Update(advogadoDomain);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(advogado);
            }
        }

        // GET: AdvogadoController/Delete/5
        public ActionResult Delete(Guid id)
        {
            Advogado _result = _repo.GetbyId(id);
            var advogadoVM = _mapper.Map<Advogado, AdvogadoViewModel>(_result);
            return View(advogadoVM);
        }

        // POST: AdvogadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AdvogadoViewModel advogado)
        {
            if (String.IsNullOrWhiteSpace(advogado.ID.ToString()))
                throw new System.Exception();

            try
            {
                var advogadoDomain = _mapper.Map<AdvogadoViewModel, Advogado>(advogado);
                _repo.Delete(advogadoDomain);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(advogado);
            }
        }
    }
}
