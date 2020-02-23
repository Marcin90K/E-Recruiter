﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitingSystem.Data.Contexts;

namespace RecruitingSystem.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200204210710_entity-classes-improvement_04022020")]
    partial class entityclassesimprovement_04022020
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuildingNumber");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("FlatNumber");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ExpectedSalary");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.CandidateBasicData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressId");

                    b.Property<Guid>("CandidateId");

                    b.Property<Guid>("PersonBasicDataId");

                    b.Property<int>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CandidateId")
                        .IsUnique();

                    b.HasIndex("PersonBasicDataId");

                    b.ToTable("CandidateBasicDatas");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.CandidateJobOffer", b =>
                {
                    b.Property<Guid>("CandidateId");

                    b.Property<Guid>("JobOfferId");

                    b.HasKey("CandidateId", "JobOfferId");

                    b.HasIndex("JobOfferId");

                    b.ToTable("CandidateJobOffers");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Education", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CandidateId");

                    b.Property<string>("CourseName")
                        .IsRequired();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("SchoolName")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeCompanyId");

                    b.Property<Guid>("PersonBasicDataId");

                    b.HasKey("Id");

                    b.HasIndex("PersonBasicDataId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CandidateId");

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("Duties")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("JobTitle")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.JobOffer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfAdding");

                    b.Property<DateTime>("DateOfExpiration");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<Guid>("EmployeeId");

                    b.Property<Guid>("JobPositionId");

                    b.Property<int>("ReferenceNumber");

                    b.Property<string>("Requirements")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("JobPositionId");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.JobPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("JobPositions");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Department");

                    b.Property<Guid>("EmployeeId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.PersonBasicData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("PersonBasicDatas");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Recruiter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EmployeeId");

                    b.Property<Guid?>("ManagerId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Recruiters");
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.CandidateBasicData", b =>
                {
                    b.HasOne("RecruitingSystem.Data.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecruitingSystem.Data.Entities.Candidate", "Candidate")
                        .WithOne("BasicData")
                        .HasForeignKey("RecruitingSystem.Data.Entities.CandidateBasicData", "CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecruitingSystem.Data.Entities.PersonBasicData", "PersonBasicData")
                        .WithMany()
                        .HasForeignKey("PersonBasicDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.CandidateJobOffer", b =>
                {
                    b.HasOne("RecruitingSystem.Data.Entities.Candidate", "Candidate")
                        .WithMany("CandidateJobOffers")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecruitingSystem.Data.Entities.JobOffer", "JobOffer")
                        .WithMany("CandidateJobOffers")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Education", b =>
                {
                    b.HasOne("RecruitingSystem.Data.Entities.Candidate", "Candidate")
                        .WithMany("Educations")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Employee", b =>
                {
                    b.HasOne("RecruitingSystem.Data.Entities.PersonBasicData", "PersonBasicData")
                        .WithMany()
                        .HasForeignKey("PersonBasicDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Experience", b =>
                {
                    b.HasOne("RecruitingSystem.Data.Entities.Candidate", "Candidate")
                        .WithMany("Experiences")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.JobOffer", b =>
                {
                    b.HasOne("RecruitingSystem.Data.Entities.Recruiter", "Owner")
                        .WithMany("OwnedJobOffers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecruitingSystem.Data.Entities.JobPosition", "JobPosition")
                        .WithMany()
                        .HasForeignKey("JobPositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Manager", b =>
                {
                    b.HasOne("RecruitingSystem.Data.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecruitingSystem.Data.Entities.Recruiter", b =>
                {
                    b.HasOne("RecruitingSystem.Data.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecruitingSystem.Data.Entities.Manager", "Manager")
                        .WithMany("Recruiters")
                        .HasForeignKey("ManagerId");
                });
#pragma warning restore 612, 618
        }
    }
}
