using System;
using System.Collections.Generic;
using System.Linq;
using DocuHub.BOL;
using Microsoft.EntityFrameworkCore;

namespace DocuHub.DAL
{

    public partial class DocuHubDbContext:DbContext
    {
        
        public DocuHubDbContext(DbContextOptions<DocuHubDbContext> options):base(options)
        {
            
        }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<RingBinder> RingBinders { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>(entity =>
            {
                entity.HasKey(e => e.PageId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Guid)
                    .HasName("GUID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Parent)
                    .HasName("FK_Pages_Parent_idx");

                entity.HasIndex(e => e.RingBinderId)
                    .HasName("FK_Pages_RingBinderId_idx");

                entity.Property(e => e.PageId).HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasComment("Treść dokumentu md bądź ścieżka do zasobu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("GUID")
                    .HasColumnType("varchar(36)")
                    .HasDefaultValueSql("(uuid())")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.PageType)
                    .HasColumnType("tinyint(4)")
                    .HasComment(@"0 - dokument MD
1 - dokument PDF");

                entity.Property(e => e.Parent).HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.RingBinderId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(1024)")
                    .HasDefaultValueSql("'New Page'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasForeignKey(d => d.Parent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pages_Parent");

                entity.HasOne(d => d.RingBinder)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.RingBinderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pages_RingBinderId");
            });

            modelBuilder.Entity<RingBinder>(entity =>
            {
                entity.HasKey(e => e.RingBinderId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Guid)
                    .HasName("GUID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.RingBinderId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Color)
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("tinytext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("GUID")
                    .HasColumnType("varchar(36)")
                    .HasDefaultValueSql("(uuid())")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Pinned)
                    .IsRequired()
                    .HasColumnType("INT(1)")
                    .HasDefaultValueSql("0");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}