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
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 2))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }
            List<Cliente> lista = new ClienteRepositorio().Consultar();

            var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<ClienteModel> listaModel = mapper.Map<List<ClienteModel>>(lista);

            return View(listaModel);
        }

        [HttpGet]
        public IActionResult Adiciona(int? id)
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 2))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }

            ClienteModel model = new ClienteModel();
            model.Codigo = 0;
           
            if (id.HasValue)
            {
                var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                model = mapper.Map<ClienteModel>((new ClienteRepositorio()).Consultar(id.Value));
            }

            return View(model);
        }
        public IActionResult Visualiza(int? id)
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 2))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }

            ClienteModel model = new ClienteModel();
            model.Codigo = 0;

            if (id.HasValue)
            {
                var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                model = mapper.Map<ClienteModel>((new ClienteRepositorio()).Consultar(id.Value));
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult Adiciona(ClienteModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                    Cliente cat = mapper.Map<Cliente>(model);

                    cat.Pontos = 0;
                    cat.Situacao = true;
                    if (cat.Codigo == 0)
                    {
                        
                        if ((new ClienteRepositorio()).Inserir(cat))
                        {
                            ViewData["Menssagem"] = "SALVO !!";
                            model = new ClienteModel();
                            model.Codigo = 0;
                            ModelState.Clear();
                        }
                        else
                        {
                            ViewData["Menssagem"] = "Já existe !!";
                        }
                    }
                    else
                    {
                        (new ClienteRepositorio()).Alterar(cat);
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

        public IActionResult Excluir(int id)
        {
            try
            {
                Cliente cat = (new ClienteRepositorio()).Consultar(id);

                if (cat != null)
                {
                    new ClienteRepositorio().Excluir(cat);
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
                Cliente cat = (new ClienteRepositorio()).Consultar(id);

                if (cat != null)
                {
                    if(cat.Situacao == true)
                    {
                        cat.Situacao = false;
                    }
                    else
                    {
                        cat.Situacao = true;
                    }
                    new ClienteRepositorio().Alterar(cat);
                    ViewData["Menssagem"] = ": Alterado com sucesso !!";
                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
        public JsonResult Buscar(String Prefix)
        {
            var map = new AutoMapper.Mapper(BancoArmarinho.Mapper.AutoMapperConfig.RegisterMappings());
            List<ClienteModel> lista = map.Map<List<ClienteModel>>((new ClienteRepositorio()).Buscar(Prefix));
            return new JsonResult(lista);
        }

    }
}