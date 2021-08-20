using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repositorio.Models
{
    public partial class BancoArmarinhoContext : DbContext
    {
        public BancoArmarinhoContext()
        {
        }

        public BancoArmarinhoContext(DbContextOptions<BancoArmarinhoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Compraitens> Compraitens { get; set; }
        public virtual DbSet<ContaPagar> ContaPagar { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Itensvendidos> Itensvendidos { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venda> Venda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=. ; Database= BancoArmarinho; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("categoria");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("cliente");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasColumnName("documento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Endereço)
                    .HasColumnName("endereço")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Inscricaoestadual)
                    .HasColumnName("inscricaoestadual")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pontos).HasColumnName("pontos");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("compra");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Fornecedor).HasColumnName("fornecedor");

                entity.Property(e => e.Observacao)
                    .HasColumnName("observacao")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Stat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.FornecedorNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.Fornecedor)
                    .HasConstraintName("FK_compra_fornecedor");
            });

            modelBuilder.Entity<Compraitens>(entity =>
            {
                entity.HasKey(e => e.Ccodigo);

                entity.ToTable("compraitens");

                entity.Property(e => e.Ccodigo).HasColumnName("ccodigo");

                entity.Property(e => e.Ccompra).HasColumnName("ccompra");

                entity.Property(e => e.Cquant).HasColumnName("cquant");

                entity.Property(e => e.Prodcod).HasColumnName("prodcod");

                entity.HasOne(d => d.CcompraNavigation)
                    .WithMany(p => p.Compraitens)
                    .HasForeignKey(d => d.Ccompra)
                    .HasConstraintName("FK_compraitens_compra");

                entity.HasOne(d => d.ProdcodNavigation)
                    .WithMany(p => p.Compraitens)
                    .HasForeignKey(d => d.Prodcod)
                    .HasConstraintName("FK_compraitens_produto");
            });

            modelBuilder.Entity<ContaPagar>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("fornecedor");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("cnpj")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Endereço)
                    .HasColumnName("endereço")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Itensvendidos>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("itensvendidos");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Produto).HasColumnName("produto");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.VendaCodigo).HasColumnName("venda_codigo");

                entity.HasOne(d => d.ProdutoNavigation)
                    .WithMany(p => p.Itensvendidos)
                    .HasForeignKey(d => d.Produto)
                    .HasConstraintName("FK_itensvendidos_produto");

                entity.HasOne(d => d.VendaCodigoNavigation)
                    .WithMany(p => p.ItensvendidosNavigation)
                    .HasForeignKey(d => d.VendaCodigo)
                    .HasConstraintName("FK_itensvendidos_venda");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("produto");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Categoria).HasColumnName("categoria");

                entity.Property(e => e.Fornecedor).HasColumnName("fornecedor");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Preço)
                    .HasColumnName("preço")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("usuario");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Permissao).HasColumnName("permissao");

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("venda");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Cliente).HasColumnName("cliente");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Desconto)
                    .HasColumnName("desconto")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Itensvendidos).HasColumnName("itensvendidos");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Usuario).HasColumnName("usuario");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.Cliente)
                    .HasConstraintName("FK_venda_venda");
            });
        }
    }
}
