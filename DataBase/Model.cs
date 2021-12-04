using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataBase
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelConexion")
        {
        }

        public virtual DbSet<Desserts> Desserts { get; set; }
        public virtual DbSet<Drinks> Drinks { get; set; }
        public virtual DbSet<FirstCourses> FirstCourses { get; set; }
        public virtual DbSet<MainCourses> MainCourses { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<VW_Orders> VW_Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desserts>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Desserts>()
                .Property(e => e.PRICE)
                .HasPrecision(13, 2);

            modelBuilder.Entity<Desserts>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Desserts1)
                .HasForeignKey(e => e.DESSERTS);

            modelBuilder.Entity<Drinks>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Drinks>()
                .Property(e => e.PRICE)
                .HasPrecision(13, 2);

            modelBuilder.Entity<Drinks>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Drinks1)
                .HasForeignKey(e => e.DRINKS);

            modelBuilder.Entity<FirstCourses>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<FirstCourses>()
                .Property(e => e.PRICE)
                .HasPrecision(13, 2);

            modelBuilder.Entity<FirstCourses>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.FirstCourses)
                .HasForeignKey(e => e.FIRST_COURSE);

            modelBuilder.Entity<MainCourses>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<MainCourses>()
                .Property(e => e.PRICE)
                .HasPrecision(13, 2);

            modelBuilder.Entity<MainCourses>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.MainCourses)
                .HasForeignKey(e => e.MAIN_COURSE);

            modelBuilder.Entity<Orders>()
                .Property(e => e.CLIENTE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.SUB_TOTAL)
                .HasPrecision(13, 2);

            modelBuilder.Entity<Orders>()
                .Property(e => e.ITBIS)
                .HasPrecision(13, 2);

            modelBuilder.Entity<Orders>()
                .Property(e => e.TOTAL)
                .HasPrecision(13, 2);

            modelBuilder.Entity<States>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<States>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.States1)
                .HasForeignKey(e => e.STATES);

            modelBuilder.Entity<VW_Orders>()
                .Property(e => e.CLIENTE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<VW_Orders>()
                .Property(e => e.FirstCourses)
                .IsUnicode(false);

            modelBuilder.Entity<VW_Orders>()
                .Property(e => e.MainCourses)
                .IsUnicode(false);

            modelBuilder.Entity<VW_Orders>()
                .Property(e => e.Desserts)
                .IsUnicode(false);

            modelBuilder.Entity<VW_Orders>()
                .Property(e => e.Drinks)
                .IsUnicode(false);

            modelBuilder.Entity<VW_Orders>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<VW_Orders>()
                .Property(e => e.SUB_TOTAL)
                .HasPrecision(13, 2);

            modelBuilder.Entity<VW_Orders>()
                .Property(e => e.ITBIS)
                .HasPrecision(13, 2);

            modelBuilder.Entity<VW_Orders>()
                .Property(e => e.TOTAL)
                .HasPrecision(13, 2);
        }
    }
}
