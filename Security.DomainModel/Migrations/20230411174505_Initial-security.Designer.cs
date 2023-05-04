﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Security.DomainModel.Model;

#nullable disable

namespace Security.DomainModel.Migrations
{
    [DbContext(typeof(SecurityContext))]
    [Migration("20230411174505_Initial-security")]
    partial class Initialsecurity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Security.DomainModel.Model.ProjectAction", b =>
                {
                    b.Property<int>("ProjectActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectActionId"), 1L, 1);

                    b.Property<string>("PersianTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProjectActionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProjectControllerId")
                        .HasColumnType("int");

                    b.HasKey("ProjectActionId");

                    b.HasIndex("ProjectControllerId");

                    b.ToTable("ProjectActions");
                });

            modelBuilder.Entity("Security.DomainModel.Model.ProjectArea", b =>
                {
                    b.Property<int>("ProjectAreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectAreaId"), 1L, 1);

                    b.Property<string>("PersianTitle")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ProjectAreaName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProjectAreaId");

                    b.ToTable("ProjectAreas");
                });

            modelBuilder.Entity("Security.DomainModel.Model.ProjectController", b =>
                {
                    b.Property<int>("ProjectControllerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectControllerId"), 1L, 1);

                    b.Property<string>("PersianTitle")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ProjectAreaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ProjectControllerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProjectControllerId");

                    b.HasIndex("ProjectAreaId");

                    b.ToTable("ProjectControllers");
                });

            modelBuilder.Entity("Security.DomainModel.Model.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Security.DomainModel.Model.RoleAction", b =>
                {
                    b.Property<int>("RoleActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleActionId"), 1L, 1);

                    b.Property<bool>("HasPermission")
                        .HasColumnType("bit");

                    b.Property<int>("ProjectActionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RoleActionId");

                    b.HasIndex("ProjectActionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleActions");
                });

            modelBuilder.Entity("Security.DomainModel.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("isEmailActived")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Security.DomainModel.Model.ProjectAction", b =>
                {
                    b.HasOne("Security.DomainModel.Model.ProjectController", "ProjectController")
                        .WithMany("ProjectActions")
                        .HasForeignKey("ProjectControllerId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("ProjectController");
                });

            modelBuilder.Entity("Security.DomainModel.Model.ProjectController", b =>
                {
                    b.HasOne("Security.DomainModel.Model.ProjectArea", "ProjectArea")
                        .WithMany("ProjectControllers")
                        .HasForeignKey("ProjectAreaId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("ProjectArea");
                });

            modelBuilder.Entity("Security.DomainModel.Model.RoleAction", b =>
                {
                    b.HasOne("Security.DomainModel.Model.ProjectAction", "ProjectAction")
                        .WithMany("RoleActions")
                        .HasForeignKey("ProjectActionId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("Security.DomainModel.Model.Role", "Role")
                        .WithMany("RoleActions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("ProjectAction");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Security.DomainModel.Model.User", b =>
                {
                    b.HasOne("Security.DomainModel.Model.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Security.DomainModel.Model.ProjectAction", b =>
                {
                    b.Navigation("RoleActions");
                });

            modelBuilder.Entity("Security.DomainModel.Model.ProjectArea", b =>
                {
                    b.Navigation("ProjectControllers");
                });

            modelBuilder.Entity("Security.DomainModel.Model.ProjectController", b =>
                {
                    b.Navigation("ProjectActions");
                });

            modelBuilder.Entity("Security.DomainModel.Model.Role", b =>
                {
                    b.Navigation("RoleActions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
