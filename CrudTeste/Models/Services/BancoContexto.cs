using CrudTeste.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTeste.Models.Services
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
        {

        }


        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }

        public DbSet<PessoaFisica> PessoasFisicas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Endereco)
                .WithOne(p => p.Pessoa)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
