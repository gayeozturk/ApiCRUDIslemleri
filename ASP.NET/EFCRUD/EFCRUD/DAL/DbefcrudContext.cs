using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCRUD.DAL;

public partial class DbefcrudContext : DbContext
{
    public DbefcrudContext()
    {
    }

    public DbefcrudContext(DbContextOptions<DbefcrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Iller> Illers { get; set; }

    public virtual DbSet<Kullanici> Kullanicis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-S6H0KV0O\\SQLEXPRESS; Initial Catalog=DBEFCRUD; Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Iller>(entity =>
        {
            entity.ToTable("Iller");
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.ToTable("Kullanici");

            entity.HasOne(d => d.Il).WithMany(p => p.Kullanicis)
                .HasForeignKey(d => d.IlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kullanici_Iller");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
