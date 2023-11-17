using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineSchool.Models;

public partial class OnlineSchoolContext : DbContext
{
    public OnlineSchoolContext()
    {
    }

    public OnlineSchoolContext(DbContextOptions<OnlineSchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=192.168.2.101;Database=OnlineSchool;User=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Courses", "OnlineSchool");

            entity.Property(e => e.Duration).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasMaxLength(100);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Teachers", "OnlineSchool");

            entity.Property(e => e.Experience).HasMaxLength(100);
            entity.Property(e => e.Fio)
                .HasMaxLength(100)
                .HasColumnName("FIO");
            entity.Property(e => e.Speciality).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
