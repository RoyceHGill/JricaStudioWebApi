﻿// <auto-generated />
using System;
using JricaStudioWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JricaStudioWebApi.Migrations
{
    [DbContext(typeof(JaysLashesDbContext))]
    partial class JaysLashesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("JricaStudioWebApi.Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AdminKey")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResetKey")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ResetKeySent")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6dec7b6f-a681-473a-b7ed-d5c21eea2295"),
                            AdminKey = new Guid("b147adde-d04b-49d6-9098-198058f3c1ce"),
                            Created = new DateTime(2024, 12, 6, 21, 49, 7, 946, DateTimeKind.Utc).AddTicks(7814),
                            FirstName = "Jayrica",
                            LastName = "Cunanan",
                            Password = "$2a$11$agCkxS16HN/a7mYaTzw9U.Avqkt8FfRMftnTQAM5IB.1FnpF/Bpxu",
                            Phone = "0422453888",
                            ResetKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            ResetKeySent = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "jricastudio@gmail.com"
                        });
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasHadEyelashExtentions")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDepositPaid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSampleSetComplete")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("SampleSetCompleted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.AppointmentProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ProductId");

                    b.ToTable("AppointmentProducts");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.AppointmentService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("AppointmentServices");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.BlockOutDate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BlockOutDates");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.BusinessHours", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AfterHoursGraceRange")
                        .HasColumnType("INTEGER");

                    b.Property<TimeOnly?>("CloseTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Day")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("LocalTimeOffset")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly?>("OpenTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BusinessHours");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.ImageUpload", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StoredFileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ImageUploads");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.Policy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("PolicyArticle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PolicyTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ImageUploadId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductCategoryId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ImageUploadId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.ProductShowcase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductShowcases");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ImageUploadId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ServiceCategoryId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ImageUploadId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.ServiceCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServiceCategories");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.ServiceShowCase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServicesShowcases");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasAllergies")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasHadEyeProblems4Weeks")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasSensitiveSkin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWaiverAcknowledged")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<bool>("WearsContanctLenses")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.Appointment", b =>
                {
                    b.HasOne("JricaStudioWebApi.Entities.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.AppointmentProduct", b =>
                {
                    b.HasOne("JricaStudioWebApi.Entities.Appointment", "Appointment")
                        .WithMany("AppointmentProducts")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JricaStudioWebApi.Entities.Product", "Product")
                        .WithMany("AppointmentProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.AppointmentService", b =>
                {
                    b.HasOne("JricaStudioWebApi.Entities.Appointment", "Appointment")
                        .WithMany("AppointmentServices")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JricaStudioWebApi.Entities.Service", "Service")
                        .WithMany("AppointmentServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.Product", b =>
                {
                    b.HasOne("JricaStudioWebApi.Entities.ImageUpload", "ImageUpload")
                        .WithMany("Products")
                        .HasForeignKey("ImageUploadId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JricaStudioWebApi.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ImageUpload");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.ProductShowcase", b =>
                {
                    b.HasOne("JricaStudioWebApi.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.Service", b =>
                {
                    b.HasOne("JricaStudioWebApi.Entities.ImageUpload", "ImageUpload")
                        .WithMany("Services")
                        .HasForeignKey("ImageUploadId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ImageUpload");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.ServiceShowCase", b =>
                {
                    b.HasOne("JricaStudioWebApi.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.Appointment", b =>
                {
                    b.Navigation("AppointmentProducts");

                    b.Navigation("AppointmentServices");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.ImageUpload", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.Product", b =>
                {
                    b.Navigation("AppointmentProducts");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.Service", b =>
                {
                    b.Navigation("AppointmentServices");
                });

            modelBuilder.Entity("JricaStudioWebApi.Entities.User", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
