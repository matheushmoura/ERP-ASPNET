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
    public class VendaController : Controller
    {

        public IActionResult Index()
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 3))
            {
                case -1: return RedirectToAction("Login", "Usuario");
                case 0: return RedirectToAction("SemPermissao", "Usuario");
            }
            List<Venda> lista = (new VendaRepositorio()).Consultar();

            var mapper = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

            List<VendaModel> listaModel = mapper.Map<List<VendaModel>>(lista);

            return View(listaModel);
        }


        public IActionResult create()
        {
            switch (new UsuarioRepositorio().VerificarPermissao(HttpContext.Session.GetInt32("Codigo"), 2))
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
                Venda ven = (new VendaRepositorio().Consultar(codigo));
                ven.Valor = new ItensvendidosRepositorio().calcularTotal(codigo);

                //pontuação
                Cliente c = new ClienteRepositorio().Consultar(new VendaRepositorio().Consultar(ven.Codigo).Cliente.Value);
                
                c.Pontos += (int)(ven.Valor / 10);

                ven = (new VendaRepositorio().AtualizarVenda(ven, c));

                new ClienteRepositorio().Alterar(c);

                //desconto
                if (c.Pontos > 50)
                {
                    ven.Desconto = (ven.Valor / 100) * 5;
                }
                else
                {
                    ven.Desconto = 0;
                }
                //alterar quantidade estoque
                ven.Total = ven.Valor - ven.Desconto;
                //ven.Total = ven.Valor;
                List<Itensvendidos> ci = new ItensvendidosRepositorio().buscarProdutos(ven.Codigo);
                Produto p = new Produto();

                foreach(var item in ci)
                {
                    p = new ProdutoRepositorio().Consultar(item.Produto.Value);
                    p.Quantidade = p.Quantidade - item.Quantidade;
                    p.Estoque2 = p.Estoque2 - item.Quantidade;

                    new ProdutoRepositorio().Alterar(p);
                }
                //altera vendaa
                new VendaRepositorio().Alterar(ven);




                return new JsonResult(true);
            }
            catch (Exception)
            {
                return new JsonResult(false);
            }
        }

        [HttpPost]
        public JsonResult salvar([FromBody]VendaModel model)
        {
            try
            {
                var map = new AutoMapper.Mapper(BancoArmarinho.Mapper.AutoMapperConfig.RegisterMappings());

                Venda ven = map.Map<Venda>(model);

                ven.Data = DateTime.Now;

                new VendaRepositorio().Inserir(ven);

                model.Codigo = ven.Codigo;
               
                return new JsonResult(model);
            }
            catch (Exception)
            {
                return new JsonResult(null);
            }
        }
    }

}
