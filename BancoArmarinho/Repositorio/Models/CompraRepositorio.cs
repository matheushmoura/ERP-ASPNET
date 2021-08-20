using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Models
{
    public class CompraRepositorio
    {
        public void Inserir(Compra model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Compra.Add(model);
                db.SaveChanges();
            }
        }

        public Compra Consultar(int id)
        {
            Compra model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from nc in db.Compra
                         join f in db.Fornecedor on nc.Fornecedor equals f.Codigo
                         where nc.Codigo == id
                         select new Compra()
                         {
                             Codigo = nc.Codigo,
                             Observacao = nc.Observacao,
                             Stat = nc.Stat,
                             Data = nc.Data,
                             Valor = nc.Valor,
                             Tipo = nc.Tipo,
                             Fornecedor = nc.Fornecedor,
                             FornecedorNavigation = f
                         }).FirstOrDefault();
            }

            return model;
        }

        public List<Compra> Consultar()
        {
            List<Compra> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Compra
                         join f in db.Fornecedor on c.Fornecedor equals f.Codigo
                         where c.Stat == "F" && c.Tipo == 0
                         select new Compra()
                         {
                             Codigo = c.Codigo,
                             Observacao = c.Observacao,
                             Stat = c.Stat,
                             Data = c.Data,
                             Tipo = c.Tipo,
                             Valor = c.Valor,
                             Fornecedor = c.Fornecedor,
                             FornecedorNavigation = f
                         }).ToList();
            }

            return model;
        }

        public List<Compra> ConsultarEstorno()
        {
            List<Compra> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Compra
                         join f in db.Fornecedor on c.Fornecedor equals f.Codigo
                         where c.Stat == "F"  && c.Tipo == 1
                         select new Compra()
                         {
                             Codigo = c.Codigo,
                             Observacao = c.Observacao,
                             Stat = c.Stat,
                             Data = c.Data,
                             Tipo = c.Tipo,
                             Valor = c.Valor,
                             Fornecedor = c.Fornecedor,
                             FornecedorNavigation = f
                         }).ToList();
            }

            return model;
        }

        public List<Compra> buscarNotaFornecedor(int codigo)
        {
            List<Compra> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Compra
                         join f in db.Fornecedor on c.Fornecedor equals f.Codigo
                         where c.Stat == "F" && c.Fornecedor == codigo
                         select new Compra()
                         {
                             Codigo = c.Codigo,
                             Observacao = c.Observacao,
                             Stat = c.Stat,
                             Data = c.Data,
                             Valor = c.Valor,
                             Tipo = c.Tipo,
                             Fornecedor = c.Fornecedor,
                             FornecedorNavigation = f
                         }).ToList();
            }

            return model;
        }

        public void Alterar(Compra model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Compra model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
