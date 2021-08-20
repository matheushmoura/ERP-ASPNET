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
    public class ContaPagarController : Controller
    {
        public IActionResult Index()
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 3))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }
            List<ContaPagar> lista = new ContaPagarRepositorio().Consultar();

            var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<ContaPagarModel> listaModel = mapper.Map<List<ContaPagarModel>>(lista);

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
            ContaPagarModel model = new ContaPagarModel();
            model.Codigo = 0;

            if (id.HasValue)
            {
                var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                model = mapper.Map<ContaPagarModel>((new ContaPagarRepositorio()).Consultar(id.Value));
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Adiciona(ContaPagarModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                    ContaPagar cat = mapper.Map<ContaPagar>(model);

                    if (cat.Codigo == 0)
                    {
                        (new ContaPagarRepositorio()).Inserir(cat);
                        
                            ViewData["Menssagem"] = "SALVO !!";
                       

                    }
                    else
                    {
                        (new ContaPagarRepositorio()).Alterar(cat);
                        
                            ViewData["Menssagem"] = "SALVO !!";
                    }

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(model);
        }
       

        public IActionResult Excluir(int id)
        {
            try
            {
                ContaPagar cat = (new ContaPagarRepositorio()).Consultar(id);

                if (cat != null)
                {
                    new ContaPagarRepositorio().Excluir(cat);
                    ViewData["Menssagem"] = "Excluido com sucesso !!";
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