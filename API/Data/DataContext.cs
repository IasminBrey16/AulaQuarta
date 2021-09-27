using Microsoft.EntityFrameworkCore;
using System;
using API.Models;

namespace API.Data
{

    public class DataContext : DbContext
    {
        //Construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Lista de classes de modelo que vão virar as tabelas no banco
        public DbSet<Produto> Produtos { get; set; }

    }

}