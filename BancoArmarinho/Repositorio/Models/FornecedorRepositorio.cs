using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Models
{
    public class FornecedorRepositorio
    {

        public bool Inserir(Fornecedor model)
        {
            if (Consultarl(model.Cnpj) == null)
            {
                using (BancoArmarinhoContext db = new BancoArmarinhoContext())
                {
                    db.Fornecedor.Add(model);
                    db.SaveChanges();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public Fornecedor Consultar(int? id)
        {
            Fornecedor model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = db.Fornecedor.Find(id);
            }

            return model;
        }
        public Fornecedor Consultarl(string doc)
        {
            Fornecedor model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Fornecedor where c.Cnpj == doc select c).FirstOrDefault();
            }

            return model;
        }
        public List<Fornecedor> Consultar()
        {
            List<Fornecedor> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Fornecedor select c).ToList();

            }

            return model;
        }
        public List<Fornecedor> Consultar(String id)
        {
            List<Fornecedor> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Fornecedor where c.Nome.Contains(id) && c.Situacao == true select c).ToList();
            }

            return model;
        }
        public List<Fornecedor> Buscar(String id)
        {
            List<Fornecedor> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Fornecedor where c.Nome == id select c).ToList();
            }

            return model;
        }
        // divisor

        public void Alterar(Fornecedor model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Fornecedor model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }


        //divisor
    }
}
