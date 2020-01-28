using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _07_Fiap.Web.AspNet.Models;
using _07_Fiap.Web.AspNet.Persistences;
using _07_Fiap.Web.AspNet.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _07_Fiap.Web.AspNet.Controllers
{
    public class PresidiarioController : Controller
    {
        private IPresidiarioRepository _presidiarioRepository;
        private ICelaRepository _celaRepository;

        public PresidiarioController(IPresidiarioRepository presidiarioRepository, ICelaRepository celaRepository)
        {
            _presidiarioRepository = presidiarioRepository;
            _celaRepository = celaRepository;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarCelas();
            return View();
        }

        private void CarregarCelas()
        {
            var lista = _celaRepository.Listar();
            ViewBag.celas = new SelectList(lista, "CelaId", "Nome");
        }

        [HttpPost]
        public IActionResult Cadastrar(Presidiario presidiario)
        {
            if (ModelState.IsValid)
            {
                _presidiarioRepository.Cadastrar(presidiario);
                _presidiarioRepository.Salvar();
                TempData["msg"] = "Cadastrado!";
                return RedirectToAction("Cadastrar");
            }
            else
            {
                CarregarCelas();
                return View();
            }
        }
    }
}