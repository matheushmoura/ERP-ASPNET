using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq.Expressions;
using Repositorio.Models;
using BancoArmarinho.Models;


namespace BancoArmarinho.Mapper
{
    public class AutoMapperConfig : Profile
    {

        public static MapperConfiguration RegisterMappings()
        {


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Categoria, CategoriaModel>();
                cfg.CreateMap<CategoriaModel, Categoria>();
                cfg.CreateMap<Fornecedor, FornecedorModel>();
                cfg.CreateMap<FornecedorModel, Fornecedor>();
                cfg.CreateMap<Cliente, ClienteModel>();
                cfg.CreateMap<ClienteModel, Cliente>();
                cfg.CreateMap<Produto, ProdutoModel>();
                cfg.CreateMap<ProdutoModel, Produto>();
                cfg.CreateMap<Usuario, UsuarioModel>();
                cfg.CreateMap<UsuarioModel, Usuario>();
                cfg.CreateMap<Itensvendidos, ItensvendidosModel>();
                cfg.CreateMap<ItensvendidosModel, Itensvendidos>();
                cfg.CreateMap<Venda, VendaModel>();
                cfg.CreateMap<VendaModel, Venda>();

                cfg.CreateMap<Compra, CompraModel>();
                cfg.CreateMap<CompraModel, Compra>();

                cfg.CreateMap<Compraitens, CompraitensModel>();
                cfg.CreateMap<CompraitensModel, Compraitens>();

                cfg.CreateMap<ContaPagar, ContaPagarModel>();
                cfg.CreateMap<ContaPagarModel, ContaPagar>();
            });
            return config;

        }


    }

}
