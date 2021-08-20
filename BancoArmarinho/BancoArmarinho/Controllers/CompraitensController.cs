using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Models;
using BancoArmarinho.Mapper;
using BancoArmarinho.Models;

namespace BancoArmarinho.Controllers
{
    public class CompraitensController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult ListarProdutos(int codigo)
        {
            var map = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
            List<CompraitensModel> lista = map.Map<List<CompraitensModel>>(new CompraitensRepositorio().buscarProdutos(codigo));
            return PartialView(lista);
        }


        [HttpPost]
        public JsonResult salvar([FromBody]CompraitensModel model)
        {
            try
            {
                var map = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());

                Compraitens pc = map.Map<Compraitens>(model);

                Produto pro = new ProdutoRepositorio().Consultar(pc.Prodcod.Value);

                new CompraitensRepositorio().Inserir(pc);

                return new JsonResult(model);
            }
            catch (Exception)
            {

                return new JsonResult(null);
            }

        }

        public JsonResult excluir(int codigo)
        {
            try
            {
                Compraitens pc = (new CompraitensRepositorio()).Consultar(codigo);
                (new CompraitensRepositorio()).Excluir(pc);
                var map = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings());
                return new JsonResult(map.Map<CompraitensModel>(pc));
            }
            catch (Exception)
            {

                return new JsonResult(null);
            }

        }
    }
}