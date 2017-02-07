using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Wikipages.Models
{
    public class WikipagesContext :DbContext
    {
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BluePages;integrated security=True");
        }
    }
}
