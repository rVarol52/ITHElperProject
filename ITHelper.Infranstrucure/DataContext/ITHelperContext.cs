using ITHelper.Infranstrucure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Infranstrucure.DataContext
{
    public class ITHelperContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BN-1043;initial Catalog=ITHelperDb;integrated Security=true;TrustServerCertificate=true");
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Blog> Bloglar { get; set; }
        public DbSet<Etiket> Etiketler { get; set; }
        public DbSet<BlogEtiket> BlogEtiketler { get;set; }


    }


}
