using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hmp_TvcLesson12.Models;

public partial class HmpTvcLesson12Context : DbContext
{
    public HmpTvcLesson12Context()
    {
    }

    public HmpTvcLesson12Context(DbContextOptions<HmpTvcLesson12Context> options)
        : base(options)
    {
    }

    public virtual DbSet<HmpProduct> HmpProducts { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Hmp_TvcLesson12;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HmpProduct>(entity =>
        {
            entity.HasKey(e => e.HmpId).HasName("PK__HmpProdu__D2699119BBF9F52F");

            entity.Property(e => e.HmpCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HmpImage).HasMaxLength(255);
            entity.Property(e => e.HmpName).HasMaxLength(255);
            entity.Property(e => e.HmpPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HmpSalePrice).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
