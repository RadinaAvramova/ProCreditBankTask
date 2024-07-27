using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProCreditBankZadacha
{


    public class ApplicationDbContext : DbContext
    {
        public DbSet<ParsedSwiftMT799Message> ParsedMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=mydatabase.db");
    }

}
