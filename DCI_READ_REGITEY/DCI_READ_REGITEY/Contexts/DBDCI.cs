using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DCI_READ_REGITEY.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DCI_READ_REGITEY.Contexts
{
    public partial class DBDCI : DbContext
    {
        public DBDCI()
        {
        }

        public DBDCI(DbContextOptions<DBDCI> options)
            : base(options)
        {
        }

        public virtual DbSet<DciFixedAssetLog> DciFixedAssetLog { get; set; }
        public virtual DbSet<DciFixedAssetSetting> DciFixedAssetSetting { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.226.145;Database=dbDci;TrustServerCertificate=True;uid=sa;password=decjapan");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DciFixedAssetLog>(entity =>
            {
                entity.HasKey(e => new { e.ComputerName, e.RegistryId, e.RegistryKey })
                    .HasName("PK_DCI_FIXED_ASSET_LOG_1");

                entity.ToTable("DCI_FIXED_ASSET_LOG");

                entity.Property(e => e.ComputerName)
                    .HasColumnName("COMPUTER_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistryId).HasColumnName("REGISTRY_ID");

                entity.Property(e => e.RegistryKey)
                    .HasColumnName("REGISTRY_KEY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistryValue)
                    .IsRequired()
                    .HasColumnName("REGISTRY_VALUE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DciFixedAssetSetting>(entity =>
            {
                entity.HasKey(e => new { e.RegistryId, e.RegistryRoot });

                entity.ToTable("DCI_FIXED_ASSET_SETTING");

                entity.Property(e => e.RegistryId)
                    .HasColumnName("REGISTRY_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RegistryRoot)
                    .HasColumnName("REGISTRY_ROOT")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FixedStatus)
                    .HasColumnName("FIXED_STATUS")
                    .HasComment("0 = ไม่ต้องทำการอัพเดรตข้อมูล 1 = อัพเดรตข้อมูล");

                entity.Property(e => e.InsertBy)
                    .IsRequired()
                    .HasColumnName("INSERT_BY")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDt)
                    .HasColumnName("INSERT_DT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
