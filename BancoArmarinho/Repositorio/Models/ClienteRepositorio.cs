using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Models
{
    public class ClienteRepositorio
    {

        public bool Inserir(Cliente model)
        {
            if (Consultar(model.Documento) == null)
            {
                using (BancoArmarinhoContext db = new BancoArmarinhoContext())
                {
                    db.Cliente.Add(model);
                    db.SaveChanges();
                }
                return true;
            }
            else
                return false;


        }
        public Cliente Consultar(int id)
        {
            Cliente model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = db.Cliente.Find(id);
            }

            return model;
        }
        public Cliente Consultar(string doc)
        {
            Cliente model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Cliente where c.Documento == doc select c).FirstOrDefault();
            }

            return model;
        }
        public List<Cliente> Consultar()
        {
            List<Cliente> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Cliente select c).ToList();
            }

            return model;
        }
        public List<Cliente> Buscar (String id)
        {
            List<Cliente> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Cliente where c.Documento == id && c.Situacao == true select c).ToList();
            }

            return model;
        }
        // divisor

        public void Alterar(Cliente model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Cliente model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }


    }
}
