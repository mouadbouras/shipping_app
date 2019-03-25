using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyApp.DataAccess.DataAccess
{
    public partial class shippingcoContext : DbContext
    {
        string ConnString;
        public shippingcoContext()
        {
            this.ConnString = "";
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
        public virtual DbSet<UserAuth> UserAuth { get; set; }
        public virtual DbSet<UserAuthDetails> UserAuthDetails { get; set; }
        public virtual DbSet<UserAuthRole> UserAuthRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = Helper.LoadConnSgring().connString;            

                optionsBuilder.UseSqlServer(connString);

                this.ConnString = connString;

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

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

                entity.Property(e => e.Height).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Length).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MassUnit)
                    .HasColumnName("Mass_Unit")
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Width).HasColumnType("decimal(18, 2)");
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

            modelBuilder.Entity<UserAuth>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("idx_userauth_email");

                entity.HasIndex(e => e.UserName)
                    .HasName("idx_userauth_username");

                entity.Property(e => e.Address)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.BirthDateRaw)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Culture)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.DigestHa1Hash)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginAttempt).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.LockedDate).HasColumnType("datetime");

                entity.Property(e => e.MailAddress)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Meta).IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Permissions).IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryEmail)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.RecoveryToken)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.RefIdStr)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Roles).IsUnicode(false);

                entity.Property(e => e.Salt)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAuthDetails>(entity =>
            {
                entity.Property(e => e.AccessToken)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.AccessTokenSecret)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.BirthDateRaw)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Culture)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Items).IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.MailAddress)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Meta).IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Provider)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.RefIdStr)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.RefreshTokenExpiry).HasColumnType("datetime");

                entity.Property(e => e.RequestToken)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.RequestTokenSecret)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAuthRole>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Meta).IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Permission)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.RefIdStr)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
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
