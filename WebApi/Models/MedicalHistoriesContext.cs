using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Models
{
    public partial class MedicalHistoriesContext : DbContext
    {
        public MedicalHistoriesContext()
        {
        }

        public MedicalHistoriesContext(DbContextOptions<MedicalHistoriesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=VICTOR\\MSSQLSERVER2019;Database=MedicalHistories;Trusted_Connection=true;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Diagnosis).HasMaxLength(50);

                entity.Property(e => e.PatientContacts).HasMaxLength(50);

                entity.Property(e => e.PatientFullName).HasMaxLength(50);

                entity.Property(e => e.Treatment).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
