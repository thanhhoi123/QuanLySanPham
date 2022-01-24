using _102190314_PhamThanhHoi.DTO;
using _102190314_PhamThanhHoi.View;
using System;
using System.Data.Entity;
using System.Linq;

namespace _102190314_PhamThanhHoi
{
    public class QLSP : DbContext
    {        
        public QLSP()
            : base("name=QLSP")
        {
            Database.SetInitializer<QLSP>(new CreateDB());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<SP> SPs { get; set; }
        public virtual DbSet<NCC> NCCs { get; set; }
        public virtual DbSet<TP> TPs { get; set; }
    }

 
}