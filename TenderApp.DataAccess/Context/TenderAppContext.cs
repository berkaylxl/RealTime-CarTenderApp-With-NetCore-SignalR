using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Entities;

namespace TenderApp.DataAccess.Context
{

    public class TenderAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-BEKO;Database=Tender;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
