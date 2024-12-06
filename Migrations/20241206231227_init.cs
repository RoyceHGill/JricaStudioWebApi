using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JricaStudioWebApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    AdminKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    ResetKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    ResetKeySent = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlockOutDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockOutDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessHours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Day = table.Column<int>(type: "INTEGER", nullable: false),
                    OpenTime = table.Column<TimeOnly>(type: "TEXT", nullable: true),
                    CloseTime = table.Column<TimeOnly>(type: "TEXT", nullable: true),
                    LocalTimeOffset = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IsDisabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AfterHoursGraceRange = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageUploads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    StoredFileName = table.Column<string>(type: "TEXT", nullable: false),
                    ContentType = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUploads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PolicyTitle = table.Column<string>(type: "TEXT", nullable: false),
                    PolicyArticle = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    DOB = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    WearsContanctLenses = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasHadEyeProblems4Weeks = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasAllergies = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasSensitiveSkin = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsWaiverAcknowledged = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ServiceCategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ImageUploadId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ImageUploads_ImageUploadId",
                        column: x => x.ImageUploadId,
                        principalTable: "ImageUploads",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ImageUploadId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ImageUploads_ImageUploadId",
                        column: x => x.ImageUploadId,
                        principalTable: "ImageUploads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    HasHadEyelashExtentions = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSampleSetComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDepositPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    SampleSetCompleted = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ServicesShowcases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesShowcases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesShowcases_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductShowcases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShowcases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductShowcases_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentProducts_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentServices_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AdminKey", "Created", "FirstName", "LastName", "Password", "Phone", "ResetKey", "ResetKeySent", "Updated", "Username" },
                values: new object[] { new Guid("e215b7ec-cbdd-4def-b725-923f9b9039d6"), new Guid("38c84c24-053c-4048-9b9b-0d8de1c3dedd"), new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(8185), "Jayrica", "Cunanan", "$2a$11$NaqiA/4EAJS1LAYYtomE7ua5Tca/LzgEdNWkf4mhvSO96WkaXhqKi", "0422453888", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jricastudio@gmail.com" });

            migrationBuilder.InsertData(
                table: "BlockOutDates",
                columns: new[] { "Id", "Created", "Date", "Updated" },
                values: new object[,]
                {
                    { new Guid("2c2cae69-b661-4791-a0a5-4b718fe9aecf"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2942), new DateOnly(2024, 12, 10), null },
                    { new Guid("8a837d76-9c2a-4ef4-aeae-f11900222002"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2912), new DateOnly(2024, 12, 8), null },
                    { new Guid("db0f1aed-40b4-4088-a38c-c7a029954d89"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2953), new DateOnly(2024, 12, 12), null }
                });

            migrationBuilder.InsertData(
                table: "BusinessHours",
                columns: new[] { "Id", "AfterHoursGraceRange", "CloseTime", "Created", "Day", "IsDisabled", "LocalTimeOffset", "OpenTime", "Updated" },
                values: new object[,]
                {
                    { new Guid("32879885-13c8-4b57-8a32-3b2f5772a3e8"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2334), 3, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("3f35f6d0-38b6-4caf-a4bd-91326a5bbf48"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2372), 6, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("724a9dca-5ebd-475e-844c-ea2e05348393"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2268), 2, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("753665a4-5632-46f3-a1db-d317ed9d54c6"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2250), 1, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("9581bbe2-a03b-4106-8ded-ce109fd06f9a"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2172), 0, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("a1faae47-2df9-4691-80e5-5890e3491661"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2360), 5, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("f829f97f-e42f-42fb-bf21-680d16c956b0"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2346), 4, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null }
                });

            migrationBuilder.InsertData(
                table: "ImageUploads",
                columns: new[] { "Id", "ContentType", "Created", "FileName", "StoredFileName", "Updated" },
                values: new object[,]
                {
                    { new Guid("0a19d267-8ca2-4acc-ba4f-364fe7e08d7b"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(8160), "TestImage3", "yc50xtod.5qs", null },
                    { new Guid("1517f614-a450-4512-b8f5-d4ea04e12694"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(8113), "TestImage2", "r4ewrbw4.dsb", null },
                    { new Guid("19f0ec31-cb78-4ba6-8879-4db92ff6a371"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(7504), "TestImage8", "slblntjp.01y", null },
                    { new Guid("1a81c961-5317-412c-b8f1-56a7bc03389e"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(7409), "TestImage3", "5grsbly1.vvs", null },
                    { new Guid("23af1909-3f86-4552-9ef0-621040ff871d"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(7344), "TestImage0", "02lelb20.kxu", null },
                    { new Guid("39641fdb-4b32-414d-9dc5-1d0fb0cd9e96"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(7518), "TestImage9", "vhqpmyj4.d3y", null },
                    { new Guid("98a0171e-1371-47de-988b-1dc003f42af5"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(7422), "TestImage4", "dlgyvmbi.gcs", null },
                    { new Guid("a1f6884b-df7a-44e0-90a1-9b53e118286e"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(7397), "TestImage2", "4yyj3byq.m42", null },
                    { new Guid("a91610de-8235-438b-a2d7-9b98525208b6"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(8082), "TestImage0", "bfbh030y.uon", null },
                    { new Guid("d7ec3b7c-0a6b-4575-b593-8b2cf46b77d4"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(8103), "TestImage1", "pl4hh1jm.ngy", null },
                    { new Guid("dbe2cf7d-e5a6-417f-84f7-ac52b1a7e1f2"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(7478), "TestImage6", "oca4ntjt.ttx", null },
                    { new Guid("e1757882-fdaa-417b-911b-28c36be5fea0"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(7491), "TestImage7", "qvxqk2ty.x1t", null },
                    { new Guid("e25d1754-1c0c-4a44-854e-6ad4ba5d54ef"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(8171), "TestImage4", "z02np4ox.2jp", null },
                    { new Guid("ed8ed240-de82-4de1-8402-8f395e9809ca"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(7385), "TestImage1", "1wfiyggv.ogz", null },
                    { new Guid("fad508da-35c7-4add-8a8c-8f4546c69234"), "image", new DateTime(2024, 12, 6, 23, 12, 26, 925, DateTimeKind.Utc).AddTicks(7434), "TestImage5", "mo3lni30.ymi", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("30c2731a-10a6-4f85-8eed-514cd13caea0"), "Eye Lash Extensions" },
                    { new Guid("5775e093-6fee-433a-925e-41ad0dcbdd1f"), "Lotion" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("33df749d-a17f-4d04-a9c7-3c5fd2ba1a0f"), "Eye Brow Shaping" },
                    { new Guid("a0004cb7-bea4-464e-bb33-85837416123e"), "Eye Lash Extensions" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "ImageUploadId", "Name", "Price", "ProductCategoryId", "Quantity", "Updated" },
                values: new object[,]
                {
                    { new Guid("016a974e-4509-48ce-8783-4eb0ae615056"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2624), "Description", new Guid("a91610de-8235-438b-a2d7-9b98525208b6"), "Wet Look Style Eyelash Extensions", 30.60m, new Guid("30c2731a-10a6-4f85-8eed-514cd13caea0"), 1, null },
                    { new Guid("0d1d6d5c-ebdb-4388-acf1-6c92788c59ff"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2636), "Description", new Guid("0a19d267-8ca2-4acc-ba4f-364fe7e08d7b"), "3D Style Eyelash Extensions", 35.60m, new Guid("30c2731a-10a6-4f85-8eed-514cd13caea0"), 1, null },
                    { new Guid("204f0be3-9327-4392-adf3-db324efbc3a1"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2585), "Description", new Guid("1517f614-a450-4512-b8f5-d4ea04e12694"), "Curel Body Lotion", 10.95m, new Guid("5775e093-6fee-433a-925e-41ad0dcbdd1f"), 0, null },
                    { new Guid("77dd84da-66a6-49ff-b557-43a962e54779"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2570), "Description", new Guid("1517f614-a450-4512-b8f5-d4ea04e12694"), "Nivea Body Lotion", 10.95m, new Guid("5775e093-6fee-433a-925e-41ad0dcbdd1f"), 0, null },
                    { new Guid("ac747f6a-032e-49be-9465-77af5ace3950"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2556), "Description", new Guid("1517f614-a450-4512-b8f5-d4ea04e12694"), "Vaseline Body Lotion", 10.95m, new Guid("5775e093-6fee-433a-925e-41ad0dcbdd1f"), 0, null },
                    { new Guid("b7b00ac4-383a-4231-914d-f4a97458f617"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2495), "Description", new Guid("a91610de-8235-438b-a2d7-9b98525208b6"), "Aveeno Body Lotion", 10.95m, new Guid("5775e093-6fee-433a-925e-41ad0dcbdd1f"), 0, null },
                    { new Guid("d1596535-dd8f-40c8-b645-3e1583c37a14"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2611), "Description", new Guid("a91610de-8235-438b-a2d7-9b98525208b6"), "Volume Style Eyelash Extensions", 35.60m, new Guid("30c2731a-10a6-4f85-8eed-514cd13caea0"), 1, null },
                    { new Guid("dd4cefd0-7dfd-43ae-8c09-69b0296eb951"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2598), "Description", new Guid("1517f614-a450-4512-b8f5-d4ea04e12694"), "Classic Style Eyelash Extensions", 30.60m, new Guid("30c2731a-10a6-4f85-8eed-514cd13caea0"), 1, null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Created", "Description", "Duration", "ImageUploadId", "Name", "Price", "ServiceCategoryId", "Updated" },
                values: new object[,]
                {
                    { new Guid("00286ba5-8cf4-4b90-b151-b3590f945e06"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2742), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("fad508da-35c7-4add-8a8c-8f4546c69234"), "5D Lashes Infill", 120m, new Guid("a0004cb7-bea4-464e-bb33-85837416123e"), null },
                    { new Guid("29d10e4f-6e9d-44b6-8e41-4d90215e4a4e"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2665), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("23af1909-3f86-4552-9ef0-621040ff871d"), "2D Lashes Infill", 120m, new Guid("a0004cb7-bea4-464e-bb33-85837416123e"), null },
                    { new Guid("2f363256-6afa-4f45-a430-58885aa5e643"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2783), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("dbe2cf7d-e5a6-417f-84f7-ac52b1a7e1f2"), "8D Lashes Infill", 120m, new Guid("a0004cb7-bea4-464e-bb33-85837416123e"), null },
                    { new Guid("38726940-f647-434a-9b74-5757364b9d4c"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2796), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("e1757882-fdaa-417b-911b-28c36be5fea0"), "9D Lashes Infill", 120m, new Guid("a0004cb7-bea4-464e-bb33-85837416123e"), null },
                    { new Guid("3ef68f0b-1971-4c70-bdca-42d5e14a5e23"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2828), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("dbe2cf7d-e5a6-417f-84f7-ac52b1a7e1f2"), "Classic Eye Brow Trim and Shape", 90.00m, new Guid("33df749d-a17f-4d04-a9c7-3c5fd2ba1a0f"), null },
                    { new Guid("443619e7-5178-43c3-9928-5829f05d35df"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2840), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("dbe2cf7d-e5a6-417f-84f7-ac52b1a7e1f2"), "Volume Eye Brow Trim and Shape", 90.00m, new Guid("33df749d-a17f-4d04-a9c7-3c5fd2ba1a0f"), null },
                    { new Guid("4542cbfd-cd65-4f32-92f1-63d0b7d913a7"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2698), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("1a81c961-5317-412c-b8f1-56a7bc03389e"), "3D Lashes Infill", 120m, new Guid("a0004cb7-bea4-464e-bb33-85837416123e"), null },
                    { new Guid("5248b3ac-a295-4dd4-917b-48755bd1bcd0"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2756), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("ed8ed240-de82-4de1-8402-8f395e9809ca"), "6D Lashes Infill", 120m, new Guid("a0004cb7-bea4-464e-bb33-85837416123e"), null },
                    { new Guid("7c6aba58-4d3a-44c2-9990-ffaa893c6a37"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2810), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("98a0171e-1371-47de-988b-1dc003f42af5"), "10D Lashes Infill", 120m, new Guid("a0004cb7-bea4-464e-bb33-85837416123e"), null },
                    { new Guid("a831753b-0cea-4438-82fe-af11c14fb1e1"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2711), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("a1f6884b-df7a-44e0-90a1-9b53e118286e"), "4D Lashes Infill", 120m, new Guid("a0004cb7-bea4-464e-bb33-85837416123e"), null },
                    { new Guid("d71bc441-8f44-48c4-a65f-2525a29903c9"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2769), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("a1f6884b-df7a-44e0-90a1-9b53e118286e"), "7D Lashes Infill", 120m, new Guid("a0004cb7-bea4-464e-bb33-85837416123e"), null },
                    { new Guid("e0bc64d0-c2dd-4c8d-b886-6f137cb733ef"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2867), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("a1f6884b-df7a-44e0-90a1-9b53e118286e"), "Volume Eye Brow Lamination", 90.00m, new Guid("33df749d-a17f-4d04-a9c7-3c5fd2ba1a0f"), null },
                    { new Guid("e2c27213-eb48-446c-9495-ae11b82942b7"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2852), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("ed8ed240-de82-4de1-8402-8f395e9809ca"), "Classic Eye Brow lamination", 90.00m, new Guid("33df749d-a17f-4d04-a9c7-3c5fd2ba1a0f"), null }
                });

            migrationBuilder.InsertData(
                table: "ProductShowcases",
                columns: new[] { "Id", "Created", "ProductId", "Updated" },
                values: new object[] { new Guid("f2f1c228-d700-47c7-98b5-ddefded757bd"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2977), new Guid("dd4cefd0-7dfd-43ae-8c09-69b0296eb951"), null });

            migrationBuilder.InsertData(
                table: "ServicesShowcases",
                columns: new[] { "Id", "Created", "ServiceId", "Updated" },
                values: new object[] { new Guid("4632d588-8f46-48aa-83ee-aba776fa19b0"), new DateTime(2024, 12, 6, 23, 12, 27, 15, DateTimeKind.Utc).AddTicks(2888), new Guid("29d10e4f-6e9d-44b6-8e41-4d90215e4a4e"), null });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentProducts_AppointmentId",
                table: "AppointmentProducts",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentProducts_ProductId",
                table: "AppointmentProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentServices_AppointmentId",
                table: "AppointmentServices",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentServices_ServiceId",
                table: "AppointmentServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageUploadId",
                table: "Products",
                column: "ImageUploadId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShowcases_ProductId",
                table: "ProductShowcases",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageUploadId",
                table: "Services",
                column: "ImageUploadId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesShowcases_ServiceId",
                table: "ServicesShowcases",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AppointmentProducts");

            migrationBuilder.DropTable(
                name: "AppointmentServices");

            migrationBuilder.DropTable(
                name: "BlockOutDates");

            migrationBuilder.DropTable(
                name: "BusinessHours");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "ProductShowcases");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "ServicesShowcases");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ImageUploads");
        }
    }
}
