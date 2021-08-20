using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Models
{
    public class VendaRepositorio
    {

        public void Inserir(Venda model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Venda.Add(model);
                db.SaveChanges();
            }
        }

        public Venda Consultar(int id)
        {
            Venda model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = db.Venda.Find(id);
            }

            return model;
        }

        public List<Venda> Consultar()
        {
            List<Venda> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from v in db.Venda join c in db.Cliente on v.Cliente equals c.Codigo select new Venda()
                {
                    Cliente = v.Cliente,
                    Codigo = v.Codigo,
                    Data = v.Data,
                    Valor = v.Valor,
                    Desconto = v.Desconto,
                    Total = v.Total,

                    ClienteNavigation = c,
                }).ToList();
            }

            return model;
        }

        public void Alterar(Venda model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Venda AtualizarVenda(Venda ven, Cliente cli)
        {
            ven.ClienteNavigation = cli;
                return ven;
        }

        public void Excluir(Venda model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }

    }
}
