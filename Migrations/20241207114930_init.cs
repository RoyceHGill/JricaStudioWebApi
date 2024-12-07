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
                values: new object[] { new Guid("cdac5f7e-19b3-48ef-9030-343dbd505a71"), new Guid("c3735184-fec7-4da8-bbc9-beed86f418a8"), new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5784), "Jayrica", "Cunanan", "$2a$11$qD.0XYzEinIt1ZM296b5JOWiBlcVT5FQqsCUAyo1wswsucBmtBz8q", "0422453888", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jricastudio@gmail.com" });

            migrationBuilder.InsertData(
                table: "BlockOutDates",
                columns: new[] { "Id", "Created", "Date", "Updated" },
                values: new object[,]
                {
                    { new Guid("2ec6d4de-0523-4114-a290-7103f9e53a7e"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9478), new DateOnly(2024, 12, 13), null },
                    { new Guid("36b55092-4978-494f-85df-15827b1a08ff"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9412), new DateOnly(2024, 12, 9), null },
                    { new Guid("b73847dd-eef3-4791-8b98-2f389e0e5adf"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9439), new DateOnly(2024, 12, 11), null }
                });

            migrationBuilder.InsertData(
                table: "BusinessHours",
                columns: new[] { "Id", "AfterHoursGraceRange", "CloseTime", "Created", "Day", "IsDisabled", "LocalTimeOffset", "OpenTime", "Updated" },
                values: new object[,]
                {
                    { new Guid("0e75538b-41b5-41b6-a618-013aa4784e2b"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(8832), 6, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("1c547614-c584-442f-87fa-8416329cd965"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(8776), 2, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("2dc4bdd2-2cca-446f-81b8-9f984855ef37"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(8700), 0, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("497b53de-21c3-4906-a523-136d93222341"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(8796), 3, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("653a1de4-c74d-40b6-a831-0b219c4fc936"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(8821), 5, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("8fe10108-2b23-40e4-9cea-0486d9a458c3"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(8762), 1, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("e91abe51-a8ed-49d8-853b-e2879ad0033a"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(8807), 4, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null }
                });

            migrationBuilder.InsertData(
                table: "ImageUploads",
                columns: new[] { "Id", "ContentType", "Created", "FileName", "StoredFileName", "Updated" },
                values: new object[,]
                {
                    { new Guid("019b9ba0-22da-4492-b92b-3d9618c8656c"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5761), "TestImage4", "xxob4cje.kui", null },
                    { new Guid("182e064b-b108-4bfa-88d7-e1d7fd2f6b72"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5230), "TestImage7", "rnguv4sj.yq1", null },
                    { new Guid("2553145e-4214-4b9c-bd0a-6bcdf1320a9a"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5243), "TestImage8", "x01stjie.g42", null },
                    { new Guid("2c3183b0-e882-43c2-b716-6071f001978a"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5684), "TestImage0", "i4cksssk.ch2", null },
                    { new Guid("2eb9373b-2333-46af-8f1c-ed8795ed4e59"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5722), "TestImage2", "ksbexjv0.h5g", null },
                    { new Guid("3ab6c196-4041-4433-9abb-d1208e89ee4f"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5742), "TestImage3", "xalczynf.rkv", null },
                    { new Guid("4f4decdb-3cd4-4f55-9852-bd063ce53220"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5172), "TestImage2", "jqwex1ch.5fv", null },
                    { new Guid("6a4d1239-f8ea-4941-901a-48c3ed10e08d"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5701), "TestImage1", "icbjzpkg.vdq", null },
                    { new Guid("898e4ad1-d9f9-42ca-a5bf-3a5984ddeaae"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5208), "TestImage5", "mthjb4ul.hqn", null },
                    { new Guid("964f2080-01fd-48c2-afea-0755bba97315"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5095), "TestImage0", "2aubqrya.se1", null },
                    { new Guid("9e50c32a-b21b-47ca-b144-7bbc0ee53042"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5159), "TestImage1", "fhu1f0as.q1j", null },
                    { new Guid("9e769b48-9ee2-490e-965d-1b6b67f52212"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5182), "TestImage3", "kddfooda.qlo", null },
                    { new Guid("a4bfef7d-b929-4fc1-94a9-2428709bfa91"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5197), "TestImage4", "mow5g222.zwf", null },
                    { new Guid("b402b14c-fbde-4e25-80ed-a4a4278ad4f7"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5257), "TestImage9", "zzppfrlm.wcj", null },
                    { new Guid("ec55ab81-5191-4793-bbae-1206ab0c5662"), "image", new DateTime(2024, 12, 7, 11, 49, 30, 472, DateTimeKind.Utc).AddTicks(5219), "TestImage6", "qr4gtj1t.s2g", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ec71ac05-34cb-432d-ac54-6434761d46b0"), "Eye Lash Extensions" },
                    { new Guid("fad60c8d-a87a-43d0-b089-b7764ee0ad57"), "Lotion" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9948eb81-d3db-412e-aaa3-f2b7746f26ab"), "Eye Brow Shaping" },
                    { new Guid("aa986f20-34de-46ac-83c6-954b49c5c89a"), "Eye Lash Extensions" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "ImageUploadId", "Name", "Price", "ProductCategoryId", "Quantity", "Updated" },
                values: new object[,]
                {
                    { new Guid("6083a12e-3470-4839-9730-e41ba5f6dd27"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9016), "Description", new Guid("3ab6c196-4041-4433-9abb-d1208e89ee4f"), "Nivea Body Lotion", 10.95m, new Guid("fad60c8d-a87a-43d0-b089-b7764ee0ad57"), 0, null },
                    { new Guid("63f10458-5b42-483e-ac54-9da88dfd7cd3"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9044), "Description", new Guid("3ab6c196-4041-4433-9abb-d1208e89ee4f"), "Classic Style Eyelash Extensions", 30.60m, new Guid("ec71ac05-34cb-432d-ac54-6434761d46b0"), 1, null },
                    { new Guid("81a03b73-1a26-4a64-8555-e18dcfe9b29e"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9029), "Description", new Guid("6a4d1239-f8ea-4941-901a-48c3ed10e08d"), "Curel Body Lotion", 10.95m, new Guid("fad60c8d-a87a-43d0-b089-b7764ee0ad57"), 0, null },
                    { new Guid("87aef8f4-4109-41a0-94ae-12ff6bf2cc2f"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(8937), "Description", new Guid("6a4d1239-f8ea-4941-901a-48c3ed10e08d"), "Aveeno Body Lotion", 10.95m, new Guid("fad60c8d-a87a-43d0-b089-b7764ee0ad57"), 0, null },
                    { new Guid("acb768cc-4c79-4fa2-b8a5-8929fc6af994"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(8998), "Description", new Guid("3ab6c196-4041-4433-9abb-d1208e89ee4f"), "Vaseline Body Lotion", 10.95m, new Guid("fad60c8d-a87a-43d0-b089-b7764ee0ad57"), 0, null },
                    { new Guid("b8fefedb-9050-4061-8350-377626f306ea"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9151), "Description", new Guid("3ab6c196-4041-4433-9abb-d1208e89ee4f"), "Wet Look Style Eyelash Extensions", 30.60m, new Guid("ec71ac05-34cb-432d-ac54-6434761d46b0"), 1, null },
                    { new Guid("bd8d7915-626e-4d93-b0cd-dea47c2175ae"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9167), "Description", new Guid("3ab6c196-4041-4433-9abb-d1208e89ee4f"), "3D Style Eyelash Extensions", 35.60m, new Guid("ec71ac05-34cb-432d-ac54-6434761d46b0"), 1, null },
                    { new Guid("c31d27a4-44a0-47f6-b5ac-d9a6a2b091d7"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9058), "Description", new Guid("2c3183b0-e882-43c2-b716-6071f001978a"), "Volume Style Eyelash Extensions", 35.60m, new Guid("ec71ac05-34cb-432d-ac54-6434761d46b0"), 1, null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Created", "Description", "Duration", "ImageUploadId", "Name", "Price", "ServiceCategoryId", "Updated" },
                values: new object[,]
                {
                    { new Guid("4f963a67-b404-4183-9ccc-4b1102b7ed5c"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9369), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("9e769b48-9ee2-490e-965d-1b6b67f52212"), "Volume Eye Brow Lamination", 90.00m, new Guid("9948eb81-d3db-412e-aaa3-f2b7746f26ab"), null },
                    { new Guid("6c794798-bef7-4cd0-8a44-5f49b0663f19"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9245), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("898e4ad1-d9f9-42ca-a5bf-3a5984ddeaae"), "4D Lashes Infill", 120m, new Guid("aa986f20-34de-46ac-83c6-954b49c5c89a"), null },
                    { new Guid("6ff29863-df1c-4348-afdf-b98ebd0d47df"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9357), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("ec55ab81-5191-4793-bbae-1206ab0c5662"), "Classic Eye Brow lamination", 90.00m, new Guid("9948eb81-d3db-412e-aaa3-f2b7746f26ab"), null },
                    { new Guid("767ea8b9-7eea-4fe6-b18e-dae5d4e0074d"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9334), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("9e769b48-9ee2-490e-965d-1b6b67f52212"), "Classic Eye Brow Trim and Shape", 90.00m, new Guid("9948eb81-d3db-412e-aaa3-f2b7746f26ab"), null },
                    { new Guid("7e07b8f5-519b-4300-a17b-2773c5573d42"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9190), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("2553145e-4214-4b9c-bd0a-6bcdf1320a9a"), "2D Lashes Infill", 120m, new Guid("aa986f20-34de-46ac-83c6-954b49c5c89a"), null },
                    { new Guid("817c4f9f-1cf3-45b0-9431-9dad0733f065"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9308), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("964f2080-01fd-48c2-afea-0755bba97315"), "9D Lashes Infill", 120m, new Guid("aa986f20-34de-46ac-83c6-954b49c5c89a"), null },
                    { new Guid("89dd9336-143f-408e-99c5-734108fd8281"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9268), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("a4bfef7d-b929-4fc1-94a9-2428709bfa91"), "6D Lashes Infill", 120m, new Guid("aa986f20-34de-46ac-83c6-954b49c5c89a"), null },
                    { new Guid("9e51fdf3-d934-4899-a21c-64ec9b117982"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9321), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("898e4ad1-d9f9-42ca-a5bf-3a5984ddeaae"), "10D Lashes Infill", 120m, new Guid("aa986f20-34de-46ac-83c6-954b49c5c89a"), null },
                    { new Guid("a2262847-46cb-40c4-a4c4-c57dd0a5189f"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9346), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("2553145e-4214-4b9c-bd0a-6bcdf1320a9a"), "Volume Eye Brow Trim and Shape", 90.00m, new Guid("9948eb81-d3db-412e-aaa3-f2b7746f26ab"), null },
                    { new Guid("a78f462a-3b5a-4ccd-a52d-dbe4cf0ed428"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9283), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("964f2080-01fd-48c2-afea-0755bba97315"), "7D Lashes Infill", 120m, new Guid("aa986f20-34de-46ac-83c6-954b49c5c89a"), null },
                    { new Guid("c51e52fe-f4f2-448c-9b69-0f791251970a"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9231), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("a4bfef7d-b929-4fc1-94a9-2428709bfa91"), "3D Lashes Infill", 120m, new Guid("aa986f20-34de-46ac-83c6-954b49c5c89a"), null },
                    { new Guid("e770d9e9-3469-4c77-99d5-18395f4f000b"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9257), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("4f4decdb-3cd4-4f55-9852-bd063ce53220"), "5D Lashes Infill", 120m, new Guid("aa986f20-34de-46ac-83c6-954b49c5c89a"), null },
                    { new Guid("f02fcbe7-d485-4993-8dae-d2f0e770d074"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9296), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("9e50c32a-b21b-47ca-b144-7bbc0ee53042"), "8D Lashes Infill", 120m, new Guid("aa986f20-34de-46ac-83c6-954b49c5c89a"), null }
                });

            migrationBuilder.InsertData(
                table: "ProductShowcases",
                columns: new[] { "Id", "Created", "ProductId", "Updated" },
                values: new object[] { new Guid("971f918a-9b89-4bb5-9df8-44f543e9120e"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9496), new Guid("63f10458-5b42-483e-ac54-9da88dfd7cd3"), null });

            migrationBuilder.InsertData(
                table: "ServicesShowcases",
                columns: new[] { "Id", "Created", "ServiceId", "Updated" },
                values: new object[] { new Guid("b7aea277-5e6d-4b2b-ba91-484208adbedd"), new DateTime(2024, 12, 7, 11, 49, 30, 561, DateTimeKind.Utc).AddTicks(9388), new Guid("7e07b8f5-519b-4300-a17b-2773c5573d42"), null });

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
