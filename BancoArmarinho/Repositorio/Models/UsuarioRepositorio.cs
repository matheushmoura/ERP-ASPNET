using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Models
{
    public class UsuarioRepositorio
    {


        public Boolean Inserir(Usuario model)
        {
            if (Consultar2(model.Usuario1) == null)
            {
                using (BancoArmarinhoContext db = new BancoArmarinhoContext())
                {
                    db.Usuario.Add(model);
                    db.SaveChanges();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public Usuario Consultar2(string doc)
        {
            Usuario model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Usuario where c.Usuario1 == doc select c).FirstOrDefault();
            }

            return model;
        }
        public Usuario Consultar(int id)
        {
            Usuario model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = db.Usuario.Find(id);
            }

            return model;
        }

        public List<Usuario> Consultar()
        {
            List<Usuario> model = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                model = (from c in db.Usuario select c).ToList();
            }

            return model;
        }

        public void Alterar(Usuario model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Usuario model)
        {
            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Usuario Autenticar(String login, String senha)
        {
            Usuario usu = null;

            using (BancoArmarinhoContext db = new BancoArmarinhoContext())
            {
                usu = (from u in db.Usuario where u.Usuario1 == login && u.Senha == senha select u).FirstOrDefault();
            }

            return usu;
        }


        public int VerificarPermissao(int? UsuCodigo, int setor)
        {
            if (UsuCodigo != null)
            {
                Usuario u = Consultar(UsuCodigo.Value);
                if (u.Permissao == 1 || u.Permissao == setor)
                {
                    return 1;
                }

                return 0;
            }

            return -1;
        }

    }
}
