﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectAlliance.Data;

namespace ProjectAlliance.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20220614182048_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectAlliance.Models.BoardCard", b =>
                {
                    b.Property<int>("cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("label")
                        .HasColumnType("text");

                    b.Property<string>("lid")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("cid");

                    b.ToTable("boardCard");
                });

            modelBuilder.Entity("ProjectAlliance.Models.BoardLane", b =>
                {
                    b.Property<int>("lid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("label")
                        .HasColumnType("text");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("lid");

                    b.ToTable("boardlane");
                });

            modelBuilder.Entity("ProjectAlliance.Models.Comments", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("comId")
                        .HasColumnType("text");

                    b.Property<int>("reqId")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("ProjectAlliance.Models.CommentsReplies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("comId")
                        .HasColumnType("text");

                    b.Property<string>("parentCommentId")
                        .HasColumnType("text");

                    b.Property<string>("text")
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("CommentsReplies");
                });

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

            modelBuilder.Entity("ProjectAlliance.Models.Design", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("folderId")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Designs");
                });

            modelBuilder.Entity("ProjectAlliance.Models.DesignAttachment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AttachmentExtension")
                        .HasColumnType("text");

                    b.Property<string>("AttachmentPath")
                        .HasColumnType("text");

                    b.Property<int>("designId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("DesignAttachments");
                });

            modelBuilder.Entity("ProjectAlliance.Models.DesignFolder", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("folderType")
                        .HasColumnType("text");

                    b.Property<DateTime>("modifeidOn")
                        .HasColumnType("Date");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("folders");
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

            modelBuilder.Entity("ProjectAlliance.Models.EmailAttachment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("emailId")
                        .HasColumnType("int");

                    b.Property<string>("ext")
                        .HasColumnType("text");

                    b.Property<string>("fakeName")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("path")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("mailAttachments");
                });

            modelBuilder.Entity("ProjectAlliance.Models.Enviorment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("RequirementId")
                        .HasColumnType("int");

                    b.Property<string>("TestType")
                        .HasColumnType("text");

                    b.Property<bool>("isRequirementBased")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<string>("summary")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("enviornment");
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

            modelBuilder.Entity("ProjectAlliance.Models.Goals", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("Date");

                    b.Property<string>("goalDescription")
                        .HasColumnType("text");

                    b.Property<string>("goalName")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("startDate")
                        .HasColumnType("Date");

                    b.HasKey("id");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("ProjectAlliance.Models.LabResource", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnvId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("value")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("labResource");
                });

            modelBuilder.Entity("ProjectAlliance.Models.Permisions", b =>
                {
                    b.Property<int>("permisionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Delete")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("create")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("permisionTitle")
                        .HasColumnType("text");

                    b.Property<bool>("read")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("update")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("permisionId");

                    b.ToTable("permisions");
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

            modelBuilder.Entity("ProjectAlliance.Models.ProjectSchedule", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AssignTo")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("dependancies")
                        .HasColumnType("text");

                    b.Property<DateTime>("end")
                        .HasColumnType("datetime");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("progress")
                        .HasColumnType("int");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime");

                    b.HasKey("id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Schedule");
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

            modelBuilder.Entity("ProjectAlliance.Models.QualitySchedule", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AssignTo")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("dependancies")
                        .HasColumnType("text");

                    b.Property<DateTime>("end")
                        .HasColumnType("datetime");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("progress")
                        .HasColumnType("int");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime");

                    b.HasKey("id");

                    b.HasIndex("ProjectId");

                    b.ToTable("QualitySchedule");
                });

            modelBuilder.Entity("ProjectAlliance.Models.RecevidMail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("company")
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("from")
                        .HasColumnType("text");

                    b.Property<bool>("isRead")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isStared")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("subject")
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("DateTime");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<string>("to")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("mail");
                });

            modelBuilder.Entity("ProjectAlliance.Models.RequirementAttachment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AttachmentExtension")
                        .HasColumnType("text");

                    b.Property<string>("AttachmentPath")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("requirementId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("RequirementAttachments");
                });

            modelBuilder.Entity("ProjectAlliance.Models.RequirementModule", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("modifeidOn")
                        .HasColumnType("Date");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("RequirementsModule");
                });

            modelBuilder.Entity("ProjectAlliance.Models.Requirements", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("modifeidOn")
                        .HasColumnType("Date");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("text");

                    b.Property<int>("moduleId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("requirementDescription")
                        .HasColumnType("text");

                    b.Property<string>("requirementType")
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("requirements");
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

            modelBuilder.Entity("ProjectAlliance.Models.TestCaseAttachment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AttachmentExtension")
                        .HasColumnType("text");

                    b.Property<string>("AttachmentPath")
                        .HasColumnType("text");

                    b.Property<string>("AtttachmentType")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("testresultId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("TestCaseAttachment");
                });

            modelBuilder.Entity("ProjectAlliance.Models.TestCases", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("categoryName")
                        .HasColumnType("text");

                    b.Property<string>("categoryType")
                        .HasColumnType("text");

                    b.Property<int>("testPlanId")
                        .HasColumnType("int");

                    b.Property<string>("testType")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("testCases");
                });

            modelBuilder.Entity("ProjectAlliance.Models.TestPlan", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("EnvId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("testPlan");
                });

            modelBuilder.Entity("ProjectAlliance.Models.TestResult", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("testId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("testResult");
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

            modelBuilder.Entity("ProjectAlliance.Models.ProjectSchedule", b =>
                {
                    b.HasOne("ProjectAlliance.Models.Project", "pid")
                        .WithMany("projectSchedules")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectAlliance.Models.QualitySchedule", b =>
                {
                    b.HasOne("ProjectAlliance.Models.Project", "pid")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}