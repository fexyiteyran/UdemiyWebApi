using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemiyWebApi.DAL.Entities;

namespace UdemiyWebApi.DAL.Context
{
    public class UdemiyWebApiContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server = DESKTOP-NV0GSA0\SQLEXPRESS; Database = UdemyWebApi; Trusted_Connection = True; MultipleActiveResultSets = true");

            base.OnConfiguring(optionsBuilder); 
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
