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
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 2))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }
            List<Categoria> lista = (new CategoriaRepositorio()).Consultar();

            var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<CategoriaModel> listaModel = mapper.Map<List<CategoriaModel>>(lista);

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

            CategoriaModel model = new CategoriaModel();
            model.Codigo = 0;

            if (id.HasValue)
            {
                var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                model = mapper.Map<CategoriaModel>((new CategoriaRepositorio()).Consultar(id.Value));
            }

            return View(model);
        }
        
        [HttpPost]
        public IActionResult Adiciona(CategoriaModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                    Categoria cat = mapper.Map<Categoria>(model);

                    if (cat.Codigo == 0)
                    {
                        if ((new CategoriaRepositorio()).Inserir(cat))
                        {

                            ViewData["Menssagem"] = "SALVO !!";
                            model = new CategoriaModel();
                            model.Codigo = 0;
                            ModelState.Clear();
                        }
                        else
                        {
                            ViewData["Menssagem"] = "Categoria Já existe !!";
                        }
                    }
                    else
                    {
                        (new CategoriaRepositorio()).Alterar(cat);
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
            
            return View(model);
        }
        public JsonResult Buscar(String Prefix)
        {
            var map = new AutoMapper.Mapper(BancoArmarinho.Mapper.AutoMapperConfig.RegisterMappings());
            List<CategoriaModel> lista = map.Map<List<CategoriaModel>>((new CategoriaRepositorio()).Buscar(Prefix));
            return new JsonResult(lista);
        }


        public IActionResult Excluir(int id)
        {
            try
            {
                Categoria cat = (new CategoriaRepositorio()).Consultar(id);

                if (cat != null)
                {
                    new CategoriaRepositorio().Excluir(cat);
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