﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volunteering.Migrations.DataAccessLayer.SqlServer;

namespace Volunteering.Migrations.Migrations.Development.SqlServer
{
    [DbContext(typeof(DevelopmentSqlServerDbContext))]
    partial class DevelopmentSqlServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Volunteering.Migrations.Models.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("creation_date")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("DailyLesson")
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasColumnName("daily_lesson");

                    b.Property<string>("Description")
                        .HasMaxLength(144)
                        .HasColumnType("nvarchar(144)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasColumnName("name");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasColumnName("place");

                    b.Property<int>("StudentCouse")
                        .HasColumnType("int")
                        .HasColumnName("student_course");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasColumnName("student_name");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .IsClustered();

                    b.ToTable("activity");
                });

            modelBuilder.Entity("Volunteering.Migrations.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("ActivityId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("activity_id");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("creation_date")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<byte>("DayOfWeek")
                        .HasColumnType("tinyint")
                        .HasColumnName("day_of_week");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time")
                        .HasColumnName("end");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time")
                        .HasColumnName("start");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("ActivityId");

                    b.ToTable("schedule");
                });

            modelBuilder.Entity("Volunteering.Migrations.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("creation_date")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("dni");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasColumnName("email");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasColumnName("last_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("phone_number");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasAlternateKey("DNI")
                        .IsClustered(false);

                    b.ToTable("user");
                });

            modelBuilder.Entity("Volunteering.Migrations.Models.UserSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("schedule_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("UserId");

                    b.ToTable("userschedule");
                });

            modelBuilder.Entity("Volunteering.Migrations.Models.Schedule", b =>
                {
                    b.HasOne("Volunteering.Migrations.Models.Activity", "Activity")
                        .WithMany("ScheduleRelation")
                        .HasForeignKey("ActivityId")
                        .HasConstraintName("fk_sch_act")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Activity");
                });

            modelBuilder.Entity("Volunteering.Migrations.Models.UserSchedule", b =>
                {
                    b.HasOne("Volunteering.Migrations.Models.Schedule", "Schedule")
                        .WithMany("UserScheduleRelation")
                        .HasForeignKey("ScheduleId")
                        .HasConstraintName("FK_Schedules_UserSchedule")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Volunteering.Migrations.Models.User", "User")
                        .WithMany("UserScheduleRelation")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Users_UserSchedule")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Volunteering.Migrations.Models.Activity", b =>
                {
                    b.Navigation("ScheduleRelation");
                });

            modelBuilder.Entity("Volunteering.Migrations.Models.Schedule", b =>
                {
                    b.Navigation("UserScheduleRelation");
                });

            modelBuilder.Entity("Volunteering.Migrations.Models.User", b =>
                {
                    b.Navigation("UserScheduleRelation");
                });
#pragma warning restore 612, 618
        }
    }
}
