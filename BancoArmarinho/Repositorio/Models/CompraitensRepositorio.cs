using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Models
{
    public class CompraitensRepositorio
    {
        public void Inserir(Compraitens model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Compraitens.Add(model);
                db.SaveChanges();
            }
        }

        public Compraitens Consultar(int id)
        {
            Compraitens model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from p in db.Compraitens join pro in db.Produto on p.Prodcod equals pro.Codigo
                         where p.Ccompra == id
                         select new Compraitens()
                         {
                             Ccodigo = p.Ccodigo,
                             Ccompra = p.Ccompra,
                             Prodcod = p.Prodcod,
                             ProdcodNavigation = pro,
                             Cquant = p.Cquant,
                         }).FirstOrDefault();
            }

            return model;
        }
        

        public List<Compraitens> Consultar()
        {
            List<Compraitens> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Compraitens select c).ToList();
            }

            return model;
        }

        public List<Compraitens> buscarProdutos(int codigo)
        {
            List<Compraitens> model = null;
            using (BancoArmarinhoContext db =
                new BancoArmarinhoContext())
            {
                model = (from p in db.Compraitens join pro in db.Produto on p.Prodcod equals pro.Codigo
                         where p.Ccompra == codigo
                         select new Compraitens()
                         {
                             Ccodigo = p.Ccodigo,
                             Ccompra = p.Ccompra,
                             Prodcod = p.Prodcod,
                             ProdcodNavigation = pro,
                             Cquant = p.Cquant,
                         }).ToList();
            }

            return model;
        }

        public void Alterar(Compraitens model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Compraitens model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
