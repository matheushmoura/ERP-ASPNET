using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Models
{
    public class CategoriaRepositorio
    {
        public Boolean Inserir(Categoria model)
        {
            if (Consultar2(model.Nome) == null)
            {
                using (BancoArmarinhoContext db = new BancoArmarinhoContext())
                {
                    db.Categoria.Add(model);
                    db.SaveChanges();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public Categoria Consultar2(string doc)
        {
            Categoria model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Categoria where c.Nome == doc select c).FirstOrDefault();
            }

            return model;
        }
        public Categoria Consultar(int? id)
        {
            Categoria model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = db.Categoria.Find(id);
            }

            return model;
        }

        public List<Categoria> Consultar()
        {
            List<Categoria> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Categoria select c).ToList();
            }

            return model;
        }
        public List<Categoria> Buscar(String id)
        {
            List<Categoria> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Categoria where c.Nome== id select c).ToList();
            }

            return model;
        }
        public void Alterar(Categoria model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Categoria model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        


    }
}
