using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Models;
using BancoArmarinho.Mapper;
using BancoArmarinho.Models;
using Microsoft.AspNetCore.Http;

namespace BancoArmarinho.Controllers
{
    public class FornecedorController : Controller
    {

        public IActionResult Index()
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 3))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }
            List<Fornecedor> lista = new FornecedorRepositorio().Consultar();

            var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<FornecedorModel> listaModel = mapper.Map<List<FornecedorModel>>(lista);

            return View(listaModel);
        }

        [HttpGet]
        public IActionResult Adiciona(int? id)
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 3))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }
            FornecedorModel model = new FornecedorModel();
            model.Codigo = 0;

            if (id.HasValue)
            {
                var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                model = mapper.Map<FornecedorModel>((new FornecedorRepositorio()).Consultar(id.Value));
            }

            return View(model);
        }
        public IActionResult Visualiza(int? id)
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 3))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }
            FornecedorModel model = new FornecedorModel();
            model.Codigo = 0;

            if (id.HasValue)
            {
                var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                model = mapper.Map<FornecedorModel>((new FornecedorRepositorio()).Consultar(id.Value));
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult Adiciona(FornecedorModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                    Fornecedor cat = mapper.Map<Fornecedor>(model);
                    cat.Situacao = true;
                    if (cat.Codigo == 0)
                    {
                        if ((new FornecedorRepositorio()).Inserir(cat))
                        {
                            ViewData["Menssagem"] = "SALVO !!";
                            model = new FornecedorModel();
                            model.Codigo = 0;
                            ModelState.Clear();
                        }
                        else
                        {
                            ViewData["Menssagem"] = "Fornecedor já existe !!";
                        }
                    }
                    else
                    {
                        (new FornecedorRepositorio()).Alterar(cat);
                    }

                    //return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(model);
        }
        public JsonResult Buscar(string prefix)
        {
            var map = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
            List<FornecedorModel> lista = map.Map<List<FornecedorModel>>(new FornecedorRepositorio().Consultar(prefix));
            return new JsonResult(lista);
        }
        public JsonResult Buscar2(string prefix)
        {
            var map = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
            List<FornecedorModel> lista = map.Map<List<FornecedorModel>>(new FornecedorRepositorio().Buscar(prefix));
            return new JsonResult(lista);
        }
        public IActionResult Excluir(int id)
        {
            try
            {
                Fornecedor cat = (new FornecedorRepositorio()).Consultar(id);

                if (cat != null)
                {
                    new FornecedorRepositorio().Excluir(cat);
                    ViewData["Menssagem"] = "Excluido com sucesso !!";
                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Ativadesativa(int id)
        {
            try
            {
                Fornecedor cat = (new FornecedorRepositorio()).Consultar(id);

                if (cat != null)
                {
                    if (cat.Situacao == true)
                    {
                        cat.Situacao = false;
                    }
                    else
                    {
                        cat.Situacao = true;
                    }
                    new FornecedorRepositorio().Alterar(cat);
                    ViewData["Menssagem"] = ": Alterado com sucesso !!";
                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }


    }
}