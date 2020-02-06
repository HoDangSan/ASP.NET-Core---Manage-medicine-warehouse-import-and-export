using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MWIE.Models.Entity;

namespace MWIE.Models
{
    public class MWIEDbContext : IdentityDbContext
    {
        public MWIEDbContext(DbContextOptions<MWIEDbContext> options) : base(options)
        {
        }

        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<GroupDrug> GroupDrugs { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<ReceiptImport> ReceiptImports { get; set; }
        public DbSet<ReceiptExport> ReceiptExports { get; set; }
        public DbSet<ReceiptLiquidation> ReceiptLiquidations { get; set; }
        public DbSet<DetailReceiptImport> DetailReceiptImports { get; set; }
        public DbSet<DetailReceiptExport> DetailReceiptExports { get; set; }
        public DbSet<DetailReceiptLiquidation> DetailReceiptLiquidations { get; set; }   
    }
}