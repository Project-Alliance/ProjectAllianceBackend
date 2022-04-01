﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectAlliance.Data;

namespace ProjectAlliance.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectAlliance.Models.Company", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("companyName")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("createdBy")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("ProjectAlliance.Models.DocumentSection", b =>
                {
                    b.Property<int>("sectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<string>("sectionDescription")
                        .HasColumnType("text");

                    b.Property<string>("sectionName")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("sectionId");

                    b.ToTable("documentSection");
                });

            modelBuilder.Entity("ProjectAlliance.Models.Files", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("DataFiles")
                        .HasColumnType("varbinary(4000)");

                    b.Property<string>("FileType")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("DocumentId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ProjectAlliance.Models.Project", b =>
                {
                    b.Property<int>("pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("Date");

                    b.Property<string>("ProjectTitle")
                        .HasColumnType("text");

                    b.Property<string>("companyProject")
                        .HasColumnType("text");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("Date");

                    b.Property<string>("progress")
                        .HasColumnType("text");

                    b.Property<string>("projectDescription")
                        .HasColumnType("text");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("Date");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.HasKey("pid");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectAlliance.Models.ProjectDocument", b =>
                {
                    b.Property<int>("documentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("documentDescription")
                        .HasColumnType("text");

                    b.Property<string>("documentFileExtension")
                        .HasColumnType("text");

                    b.Property<string>("documentName")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("documentStatus")
                        .HasColumnType("text");

                    b.Property<string>("documentVersion")
                        .HasColumnType("text");

                    b.Property<string>("filePath")
                        .HasColumnType("text");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<int>("sectionId")
                        .HasColumnType("int");

                    b.Property<string>("uploadBy")
                        .HasColumnType("text");

                    b.HasKey("documentId");

                    b.ToTable("projectDocument");
                });

            modelBuilder.Entity("ProjectAlliance.Models.ProjectTeam", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("pid")
                        .HasColumnType("int");

                    b.Property<string>("role")
                        .HasColumnType("text");

                    b.Property<int>("uid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ProjectTeams");
                });

            modelBuilder.Entity("ProjectAlliance.Models.SubTasks", b =>
                {
                    b.Property<int>("taskid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("Date");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("Date");

                    b.Property<string>("progress")
                        .HasColumnType("text");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("Date");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.Property<string>("taskTitle")
                        .HasColumnType("text");

                    b.HasKey("taskid");

                    b.ToTable("SubTasks");
                });

            modelBuilder.Entity("ProjectAlliance.Models.Tasks", b =>
                {
                    b.Property<int>("tid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("Date");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("TaskCost")
                        .HasColumnType("text");

                    b.Property<string>("TaskTitle")
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("Date");

                    b.Property<string>("progress")
                        .HasColumnType("text");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.HasKey("tid");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ProjectAlliance.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Lastlogin")
                        .HasColumnType("Date");

                    b.Property<string>("companyId")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("onlineStatus")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<string>("profilePic")
                        .HasColumnType("text");

                    b.Property<string>("role")
                        .HasColumnType("text");

                    b.Property<string>("userName")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
