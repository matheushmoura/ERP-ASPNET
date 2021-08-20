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
        public class CompraController : Controller
        {
        

        public IActionResult Index()
            {
                switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 3))
                {
                    case -1: return RedirectToAction("Login", "Usuario");
                    case 0: return RedirectToAction("SemPermissao", "Usuario");
                }
            List<Compra> lista = (new CompraRepositorio()).Consultar();

                var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<CompraModel> listaNota = mapper.Map<List<CompraModel>>(lista);

                return View(listaNota);
            }
        public IActionResult Index2()
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 3))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }
            List<Compra> lista = (new CompraRepositorio()).ConsultarEstorno();

            var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<CompraModel> listaNota = mapper.Map<List<CompraModel>>(lista);

            return View(listaNota);
        }

        public IActionResult Cadastrar()
            {
                switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 3))
                {
                    case -1: return RedirectToAction("Login", "Usuario");
                    case 0: return RedirectToAction("SemPermissao", "Usuario");
                }
            return View();
            }

            public JsonResult finalizar(int codigo)
            {
                try
                {
                    Compra n = (new CompraRepositorio().Consultar(codigo));
                n.Stat = "F";
                //Altera estoque
                    List<Compraitens> ci = new CompraitensRepositorio().buscarProdutos(n.Codigo);
                    Produto p = new Produto();

                    foreach (var item in ci)
                    {
                        p = new ProdutoRepositorio().Consultar(item.Prodcod.Value);
                        p.Quantidade = p.Quantidade + item.Cquant;
                        p.Estoque2 = p.Estoque2 + item.Cquant;
                    new ProdutoRepositorio().Alterar(p);
                    }

                //altera compra
                new CompraRepositorio().Alterar(n);

                    return new JsonResult(true);
                }
                catch (Exception)
                {
                    return new JsonResult(false);
                }
            }

            [HttpPost]
            public JsonResult salvar([FromBody]CompraModel model)
            {
                try
                {
                    var map = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

                    Compra n = map.Map<Compra>(model);

                    n.Data = DateTime.Now;

                    n.Stat = "I";

                    new CompraRepositorio().Inserir(n);

                    model.Codigo = n.Codigo;

                    return new JsonResult(model);
                }
                catch (Exception e)
                {
                    return new JsonResult(e);
                }
            }
        }
    }
