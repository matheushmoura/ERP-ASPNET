using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Models;
using BancoArmarinho.Mapper;
using BancoArmarinho.Models;
using Rotativa.AspNetCore;


namespace BancoArmarinho.Controllers
{
    public class ItensvendidosController : Controller
    {


        public IActionResult Index()
        {
            List<Itensvendidos> lista = new ItensvendidosRepositorio().Consultar();

            var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<ItensvendidosModel> listaModel = mapper.Map<List<ItensvendidosModel>>(lista);

            return View(listaModel);
        }

        public PartialViewResult itens_pedido(int prefix)
        {
            var map = new AutoMapper.Mapper(BancoArmarinho.Mapper.AutoMapperConfig.RegisterMappings());
            List<ItensvendidosModel> lista = map.Map<List<ItensvendidosModel>>( (new ItensvendidosRepositorio()).buscarProdutos(prefix) );
            return PartialView(lista);
        }

        [HttpGet]
        public IActionResult Adiciona(int? id)
        {
            ItensvendidosModel model = new ItensvendidosModel();
            model.Codigo = 0;

            if (id.HasValue)
            {
                var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                model = mapper.Map<ItensvendidosModel>((new ItensvendidosRepositorio()).Consultar(id.Value));
            }

            return View(model);
        }
        [HttpPost]
        public JsonResult salvar([FromBody]ItensvendidosModel model)
        {
            try
            {
                var map = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                Cliente cli = new ClienteRepositorio().Consultar(model.Codigo);
                model.Codigo = 0;

                Itensvendidos item = map.Map<Itensvendidos>(model);

                //Produto pro = new ProdutoRepositorio().Consultar(item.Produto.Value);
                //substituição
                
                model.ProdutoNavigation = map.Map<ProdutoModel>( new ProdutoRepositorio().Consultar(model.Produto.Value) );
                item.Valor = model.ProdutoNavigation.Preço.Value * model.Quantidade.Value;
                //resto
                //item.Valor = (decimal)item.Quantidade * pro.Preço;

                new ItensvendidosRepositorio().Inserir(item);
                model.VendaCodigo = item.VendaCodigo;
                model.Valor = new ItensvendidosRepositorio().calcularTotal(model.VendaCodigo.Value);
                if (cli != null)
                {
                    if (cli.Pontos > 50)
                    {
                        model.Valor = (model.Valor / 100) * 5;
                    }
                    else
                    {
                        model.Valor = 0;
                    }
                }

                
                return new JsonResult(model);
            }
            catch (Exception)
            {

                return new JsonResult(null);
            }

        }
            public IActionResult Excluir(int id)
        {
            try
            {
                Itensvendidos cat = (new ItensvendidosRepositorio()).Consultar(id);

                if (cat != null)
                {
                    new ItensvendidosRepositorio().Excluir(cat);
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