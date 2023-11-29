﻿// <auto-generated />
using System;
using DCI_READ_REGITEY.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DCI_READ_REGITEY.Migrations
{
    [DbContext(typeof(DBDCI))]
    partial class DBDCIModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DCI_READ_REGITEY.Models.DciFixedAssetLog", b =>
                {
                    b.Property<string>("ComputerName")
                        .HasColumnName("COMPUTER_NAME")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("RegistryKey")
                        .HasColumnName("REGISTRY_KEY")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("RegistryValue")
                        .HasColumnName("REGISTRY_VALUE")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime>("UpdateDt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UPDATE_DT")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("ComputerName", "RegistryKey", "RegistryValue");

                    b.ToTable("DCI_FIXED_ASSET_LOG");
                });

            modelBuilder.Entity("DCI_READ_REGITEY.Models.DciFixedAssetSetting", b =>
                {
                    b.Property<string>("Hkey")
                        .HasColumnName("HKEY")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("AppPath")
                        .HasColumnName("APP_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("KeyOfPath")
                        .HasColumnName("KEY_OF_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("FixedStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FIXED_STATUS")
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))")
                        .HasComment("0 = ไม่ต้องทำการอัพเดรตข้อมูล 1 = อัพเดรตข้อมูล");

                    b.Property<string>("InsertBy")
                        .IsRequired()
                        .HasColumnName("INSERT_BY")
                        .HasColumnType("varchar(6)")
                        .HasMaxLength(6)
                        .IsUnicode(false);

                    b.Property<DateTime>("InsertDt")
                        .HasColumnName("INSERT_DT")
                        .HasColumnType("datetime");

                    b.HasKey("Hkey", "AppPath", "KeyOfPath")
                        .HasName("PK_DCI_FIXED_ASSET");

                    b.ToTable("DCI_FIXED_ASSET_SETTING");
                });
#pragma warning restore 612, 618
        }
    }
}