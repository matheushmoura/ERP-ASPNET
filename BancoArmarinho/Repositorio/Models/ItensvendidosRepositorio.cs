using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Models
{
    public class ItensvendidosRepositorio
    {

        public decimal calcularTotal(int Venda_codigo)
        {
            decimal total = 0;
            using (BancoArmarinhoContext db =
                new BancoArmarinhoContext())
            {
                total = (from p in db.Itensvendidos where p.VendaCodigo == Venda_codigo select p).Sum(p => p.Valor.Value);

            }

            return total;
        }

        public void Inserir(Itensvendidos model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Itensvendidos.Add(model);
                db.SaveChanges();
            }
        }


        public Itensvendidos Consultar(int id)
        {
            Itensvendidos model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from p in db.Itensvendidos
                         join pro in db.Produto on p.Produto equals pro.Codigo
                         where p.Codigo == id
                         select new Itensvendidos()
                         {
                             VendaCodigo = p.VendaCodigo,
                             Codigo = p.Codigo,
                             Produto = p.Produto,
                             ProdutoNavigation = pro,
                             Quantidade = p.Quantidade,
                             Valor = p.Valor
                         }).FirstOrDefault();
            }

            return model;
        }

        public List<Itensvendidos> localizarPedido(int codigo)
        {
            List<Itensvendidos> model = null;
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from p in db.Itensvendidos where p.Produto == codigo select p).ToList();
            }
            return model;
        }

        public List<Itensvendidos> buscarProdutos(int Prefix)
        {
            List<Itensvendidos> model = null;
            using (BancoArmarinhoContext db =
                new BancoArmarinhoContext())
            {
                model = (from p in db.Itensvendidos
                         join pro in db.Produto on p.Produto equals pro.Codigo
                         where p.VendaCodigo == Prefix 
                         select new Itensvendidos()
                         {
                             VendaCodigo = p.VendaCodigo,
                             Codigo = p.Codigo,
                             Produto = p.Produto,
                             Quantidade = p.Quantidade,
                             Valor = p.Valor,
                             ProdutoNavigation = pro
                         }).ToList();
                //  model = (from p in db.Produtos where p.Codigo==id select p).FirstOrDefault();
            }

            return model;
        }

        //public Itensvendidos Consultar(int id)
        //{
        //    Itensvendidos model = null;

        //    using (BancoArmarinhoContext db = new BancoArmarinhoContext())
        //    {
        //        model = db.Itensvendidos.Find(id);
        //    }

        //    return model;
        //}

        public List<Itensvendidos> Consultar()
        {
            List<Itensvendidos> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Itensvendidos select c).ToList();
            }

            return model;
        }

        public void Alterar(Itensvendidos model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Itensvendidos model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
