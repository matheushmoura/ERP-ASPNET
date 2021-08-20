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
    public class UsuarioController : Controller
    {


        public IActionResult Index()
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 1))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }
            List<Usuario> lista = new UsuarioRepositorio().Consultar();

            var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<UsuarioModel> listaModel = mapper.Map<List<UsuarioModel>>(lista);

            return View(listaModel);
        }

        [HttpGet]
        public IActionResult Adiciona(int? id)
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 1))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }
            UsuarioModel model = new UsuarioModel();
            model.Codigo = 0;

            if (id.HasValue)
            {
                var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                model = mapper.Map<UsuarioModel>((new UsuarioRepositorio()).Consultar(id.Value));
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Adiciona(UsuarioModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                    Usuario cat = mapper.Map<Usuario>(model);

                    if (cat.Codigo == 0)
                    {
                        if ((new UsuarioRepositorio()).Inserir(cat))
                        {
                            ViewData["Menssagem"] = " SALVO !!";
                            model = new UsuarioModel();
                            model.Codigo = 0;
                            ModelState.Clear();
                        }
                        else
                        {
                            ViewData["Menssagem"] = " Usuario Já existe !!";
                        }
                    }
                    else
                    {
                        (new UsuarioRepositorio()).Alterar(cat);
                    }

                    //return RedirectToAction("Adiciona");
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
                Usuario cat = (new UsuarioRepositorio()).Consultar(id);

                if (cat != null)
                {
                    new UsuarioRepositorio().Excluir(cat);
                    ViewData["Mensagem"] = "Excluido com sucesso !!";
                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string txtLogin, string txtSenha)
        {
            try
            {
               
                Usuario usu = (new UsuarioRepositorio()).Autenticar(txtLogin, txtSenha);
                if (usu != null)
                {
                    /* inserir codigo na sessão e redirecionar p/ index */
                    HttpContext.Session.SetInt32("Codigo", usu.Codigo);
                    HttpContext.Session.SetString("Usuario", usu.Usuario1);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.menssagem = "inválido"+ txtLogin;
                }

            }
            catch (Exception)
            {
                ViewBag.menssagem = "ERRO";
                throw;
            }


            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Codigo");
            HttpContext.Session.Remove("Usuario");
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Usuario");
        }
        public IActionResult SemPermissao()
        {
            return View();
        }
    }
}