﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskProject.Model;

#nullable disable

namespace TaskProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskProject.Model.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Assignee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StatusID");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Assignee = "isamil.sudani2022@gmail.com",
                            Description = " Description of firt task is here ",
                            DueDate = new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2114),
                            StatusID = 1,
                            Title = " first task title"
                        },
                        new
                        {
                            Id = 2,
                            Assignee = "isamil.sudani2022@gmail.com",
                            Description = " Description of second task is here ",
                            DueDate = new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2131),
                            StatusID = 1,
                            Title = "  second task title"
                        },
                        new
                        {
                            Id = 3,
                            Assignee = "isamil.sudani2022@gmail.com",
                            Description = " Description of third task is here ",
                            DueDate = new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2133),
                            StatusID = 1,
                            Title = " third task title"
                        },
                        new
                        {
                            Id = 4,
                            Assignee = "isamil.sudani2022@gmail.com",
                            Description = " Description of fourth task is here ",
                            DueDate = new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2134),
                            StatusID = 1,
                            Title = " fourth task title"
                        },
                        new
                        {
                            Id = 5,
                            Assignee = "isamil.sudani2022@gmail.com",
                            Description = " Description of Fifth task is here ",
                            DueDate = new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2135),
                            StatusID = 1,
                            Title = " Fifth task title"
                        },
                        new
                        {
                            Id = 6,
                            Assignee = "isamil.sudani2022@gmail.com",
                            Description = " Description of Sixth task is here ",
                            DueDate = new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2136),
                            StatusID = 1,
                            Title = " Sixth task title"
                        },
                        new
                        {
                            Id = 7,
                            Assignee = "isamil.sudani2022@gmail.com",
                            Description = " Description of Seventh task is here ",
                            DueDate = new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2138),
                            StatusID = 1,
                            Title = " Seventh task title"
                        },
                        new
                        {
                            Id = 8,
                            Assignee = "isamil.sudani2022@gmail.com",
                            Description = " Description of Eighth task is here ",
                            DueDate = new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2139),
                            StatusID = 1,
                            Title = " Eighth task title"
                        },
                        new
                        {
                            Id = 9,
                            Assignee = "isamil.sudani2022@gmail.com",
                            Description = " Description of Ninth task is here ",
                            DueDate = new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2140),
                            StatusID = 1,
                            Title = " Ninth task title"
                        },
                        new
                        {
                            Id = 10,
                            Assignee = "isamil.sudani2022@gmail.com",
                            Description = " Description of tenth task is here ",
                            DueDate = new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2141),
                            StatusID = 1,
                            Title = " tenth task title"
                        });
                });

            modelBuilder.Entity("TaskProject.Model.TaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Not Started"
                        },
                        new
                        {
                            Id = 2,
                            Name = " In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("TaskProject.Model.Task", b =>
                {
                    b.HasOne("TaskProject.Model.TaskStatus", "Status")
                        .WithMany("Tasks")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TaskProject.Model.TaskStatus", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
