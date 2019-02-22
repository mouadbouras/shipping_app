using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyApp.DataAccess.DataAccess
{
    public partial class shippingcoContext : DbContext
    {
        public shippingcoContext()
        {
        }

        public shippingcoContext(DbContextOptions<shippingcoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Parcel> Parcel { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
        public virtual DbSet<ShippmentUnit> ShippmentUnit { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = Helper.LoadConnSgring().connString;
                if(connString==null)
                {
                    connString = ConfigurationManager.AppSettings["connString"];
                }

                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Company).IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Currency).IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Estimate).IsUnicode(false);

                entity.Property(e => e.Eta).HasColumnType("datetime");

                entity.Property(e => e.FromId).HasColumnName("From_Id");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.LabelUrl)
                    .HasColumnName("LabelURL")
                    .IsUnicode(false);

                entity.Property(e => e.ParcelId).HasColumnName("Parcel_Id");

                entity.Property(e => e.Provider).IsUnicode(false);

                entity.Property(e => e.ServiceLevel).IsUnicode(false);

                entity.Property(e => e.ToId).HasColumnName("To_Id");

                entity.Property(e => e.TrackingNumber).IsUnicode(false);

                entity.Property(e => e.TrackingUrl)
                    .HasColumnName("TrackingURL")
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_id");
            });

            modelBuilder.Entity<Parcel>(entity =>
            {
                entity.Property(e => e.DistanceUnit)
                    .HasColumnName("Distance_Unit")
                    .IsUnicode(false);

                entity.Property(e => e.MassUnit)
                    .HasColumnName("Mass_Unit")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Currency).IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Estimate).IsUnicode(false);

                entity.Property(e => e.FromId).HasColumnName("From_Id");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.ParcelId).HasColumnName("Parcel_Id");

                entity.Property(e => e.Provider).IsUnicode(false);

                entity.Property(e => e.ServiceLevel).IsUnicode(false);

                entity.Property(e => e.ToId).HasColumnName("To_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });

            modelBuilder.Entity<ShippmentUnit>(entity =>
            {
                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Company).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PostalCode).IsUnicode(false);

                entity.Property(e => e.Province).IsUnicode(false);

                entity.Property(e => e.StreetAddress).IsUnicode(false);

                entity.Property(e => e.StreetNumber).IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });
        }
    }
}
