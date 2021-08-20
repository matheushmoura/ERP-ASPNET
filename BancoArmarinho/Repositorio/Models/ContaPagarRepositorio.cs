using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Models
{
    public class ContaPagarRepositorio
    {
        public void Inserir(ContaPagar model)
        {
            
                using (BancoArmarinhoContext db = new BancoArmarinhoContext())
                {
                    db.ContaPagar.Add(model);
                    db.SaveChanges();
                }
             


        }
        public ContaPagar Consultar(int id)
        {
            ContaPagar model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = db.ContaPagar.Find(id);
            }

            return model;
        }
     
        public List<ContaPagar> Consultar()
        {
            List<ContaPagar> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.ContaPagar select c).ToList();
            }

            return model;
        }
       
        // divisor

        public void Alterar(ContaPagar model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(ContaPagar model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }



    }
}
