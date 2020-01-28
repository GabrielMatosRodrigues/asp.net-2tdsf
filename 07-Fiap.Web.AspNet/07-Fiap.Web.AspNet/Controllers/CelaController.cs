using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _07_Fiap.Web.AspNet.Models;
using _07_Fiap.Web.AspNet.Persistences;
using _07_Fiap.Web.AspNet.Repositories;
using _07_Fiap.Web.AspNet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _07_Fiap.Web.AspNet.Controllers
{
    public class CelaController : Controller
    {
        private ICelaRepository _repository;
        private IPresidiarioRepository _presidiarioRepository;

        public CelaController(ICelaRepository repository,
            IPresidiarioRepository presidiarioRepository)
        {
            _repository = repository;
            _presidiarioRepository = presidiarioRepository;
        }

        [HttpPost]
        public IActionResult Saidinha(int id)
        {
            var presidiario = _presidiarioRepository.BuscarPorCodigo(id);
            presidiario.SaidaTemporaria = true;
            _presidiarioRepository.Atualizar(presidiario);
            _presidiarioRepository.Salvar();
            TempData["msg"] = "Saida registrada";
            return RedirectToAction("Detalhar", new { codigo = presidiario.CelaId } );
        }

        [HttpGet]
        public IActionResult Detalhar(int codigo)
        {
            //Pesquisar a cela
            var cela = _repository.BuscarPorCodigo(codigo);
            //Listar os presidiarios da cela
            var presidiarios = _presidiarioRepository
                            .BuscarPor(p => p.CelaId == codigo);

            //Objeto que possui todas as informações da tela
            var viewModel = new DetalheCelaViewModel()
            {
                Cela = cela,
                Presidiarios = presidiarios,
                QuantidadePresidiarios = presidiarios.Count,
                Ocupacao = (presidiarios.Count*100)/cela.QuantidadeMaxima
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cela cela)
        {
            //verifica se a cela está OK
            if (ModelState.IsValid)
            {
                _repository.Cadastrar(cela);
                _repository.Salvar();
                TempData["msg"] = "Cadastrado!";
                return RedirectToAction("Cadastrar");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return View(_repository.Listar());
        }
    }
}