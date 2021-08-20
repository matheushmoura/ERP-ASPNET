using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Models
{
    public class ProdutoRepositorio
    {
        public void Inserir(Produto model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Produto.Add(model);
                db.SaveChanges();
            }
        }
        //public Produto AtualizaNav(Produto model)
        //{
        //    model.FornecedorNavigation = new FornecedorRepositorio().Consultar(model.Fornecedor);
        //    model.CategoriaNavigation = new CategoriaRepositorio().Consultar(model.Categoria);
        //    return model;
        //}
        public Produto Consultar(int id)
        {
            Produto model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = db.Produto.Find(id);
            }

            return model;
        }
        private static bool IsNumeric(string data)
        {
            bool isnumeric = false;
            char[] datachars = data.ToCharArray();

            foreach (var datachar in datachars)
                isnumeric = isnumeric ? char.IsDigit(datachar) : isnumeric;


            return isnumeric;
        }

        public List<Produto> Consultar(String Prefix)
        {
            List<Produto> model = null;

            if (Char.IsDigit(Prefix, 0))
            {
            
            int PrefixInt = Convert.ToInt32(Prefix);
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from p in db.Produto
                         join c in db.Categoria on p.Categoria equals c.Codigo
                         where  p.Codigo == PrefixInt
                         select new Produto()
                         {
                             //CatCodigoNavigation = c,
                             Categoria = p.Categoria,
                             Codigo = p.Codigo,
                             Nome = p.Nome,
                             Quantidade = p.Quantidade,
                             Preço = p.Preço
                         }).ToList();
            }
            }
            else
            {
                
                using (BancoArmarinhoContext db = new BancoArmarinhoContext())
                {
                    model = (from p in db.Produto
                             join c in db.Categoria on p.Categoria equals c.Codigo
                             where p.Nome.Contains(Prefix) 
                             select new Produto()
                             {
                                 //CatCodigoNavigation = c,
                                 Categoria = p.Categoria,
                                 Codigo = p.Codigo,
                                 Nome = p.Nome,
                                 Quantidade = p.Quantidade,
                                 Preço = p.Preço
                             }).ToList();
                }
            }
            return model;
        }
        public List<Produto> Consultar()
        {
            List<Produto> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Produto select c).ToList();
            }

            return model;
        }

        public void Alterar(Produto model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Produto model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }

    }
}
