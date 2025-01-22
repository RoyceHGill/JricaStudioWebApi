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
                values: new object[] { new Guid("f75c8dc8-2b85-4308-8145-ef69485c6399"), new Guid("505d1f96-cb45-44ba-95a1-d4566e78337e"), new DateTime(2025, 1, 22, 7, 8, 46, 645, DateTimeKind.Utc).AddTicks(6629), "Jayrica", "Cunanan", "$2a$11$okWy7urSc7G66WFf5p454OcjVcpErRSL6M86ytRRiV3vpAX/3tEX2", "0422453888", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jricastudio@gmail.com" });

            migrationBuilder.InsertData(
                table: "BlockOutDates",
                columns: new[] { "Id", "Created", "Date", "Updated" },
                values: new object[,]
                {
                    { new Guid("0434f408-0782-45c2-82e9-741e2df3c33d"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5419), new DateOnly(2025, 1, 24), null },
                    { new Guid("21c2d868-3bbe-487d-bacf-12dfe5311410"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5457), new DateOnly(2025, 1, 28), null },
                    { new Guid("51223b65-79a6-47f8-839a-3ebba3bdf464"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5446), new DateOnly(2025, 1, 26), null }
                });

            migrationBuilder.InsertData(
                table: "BusinessHours",
                columns: new[] { "Id", "AfterHoursGraceRange", "CloseTime", "Created", "Day", "IsDisabled", "LocalTimeOffset", "OpenTime", "Updated" },
                values: new object[,]
                {
                    { new Guid("2779aa5e-6940-4c73-a9ce-5e16fd8e965f"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4904), 3, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("29e76d9a-1232-4845-852e-0e0d3aaa1c9e"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4882), 1, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("6c92a834-502e-4452-8548-8dbd40e6c7e8"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4894), 2, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("98136c2a-de09-42a2-8c02-120da7c04575"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4927), 5, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("a734c6cf-ed13-4a4b-9e5a-c93579106899"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4816), 0, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("ac242e66-9158-4d47-96be-55bc91c8747e"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4915), 4, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("e3de7592-dc63-466b-896a-d3afd054ca6d"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4937), 6, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null }
                });

            migrationBuilder.InsertData(
                table: "ImageUploads",
                columns: new[] { "Id", "ContentType", "Created", "FileName", "StoredFileName", "Updated" },
                values: new object[,]
                {
                    { new Guid("00520433-1dc8-44f8-8002-6c827ae54b77"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(3960), "TestImage5", "iboasfkp.w3b", null },
                    { new Guid("14a64a27-f659-42d1-b82e-2140080bf1a5"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4488), "TestImage3", "t1uxyuv1.rct", null },
                    { new Guid("20434728-e9d4-47d4-88bb-711e6b0753db"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4477), "TestImage2", "ml2hrcfr.fff", null },
                    { new Guid("22ac4d89-e1d0-487a-90dc-e5932d8f1d3e"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(3985), "TestImage7", "kxrby3er.clx", null },
                    { new Guid("43e3ebf5-84a8-4fed-a90e-f78b45d4b2eb"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4465), "TestImage1", "4j0qknjz.roc", null },
                    { new Guid("45a97314-3065-4306-bdaa-7f0cec91c9f8"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4448), "TestImage0", "1ljopecf.nq4", null },
                    { new Guid("5ccfc659-4212-47d7-9bd5-ccd5c51be600"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4038), "TestImage9", "uu15yrqp.mb1", null },
                    { new Guid("708b7255-d034-4143-8186-b8f19f8b1e65"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(3914), "TestImage2", "5viixxdx.za1", null },
                    { new Guid("8e754df1-53ba-4727-b857-bfd2ec1cf55c"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(4025), "TestImage8", "s4qx54cs.1ds", null },
                    { new Guid("9360a3b1-9f00-464e-b43f-ce90ef761ab8"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(3946), "TestImage4", "cabzutlu.2ql", null },
                    { new Guid("a6ef7706-75f5-485b-a0f9-3c074f8e0648"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(3925), "TestImage3", "5viliiwb.s44", null },
                    { new Guid("be012cd3-27f8-4e5b-83fd-2298b6ec94de"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(3972), "TestImage6", "ipdcda1n.dee", null },
                    { new Guid("c0e3d5ef-306f-424b-9cfb-69aec1979e44"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(3859), "TestImage0", "2hhbpn5f.0l4", null },
                    { new Guid("c0fcc37b-832b-4634-9ae4-25576649a35f"), "image", new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(3903), "TestImage1", "4ecfsmzj.5vq", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1aa9bb0b-da81-45e8-9a69-9d6960f4ac4a"), "Eye Lash Extensions" },
                    { new Guid("412855ec-df76-4203-aa1f-48a4f05d3d7b"), "Lotion" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9073c793-c0d4-4e99-a6c5-1919c3ce36f1"), "Eye Lash Extensions" },
                    { new Guid("df4c4988-9a1d-43ab-ba39-2d88ec923733"), "Eye Brow Shaping" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "ImageUploadId", "Name", "Price", "ProductCategoryId", "Quantity", "Updated" },
                values: new object[,]
                {
                    { new Guid("0e2f34f9-21b1-4f98-a533-78f4c0ff887e"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5031), "Description", new Guid("20434728-e9d4-47d4-88bb-711e6b0753db"), "Aveeno Body Lotion", 10.95m, new Guid("412855ec-df76-4203-aa1f-48a4f05d3d7b"), 0, null },
                    { new Guid("4ae83ebe-8b03-4864-8ed7-3883c6058dcf"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5135), "Description", new Guid("43e3ebf5-84a8-4fed-a90e-f78b45d4b2eb"), "Volume Style Eyelash Extensions", 35.60m, new Guid("1aa9bb0b-da81-45e8-9a69-9d6960f4ac4a"), 1, null },
                    { new Guid("542c4c9e-e467-4991-b987-ba3cc7dd544a"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5160), "Description", new Guid("20434728-e9d4-47d4-88bb-711e6b0753db"), "3D Style Eyelash Extensions", 35.60m, new Guid("1aa9bb0b-da81-45e8-9a69-9d6960f4ac4a"), 1, null },
                    { new Guid("572eb17f-7fbe-431d-a8bc-5ddda4d1e44c"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5124), "Description", new Guid("20434728-e9d4-47d4-88bb-711e6b0753db"), "Classic Style Eyelash Extensions", 30.60m, new Guid("1aa9bb0b-da81-45e8-9a69-9d6960f4ac4a"), 1, null },
                    { new Guid("5f9cbe78-d359-415f-b51d-597782e02135"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5112), "Description", new Guid("45a97314-3065-4306-bdaa-7f0cec91c9f8"), "Curel Body Lotion", 10.95m, new Guid("412855ec-df76-4203-aa1f-48a4f05d3d7b"), 0, null },
                    { new Guid("8813dc88-67ad-489f-9921-41061cefd261"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5099), "Description", new Guid("45a97314-3065-4306-bdaa-7f0cec91c9f8"), "Nivea Body Lotion", 10.95m, new Guid("412855ec-df76-4203-aa1f-48a4f05d3d7b"), 0, null },
                    { new Guid("bc0e2c58-4b4c-46cb-9553-1ad82788a93c"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5148), "Description", new Guid("45a97314-3065-4306-bdaa-7f0cec91c9f8"), "Wet Look Style Eyelash Extensions", 30.60m, new Guid("1aa9bb0b-da81-45e8-9a69-9d6960f4ac4a"), 1, null },
                    { new Guid("deaacc53-9223-47eb-a0bd-c8296ea2fde8"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5086), "Description", new Guid("45a97314-3065-4306-bdaa-7f0cec91c9f8"), "Vaseline Body Lotion", 10.95m, new Guid("412855ec-df76-4203-aa1f-48a4f05d3d7b"), 0, null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Created", "Description", "Duration", "ImageUploadId", "Name", "Price", "ServiceCategoryId", "Updated" },
                values: new object[,]
                {
                    { new Guid("03552cb9-89ef-42f4-9c5d-88b5eaffe5c4"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5309), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("c0e3d5ef-306f-424b-9cfb-69aec1979e44"), "8D Lashes Infill", 120m, new Guid("9073c793-c0d4-4e99-a6c5-1919c3ce36f1"), null },
                    { new Guid("3501ec61-3b7a-4906-a1f0-39c850789907"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5181), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("be012cd3-27f8-4e5b-83fd-2298b6ec94de"), "2D Lashes Infill", 120m, new Guid("9073c793-c0d4-4e99-a6c5-1919c3ce36f1"), null },
                    { new Guid("3612ff06-05ce-4567-afe9-ed5433a5cc1b"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5282), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("9360a3b1-9f00-464e-b43f-ce90ef761ab8"), "6D Lashes Infill", 120m, new Guid("9073c793-c0d4-4e99-a6c5-1919c3ce36f1"), null },
                    { new Guid("4cc13340-1b96-4836-97de-c3f348b58690"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5357), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("a6ef7706-75f5-485b-a0f9-3c074f8e0648"), "Volume Eye Brow Trim and Shape", 90.00m, new Guid("df4c4988-9a1d-43ab-ba39-2d88ec923733"), null },
                    { new Guid("6768752b-2eb1-4af5-a073-52821709af90"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5297), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("be012cd3-27f8-4e5b-83fd-2298b6ec94de"), "7D Lashes Infill", 120m, new Guid("9073c793-c0d4-4e99-a6c5-1919c3ce36f1"), null },
                    { new Guid("7a1e0aa5-cead-4a8e-8caa-84509ad2b2be"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5321), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("be012cd3-27f8-4e5b-83fd-2298b6ec94de"), "9D Lashes Infill", 120m, new Guid("9073c793-c0d4-4e99-a6c5-1919c3ce36f1"), null },
                    { new Guid("89495072-9779-46a0-8521-b2c358caf421"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5211), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("00520433-1dc8-44f8-8002-6c827ae54b77"), "3D Lashes Infill", 120m, new Guid("9073c793-c0d4-4e99-a6c5-1919c3ce36f1"), null },
                    { new Guid("caaf9a94-2726-4c75-ad5e-5f0d2903f56e"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5268), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("8e754df1-53ba-4727-b857-bfd2ec1cf55c"), "5D Lashes Infill", 120m, new Guid("9073c793-c0d4-4e99-a6c5-1919c3ce36f1"), null },
                    { new Guid("ce974964-57d9-4b5e-bfce-c8a0d06e5af9"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5369), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("00520433-1dc8-44f8-8002-6c827ae54b77"), "Classic Eye Brow lamination", 90.00m, new Guid("df4c4988-9a1d-43ab-ba39-2d88ec923733"), null },
                    { new Guid("db8c5d10-c4f8-47ea-adee-2ed497d4df46"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5252), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("708b7255-d034-4143-8186-b8f19f8b1e65"), "4D Lashes Infill", 120m, new Guid("9073c793-c0d4-4e99-a6c5-1919c3ce36f1"), null },
                    { new Guid("e2ed61c3-2088-4e2f-8dce-65115660a1af"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5333), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("9360a3b1-9f00-464e-b43f-ce90ef761ab8"), "10D Lashes Infill", 120m, new Guid("9073c793-c0d4-4e99-a6c5-1919c3ce36f1"), null },
                    { new Guid("ec61bcb4-2e9d-47d5-9fd7-db68726dc31a"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5346), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("9360a3b1-9f00-464e-b43f-ce90ef761ab8"), "Classic Eye Brow Trim and Shape", 90.00m, new Guid("df4c4988-9a1d-43ab-ba39-2d88ec923733"), null },
                    { new Guid("f2506bb0-7cfe-4a69-9979-2b2917b2d591"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5382), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("708b7255-d034-4143-8186-b8f19f8b1e65"), "Volume Eye Brow Lamination", 90.00m, new Guid("df4c4988-9a1d-43ab-ba39-2d88ec923733"), null }
                });

            migrationBuilder.InsertData(
                table: "ProductShowcases",
                columns: new[] { "Id", "Created", "ProductId", "Updated" },
                values: new object[] { new Guid("e6da40bf-c60b-422a-b54c-0118b1023a1a"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5473), new Guid("572eb17f-7fbe-431d-a8bc-5ddda4d1e44c"), null });

            migrationBuilder.InsertData(
                table: "ServicesShowcases",
                columns: new[] { "Id", "Created", "ServiceId", "Updated" },
                values: new object[] { new Guid("4352713d-5679-4ebc-9a0c-66a52fce8ce0"), new DateTime(2025, 1, 22, 7, 8, 46, 735, DateTimeKind.Utc).AddTicks(5401), new Guid("3501ec61-3b7a-4906-a1f0-39c850789907"), null });

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
