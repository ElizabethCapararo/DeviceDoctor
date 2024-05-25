﻿// <auto-generated />
using System;
using DeviceDoctorTerminalSystem.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeviceDoctorTerminalSystem.Migrations
{
    [DbContext(typeof(DocDbContext))]
    partial class DocDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DeviceDoctorTerminalSystem.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DeviceDoctorTerminalSystem.Models.Repair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssueDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Updates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("DeviceDoctorTerminalSystem.Models.Repair", b =>
                {
                    b.HasOne("DeviceDoctorTerminalSystem.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("DeviceDoctorTerminalSystem.Models.Device", "Device", b1 =>
                        {
                            b1.Property<Guid>("RepairId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Condition")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Manufacturer")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Model")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SerialNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RepairId");

                            b1.ToTable("Repairs");

                            b1.WithOwner()
                                .HasForeignKey("RepairId");
                        });

                    b.Navigation("Customer");

                    b.Navigation("Device")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
