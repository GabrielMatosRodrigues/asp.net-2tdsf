using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _06_Fiap.Web.AspNet.Models;
using _06_Fiap.Web.AspNet.Persitences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _06_Fiap.Web.AspNet.Controllers
{
    public class ImovelController : Controller
    {
        private BancoContext _context;

        public ImovelController(BancoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Listar(int idBusca)
        {
            CarregarSelectCondominio();
            return View(_context.Imoveis
                .Include(i => i.Condominio)
                .Where(i => i.CondominioId == idBusca || idBusca == 0).ToList());
        }

        [HttpPost]
        public IActionResult Cadastrar(Imovel imovel)
        {
            _context.Imoveis.Add(imovel);
            _context.SaveChanges();
            TempData["msg"] = "Imóvel registrado!";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarSelectCondominio();
            return View();
        }

        private void CarregarSelectCondominio()
        {
            var lista = _context.Condominios.ToList();
            ViewBag.condominios = new SelectList(lista,
                "CondominioId", "Nome");
        }
    }
}