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

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Doacao> Doacao { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Dinheiro> Dinheiro { get; set; }
        public DbSet<ItemDoacao> ItemDoacao { get; set; }
        public DbSet<ItemDoacaoDoado> ItemDoacaoDoado { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Mobilia> Mobilia { get; set; }
        public DbSet<Eletrodomestico> Elestrodomestico { get; set; }
        public DbSet<Roupa> Roupa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dinheiro>()
                .Property(d => d.idDinheiro)
                .ValueGeneratedNever();
            modelBuilder.Entity<ItemDoacaoDoado>()
                .HasKey(idd => idd.idDoacao, idd.idItem);
           /* modelBuilder.Entity<Usuario>(u =>{
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
            */
        }

    }
}