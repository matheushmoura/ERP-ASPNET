using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Models;
using BancoArmarinho.Mapper;
using BancoArmarinho.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BancoArmarinho.Controllers
{
    public class ProdutoController : Controller
    {


        public IActionResult Index()
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 3))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }
            List<Produto> lista = new ProdutoRepositorio().Consultar();

            var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<ProdutoModel> listaModel = mapper.Map<List<ProdutoModel>>(lista);

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
            ProdutoModel model = new ProdutoModel();
            model.Codigo = 0;
            model.Estoque1 = 0;
            model.Estoque2 = 0;
            if (id.HasValue)
            {
                var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                model = mapper.Map<ProdutoModel>((new ProdutoRepositorio()).Consultar(id.Value));
            }
            ViewBag.Categoria = InitCategoria();
            ViewBag.Fornecedor = InitFornecedor();
            return View(model);
        }

        [HttpPost]
        public IActionResult Adiciona(ProdutoModel model)
        {

            try
            {

               
                if (ModelState.IsValid)
                {
                    var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                    Produto cat = mapper.Map<Produto>(model);
                    //cat = new ProdutoRepositorio().AtualizaNav(cat);
                    if (cat.Codigo == 0)
                    {
                        (new ProdutoRepositorio()).Inserir(cat);
                        ViewData["Menssagem"] = "SALVO !!";
                        model = new ProdutoModel();
                        model.Codigo = 0;
                        ModelState.Clear();
                    }
                    else
                    {
                        (new ProdutoRepositorio()).Alterar(cat);
                        ViewData["Menssagem"] = "SALVO !!";
                    }

                    ViewBag.Categoria = InitCategoria();
                    ViewBag.Fornecedor = InitFornecedor();
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
                Produto cat = (new ProdutoRepositorio()).Consultar(id);

                if (cat != null)
                {
                    new ProdutoRepositorio().Excluir(cat);
                    ViewData["Menssagem"] = "Excluido com sucesso !!";
                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Aumenta1(int id)
        {
            try
            {
                Produto pro = (new ProdutoRepositorio()).Consultar(id);

                if (pro != null)
                {
                    pro.Estoque1 += 1;
                    pro.Quantidade += 1;
                    new ProdutoRepositorio().Alterar(pro);
                    ViewData["Menssagem"] = ": Alterado com sucesso !!";
                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
        public IActionResult Aumenta2(int id)
        {
            try
            {
                Produto pro = (new ProdutoRepositorio()).Consultar(id);

                if (pro != null)
                {
                    pro.Estoque2 += 1;
                    pro.Quantidade += 1;
                    new ProdutoRepositorio().Alterar(pro);
                    ViewData["Menssagem"] = ": Alterado com sucesso !!";
                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
        public IActionResult Diminui1(int id)
        {
            try
            {
                Produto pro = (new ProdutoRepositorio()).Consultar(id);

                if (pro != null)
                {
                    if (pro.Estoque1 >= 1)
                    {
                        pro.Estoque1 -= 1;
                        pro.Quantidade -= 1;
                        new ProdutoRepositorio().Alterar(pro);
                        ViewData["Menssagem"] = ": Alterado com sucesso !!";
                    }
                    else
                    {
                        ViewData["Menssagem"] = ": Não da para retirar mais!!";
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
        public IActionResult Diminui2(int id)
        {
            try
            {
                Produto pro = (new ProdutoRepositorio()).Consultar(id);

                if (pro != null)
                {
                    if (pro.Estoque2 >= 1)
                    {
                        pro.Estoque2 -= 1;
                        pro.Quantidade -= 1;
                        new ProdutoRepositorio().Alterar(pro);
                        ViewData["Menssagem"] = ": Alterado com sucesso !!";
                    }
                    else
                    {
                        ViewData["Menssagem"] = ": Não da para retirar mais!!";
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
        public JsonResult Buscar(string Prefix)
        {
            var map = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
            List<ProdutoModel> lista = map.Map<List<ProdutoModel>>(new ProdutoRepositorio().Consultar(Prefix));
            return new JsonResult(lista);
        }
        List<CategoriaModel> InitCategoria()
        {
            var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<CategoriaModel> lista = mapper.Map<List<CategoriaModel>>(new CategoriaRepositorio().Consultar());
            lista.Insert(0, new CategoriaModel()
            {
                Codigo = 0,
                Nome = "Selecione a Categoria...",
            });

            return lista;
        }
        List<FornecedorModel> InitFornecedor()
        {
            var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<FornecedorModel> lista = mapper.Map<List<FornecedorModel>>(new FornecedorRepositorio().Consultar());
            lista.Insert(0, new FornecedorModel()
            {
                Codigo = 0,
                Nome = "Selecione o Fornecedor...",
            });

            return lista;
        }
    }
}