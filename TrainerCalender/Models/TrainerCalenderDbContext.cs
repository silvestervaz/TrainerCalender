using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrainerCalender.Models;

public partial class TrainerCalenderDbContext : DbContext
{
    public TrainerCalenderDbContext()
    {
    }

    public TrainerCalenderDbContext(DbContextOptions<TrainerCalenderDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; } = null!;

    public virtual DbSet<Schedule> Schedules { get; set; } = null!;

    public virtual DbSet<Skill> Skills { get; set; } = null!;

    public virtual DbSet<TrainerCourse> TrainerCourses { get; set; } = null!;

    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnOrder(1);
            entity.Property(e => e.SkillId)
                .HasColumnOrder(2)
                .HasColumnName("Skill_id");

            entity.HasOne(d => d.Skill).WithMany(p => p.Courses)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Skills");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.ToTable("Schedule");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.Date)
                .HasColumnOrder(2)
                .HasColumnType("date");
            entity.Property(e => e.EndTime)
                .HasColumnOrder(4)
                .HasColumnType("datetime")
                .HasColumnName("End_Time");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(5);
            entity.Property(e => e.Mode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(6);
            entity.Property(e => e.SessionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnOrder(1)
                .HasColumnName("Session_Name");
            entity.Property(e => e.StartTime)
                .HasColumnOrder(3)
                .HasColumnType("datetime")
                .HasColumnName("Start_Time");
            entity.Property(e => e.TrainerCourseId)
                .HasColumnOrder(7)
                .HasColumnName("Trainer_Course_id");

            entity.HasOne(d => d.TrainerCourse).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TrainerCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Trainer_Course");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(1);
        });

        modelBuilder.Entity<TrainerCourse>(entity =>
        {
            entity.ToTable("Trainer_Course");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.CourseId)
                .HasColumnOrder(2)
                .HasColumnName("Course_Id");
            entity.Property(e => e.UserId)
                .HasColumnOrder(1)
                .HasColumnName("User_id");

            entity.HasOne(d => d.Course).WithMany(p => p.TrainerCourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trainer_Course_Courses");

            entity.HasOne(d => d.User).WithMany(p => p.TrainerCourses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trainer_Course_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.Emailid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(3);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(1)
                .HasColumnName("First_Name");
            entity.Property(e => e.IsAdmin).HasColumnOrder(5);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(2)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(4);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
