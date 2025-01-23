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
                values: new object[] { new Guid("b77164bf-38b8-4cf7-8e98-8943be598580"), new Guid("c57a1b7b-0ce2-4766-ae35-76aeffa26be1"), new DateTime(2025, 1, 23, 22, 15, 28, 962, DateTimeKind.Utc).AddTicks(3887), "Jayrica", "Cunanan", "$2a$11$WEyR1m4QJt3VQbH.qsFiRuea2WUSvbEBxzYxFQqvtYEcUjfIXXf6e", "0422453888", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jricastudio@gmail.com" });

            migrationBuilder.InsertData(
                table: "BlockOutDates",
                columns: new[] { "Id", "Created", "Date", "Updated" },
                values: new object[,]
                {
                    { new Guid("2e75a992-a1e9-4798-b064-b927a2bdb1c0"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(6094), new DateOnly(2025, 1, 29), null },
                    { new Guid("3c5bb93b-41ad-4c90-bb59-2ae7e6529a52"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(6036), new DateOnly(2025, 1, 25), null },
                    { new Guid("f03d26d0-4133-4004-a273-506eb359c27c"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(6073), new DateOnly(2025, 1, 27), null }
                });

            migrationBuilder.InsertData(
                table: "BusinessHours",
                columns: new[] { "Id", "AfterHoursGraceRange", "CloseTime", "Created", "Day", "IsDisabled", "LocalTimeOffset", "OpenTime", "Updated" },
                values: new object[,]
                {
                    { new Guid("21077f72-8d77-4654-98f1-193c6fde7856"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(4911), 1, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("66d18fd1-7e3c-4029-b55d-109ac673ec5b"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(4980), 4, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("695a7a87-35c0-4283-b638-ee5937fcbe94"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(4867), 0, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("6e0a2f5a-ed6c-417b-a347-3a298556f239"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5002), 5, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("a1e64355-989f-4dd8-b0f8-616e3469f9e6"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(4961), 3, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("ada29e9f-20ad-4830-ae77-f68802a82cbc"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5022), 6, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("c07fd9bb-2ebd-44f0-9121-b1bff078988c"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(4933), 2, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null }
                });

            migrationBuilder.InsertData(
                table: "ImageUploads",
                columns: new[] { "Id", "ContentType", "Created", "FileName", "StoredFileName", "Updated" },
                values: new object[,]
                {
                    { new Guid("08627b7f-f69c-4bde-972a-1aa8102bc0f8"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(3403), "TestImage7", "qa4ae2om.qht", null },
                    { new Guid("1a104eca-dbdc-441f-a395-e1d6d5676b25"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(3491), "TestImage9", "uwz52kvb.eo2", null },
                    { new Guid("41f8e9c7-8ae0-4d7a-a353-bb9fd9ceb507"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(4457), "TestImage1", "c1nnahll.5rg", null },
                    { new Guid("8bbec06a-0250-42ad-938e-b8d5e5cc656b"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(3114), "TestImage0", "1zragvms.d3b", null },
                    { new Guid("94cb958a-5db4-4762-a18b-bb8964b59f8d"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(3315), "TestImage4", "kkhhxftr.hsy", null },
                    { new Guid("9c030d35-4847-484a-bfad-c9bf462f1e8d"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(4424), "TestImage0", "3dakx1an.31p", null },
                    { new Guid("aa38370d-0382-4986-bb28-82e6765a818e"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(3279), "TestImage3", "k4x3wa3i.uec", null },
                    { new Guid("b647d925-e806-4700-b138-04537ff07b20"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(4495), "TestImage3", "ygztqh4e.knb", null },
                    { new Guid("be48c1bc-0f08-4dca-8669-8cee8751d2a2"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(3193), "TestImage1", "3usgxy1b.zz1", null },
                    { new Guid("cc63ccce-70b1-4e66-93f7-53d4ae1cb7c6"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(3359), "TestImage6", "ppfmlzmz.y4j", null },
                    { new Guid("dac0316d-6467-4f4b-a506-b781130c3d84"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(4477), "TestImage2", "oyoirmri.whq", null },
                    { new Guid("e3f3b967-4510-4b1d-92f4-545443e5067b"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(3340), "TestImage5", "oosgacmu.sfp", null },
                    { new Guid("e5bd97b7-c695-442c-8210-7974e24ee33e"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(3425), "TestImage8", "sh2ec3rm.54o", null },
                    { new Guid("f97aa9fc-8038-4586-b3e2-26b9d973a550"), "image", new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(3227), "TestImage2", "cwecbf2i.dnp", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4a10fb95-d74b-401e-9eff-d0e1066ea505"), "Lotion" },
                    { new Guid("c353ba75-d7a8-4198-8643-ed79980709b0"), "Eye Lash Extensions" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2604b918-bdcb-4b5a-b601-d8a61c50d45b"), "Eye Brow Shaping" },
                    { new Guid("76a202b4-7831-4a77-8e44-e324c623cbeb"), "Eye Lash Extensions" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "ImageUploadId", "Name", "Price", "ProductCategoryId", "Quantity", "Updated" },
                values: new object[,]
                {
                    { new Guid("3fb0e248-3163-44c3-8238-3aa0156067fb"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5507), "Description", new Guid("9c030d35-4847-484a-bfad-c9bf462f1e8d"), "Classic Style Eyelash Extensions", 30.60m, new Guid("c353ba75-d7a8-4198-8643-ed79980709b0"), 1, null },
                    { new Guid("425a29c8-1498-4d7e-bfe1-eb61940d2df2"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5535), "Description", new Guid("41f8e9c7-8ae0-4d7a-a353-bb9fd9ceb507"), "Volume Style Eyelash Extensions", 35.60m, new Guid("c353ba75-d7a8-4198-8643-ed79980709b0"), 1, null },
                    { new Guid("48d14ad8-fb69-401d-89a5-d09a952a3f7a"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5319), "Description", new Guid("9c030d35-4847-484a-bfad-c9bf462f1e8d"), "Curel Body Lotion", 10.95m, new Guid("4a10fb95-d74b-401e-9eff-d0e1066ea505"), 0, null },
                    { new Guid("81f8916e-65fe-444d-b85e-60137b366212"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5583), "Description", new Guid("dac0316d-6467-4f4b-a506-b781130c3d84"), "3D Style Eyelash Extensions", 35.60m, new Guid("c353ba75-d7a8-4198-8643-ed79980709b0"), 1, null },
                    { new Guid("9d66c1e4-4373-4436-903b-dcae704b92b5"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5198), "Description", new Guid("9c030d35-4847-484a-bfad-c9bf462f1e8d"), "Aveeno Body Lotion", 10.95m, new Guid("4a10fb95-d74b-401e-9eff-d0e1066ea505"), 0, null },
                    { new Guid("d60a2846-e96d-4e9c-8e3d-7f7e371bd662"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5558), "Description", new Guid("9c030d35-4847-484a-bfad-c9bf462f1e8d"), "Wet Look Style Eyelash Extensions", 30.60m, new Guid("c353ba75-d7a8-4198-8643-ed79980709b0"), 1, null },
                    { new Guid("dbc49b58-c766-42a6-b36b-55c685e5c2cd"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5271), "Description", new Guid("dac0316d-6467-4f4b-a506-b781130c3d84"), "Vaseline Body Lotion", 10.95m, new Guid("4a10fb95-d74b-401e-9eff-d0e1066ea505"), 0, null },
                    { new Guid("ff54ad1a-bc22-4275-b857-4f46ef71bb92"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5296), "Description", new Guid("41f8e9c7-8ae0-4d7a-a353-bb9fd9ceb507"), "Nivea Body Lotion", 10.95m, new Guid("4a10fb95-d74b-401e-9eff-d0e1066ea505"), 0, null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Created", "Description", "Duration", "ImageUploadId", "Name", "Price", "ServiceCategoryId", "Updated" },
                values: new object[,]
                {
                    { new Guid("002756b5-3a03-43ac-8f09-10a51b5f1da1"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5809), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("8bbec06a-0250-42ad-938e-b8d5e5cc656b"), "9D Lashes Infill", 120m, new Guid("76a202b4-7831-4a77-8e44-e324c623cbeb"), null },
                    { new Guid("046f3a6f-02f7-494e-bb6b-e209b9564d0a"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5925), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("be48c1bc-0f08-4dca-8669-8cee8751d2a2"), "Volume Eye Brow Trim and Shape", 90.00m, new Guid("2604b918-bdcb-4b5a-b601-d8a61c50d45b"), null },
                    { new Guid("09ccd803-065a-47f8-bbbf-605c7af76179"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5969), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("08627b7f-f69c-4bde-972a-1aa8102bc0f8"), "Volume Eye Brow Lamination", 90.00m, new Guid("2604b918-bdcb-4b5a-b601-d8a61c50d45b"), null },
                    { new Guid("20dbe763-5ecc-48c3-903d-ffb466289cb6"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5864), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("08627b7f-f69c-4bde-972a-1aa8102bc0f8"), "10D Lashes Infill", 120m, new Guid("76a202b4-7831-4a77-8e44-e324c623cbeb"), null },
                    { new Guid("356527b3-47f6-4707-b969-4266c5c24b56"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5686), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("cc63ccce-70b1-4e66-93f7-53d4ae1cb7c6"), "4D Lashes Infill", 120m, new Guid("76a202b4-7831-4a77-8e44-e324c623cbeb"), null },
                    { new Guid("6e0d1271-bea1-406b-a9e5-1b376ccfd5f6"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5901), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("e5bd97b7-c695-442c-8210-7974e24ee33e"), "Classic Eye Brow Trim and Shape", 90.00m, new Guid("2604b918-bdcb-4b5a-b601-d8a61c50d45b"), null },
                    { new Guid("b4bd4ba5-610e-49e8-af9b-da4c35dd84a8"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5621), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("e3f3b967-4510-4b1d-92f4-545443e5067b"), "2D Lashes Infill", 120m, new Guid("76a202b4-7831-4a77-8e44-e324c623cbeb"), null },
                    { new Guid("be554741-3224-4501-9db8-263d19382cb8"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5660), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("aa38370d-0382-4986-bb28-82e6765a818e"), "3D Lashes Infill", 120m, new Guid("76a202b4-7831-4a77-8e44-e324c623cbeb"), null },
                    { new Guid("c5016612-bf23-4767-8755-f696fc977f4e"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5947), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("e3f3b967-4510-4b1d-92f4-545443e5067b"), "Classic Eye Brow lamination", 90.00m, new Guid("2604b918-bdcb-4b5a-b601-d8a61c50d45b"), null },
                    { new Guid("c96a5f38-6be8-4131-a921-2d15b26977bf"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5738), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("e5bd97b7-c695-442c-8210-7974e24ee33e"), "6D Lashes Infill", 120m, new Guid("76a202b4-7831-4a77-8e44-e324c623cbeb"), null },
                    { new Guid("d3963e92-33d7-48d5-a75d-50ceb51aac0d"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5763), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("e3f3b967-4510-4b1d-92f4-545443e5067b"), "7D Lashes Infill", 120m, new Guid("76a202b4-7831-4a77-8e44-e324c623cbeb"), null },
                    { new Guid("e12f153b-ba51-4a86-82dd-3928ae94cf5e"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5713), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("aa38370d-0382-4986-bb28-82e6765a818e"), "5D Lashes Infill", 120m, new Guid("76a202b4-7831-4a77-8e44-e324c623cbeb"), null },
                    { new Guid("ed58add0-5f9d-4a04-9cc3-d239eb4e0e09"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(5786), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("e3f3b967-4510-4b1d-92f4-545443e5067b"), "8D Lashes Infill", 120m, new Guid("76a202b4-7831-4a77-8e44-e324c623cbeb"), null }
                });

            migrationBuilder.InsertData(
                table: "ProductShowcases",
                columns: new[] { "Id", "Created", "ProductId", "Updated" },
                values: new object[] { new Guid("3f92ce62-77ed-42dd-8a3a-77993b9c54da"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(6127), new Guid("3fb0e248-3163-44c3-8238-3aa0156067fb"), null });

            migrationBuilder.InsertData(
                table: "ServicesShowcases",
                columns: new[] { "Id", "Created", "ServiceId", "Updated" },
                values: new object[] { new Guid("f5ab07ab-f1a6-4680-a7d3-631f35ec87d2"), new DateTime(2025, 1, 23, 22, 15, 29, 90, DateTimeKind.Utc).AddTicks(6002), new Guid("b4bd4ba5-610e-49e8-af9b-da4c35dd84a8"), null });

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
