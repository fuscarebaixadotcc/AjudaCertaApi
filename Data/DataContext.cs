using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AjudaCerta.Models;
using AjudaCerta.Utils;

namespace AjudaCerta.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Dinheiro> Dinheiros { get; set; }
        public DbSet<ItemDoacao> ItemDoacoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Mobilia> Mobilias { get; set; }
        public DbSet<Eletrodomestico> Elestrodomesticos { get; set; }
        public DbSet<Roupa> Roupas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(u =>{
                u.HasKey(x => x.idUsuario);
                u.Property(x => x.idUsuario).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Pessoa>()
                .HasOne(e => e.usuario)
                .WithOne(e => e.pessoa)
                .HasForeignKey<Usuario>(e => e.idUsuario)
                .IsRequired();
            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("12345678", out byte[] hash, out byte[] salt);
            user.email = "joaod@gmail.com";
            user.senha = string.Empty;
            user.senhaHash = hash;
            user.senhaSalt = salt;

            modelBuilder.Entity<Usuario>().HasData(user);
            
        }

    }
}