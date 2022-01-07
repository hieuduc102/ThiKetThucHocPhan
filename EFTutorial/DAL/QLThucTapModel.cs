using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EFTutorial.DAL
{
    public partial class QLThucTapModel : DbContext
    {
        public QLThucTapModel()
            : base("name=QLThucTapModelApp")
        {
        }

        public virtual DbSet<Nganh> Nganhs { get; set; }
        public virtual DbSet<ThucTap> ThucTaps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThucTap>()
                .Property(e => e.IDStudent)
                .IsUnicode(false);
        }
    }
}
