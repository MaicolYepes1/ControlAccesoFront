using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebControlAcceso.WEB.Models
{
    public partial class SecurityExpertContext : DbContext
    {
        public SecurityExpertContext()
        {
        }

        public SecurityExpertContext(DbContextOptions<SecurityExpertContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserCustomFieldGroupDatum> UserCustomFieldGroupData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=cogrnw2k1006\\imocon;Database=SecurityExpert;User Id=powerbi;Password=Mane1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCustomFieldGroupDatum>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CustomFieldId })
                    .HasName("pk_UserCustomFieldGroupData__UserID_CustomFieldID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CustomFieldId).HasColumnName("CustomFieldID");

                entity.Property(e => e.CustomFieldBooleanData)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CustomFieldDateTimeData).HasColumnType("datetime");

                entity.Property(e => e.CustomFieldTextData)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.UserCustomFieldGroupDataId).HasColumnName("UserCustomFieldGroupDataID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
