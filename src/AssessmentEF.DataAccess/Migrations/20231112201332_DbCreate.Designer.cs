﻿// <auto-generated />
using System;
using AssessmentEF.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssessmentEF.DataAccess.Migrations
{
    [DbContext(typeof(EntityFrameworkDbContext))]
    [Migration("20231112201332_DbCreate")]
    partial class DbCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AssessmentEF.Entities.Models.Personnel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("BirthDate");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("Gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Name");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Surname");

                    b.HasKey("ID");

                    b.ToTable("Personnels", "dbo");
                });

            modelBuilder.Entity("AssessmentEF.Entities.Models.Salary", b =>
                {
                    b.Property<int>("PersonnelId")
                        .HasColumnType("int")
                        .HasColumnName("PersonnelId");

                    b.Property<int>("Department")
                        .HasColumnType("int")
                        .HasColumnName("Department");

                    b.Property<decimal>("PersonnelSalary")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Salary");

                    b.HasKey("PersonnelId");

                    b.ToTable("Salaries", "dbo");
                });

            modelBuilder.Entity("AssessmentEF.Entities.Models.Salary", b =>
                {
                    b.HasOne("AssessmentEF.Entities.Models.Personnel", "Personnel")
                        .WithOne("Salary")
                        .HasForeignKey("AssessmentEF.Entities.Models.Salary", "PersonnelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("personnel_salary_id_fk");

                    b.Navigation("Personnel");
                });

            modelBuilder.Entity("AssessmentEF.Entities.Models.Personnel", b =>
                {
                    b.Navigation("Salary")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}