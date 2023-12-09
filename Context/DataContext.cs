using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apidotnet.Entity;
using Microsoft.EntityFrameworkCore;

namespace apidotnet.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<Livro> Livros { get; set; }
    }
}