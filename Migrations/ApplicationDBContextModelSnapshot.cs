﻿// <auto-generated />
using System;
using Cafeine_DinDin_Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cafeine_DinDin_Backend.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cafeine_DinDin_Backend.Entities.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherID")
                        .HasColumnType("int");

                    b.Property<string>("UrlCover")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("TeacherID");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("Cafeine_DinDin_Backend.Entities.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("image")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.ToTable("images");
                });

            modelBuilder.Entity("Cafeine_DinDin_Backend.Entities.Lesson", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("order")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("lessons");
                });

            modelBuilder.Entity("Cafeine_DinDin_Backend.Entities.Teacher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("teachers");
                });

            modelBuilder.Entity("Cafeine_DinDin_Backend.Entities.Course", b =>
                {
                    b.HasOne("Cafeine_DinDin_Backend.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherID");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Cafeine_DinDin_Backend.Entities.Lesson", b =>
                {
                    b.HasOne("Cafeine_DinDin_Backend.Entities.Course", null)
                        .WithMany("Lessons")
                        .HasForeignKey("CourseID");
                });

            modelBuilder.Entity("Cafeine_DinDin_Backend.Entities.Course", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
