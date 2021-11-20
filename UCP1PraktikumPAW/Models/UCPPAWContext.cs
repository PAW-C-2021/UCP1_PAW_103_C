using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UCP1PraktikumPAW.Models
{
    public partial class UCPPAWContext : DbContext
    {
        public UCPPAWContext()
        {
        }

        public UCPPAWContext(DbContextOptions<UCPPAWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Garansi> Garansi { get; set; }
        public virtual DbSet<JasaKirim> JasaKirim { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pembayaran> Pembayaran { get; set; }
        public virtual DbSet<Penjual> Penjual { get; set; }
        public virtual DbSet<Produk> Produk { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.Property(e => e.IdCustomer)
                    .HasColumnName("ID_Customer")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlamatCustomer)
                    .HasColumnName("Alamat_Customer")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailCustomer)
                    .HasColumnName("Email_Customer")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaCustomer)
                    .HasColumnName("Nama_Customer")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHpCustomer)
                    .HasColumnName("No_Hp_Customer")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Garansi>(entity =>
            {
                entity.HasKey(e => e.IdGaransi);

                entity.Property(e => e.IdGaransi)
                    .HasColumnName("ID_Garansi")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdJasaKirim).HasColumnName("ID_JasaKirim");

                entity.Property(e => e.JenisGaransi)
                    .HasColumnName("Jenis_Garansi")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kerusakan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdJasaKirimNavigation)
                    .WithMany(p => p.Garansi)
                    .HasForeignKey(d => d.IdJasaKirim)
                    .HasConstraintName("FK_Garansi_JasaKirim");
            });

            modelBuilder.Entity<JasaKirim>(entity =>
            {
                entity.HasKey(e => e.IdJasaKirim);

                entity.Property(e => e.IdJasaKirim)
                    .HasColumnName("ID_JasaKirim")
                    .ValueGeneratedNever();

                entity.Property(e => e.HargaJasa).HasColumnName("Harga_Jasa");

                entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

                entity.Property(e => e.JenisLayanan)
                    .HasColumnName("Jenis_Layanan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaJasaKirim)
                    .HasColumnName("Nama_JasaKirim")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalDiterima)
                    .HasColumnName("Tanggal_Diterima")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.JasaKirim)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_JasaKirim_Order");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.IdOrder)
                    .HasColumnName("ID_Order")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdProduk).HasColumnName("ID_Produk");

                entity.Property(e => e.NamaProduk)
                    .HasColumnName("Nama_Produk")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalOrder)
                    .HasColumnName("Tanggal_Order")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalHarga).HasColumnName("Total_Harga");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.IdProdukNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdProduk)
                    .HasConstraintName("FK_Order_Produk");
            });

            modelBuilder.Entity<Pembayaran>(entity =>
            {
                entity.HasKey(e => e.IdPembayaran);

                entity.Property(e => e.IdPembayaran)
                    .HasColumnName("ID_Pembayaran")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

                entity.Property(e => e.TotalHarga).HasColumnName("Total_Harga");

                entity.Property(e => e.ViaPembayaran)
                    .HasColumnName("Via_Pembayaran")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Pembayaran)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Pembayaran_Customer");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Pembayaran)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_Pembayaran_Order");
            });

            modelBuilder.Entity<Penjual>(entity =>
            {
                entity.HasKey(e => e.IdPenjual);

                entity.Property(e => e.IdPenjual)
                    .HasColumnName("ID_Penjual")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlamatPenjual)
                    .HasColumnName("Alamat_Penjual")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailPenjual)
                    .HasColumnName("Email_Penjual")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPenjual)
                    .HasColumnName("Nama_Penjual")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHpPenjual)
                    .HasColumnName("No_Hp_Penjual")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produk>(entity =>
            {
                entity.HasKey(e => e.IdProduk);

                entity.Property(e => e.IdProduk)
                    .HasColumnName("ID_Produk")
                    .ValueGeneratedNever();

                entity.Property(e => e.HargaProduk).HasColumnName("Harga_Produk");

                entity.Property(e => e.IdPenjual).HasColumnName("ID_Penjual");

                entity.Property(e => e.NamaProduk)
                    .HasColumnName("Nama_Produk")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StokBarang).HasColumnName("Stok_Barang");

                entity.HasOne(d => d.IdPenjualNavigation)
                    .WithMany(p => p.Produk)
                    .HasForeignKey(d => d.IdPenjual)
                    .HasConstraintName("FK_Produk_Penjual");
            });
        }
    }
}
