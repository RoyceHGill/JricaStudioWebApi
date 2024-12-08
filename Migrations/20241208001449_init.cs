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
                values: new object[] { new Guid("6aece502-a01d-469b-a283-059eb059df3c"), new Guid("0b0d2b05-c02d-4ec1-8f93-2efacc86efaa"), new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2655), "Jayrica", "Cunanan", "$2a$11$XCFJ1PYYjXY9BzZYLj4lsOAJ1fUxuo/GjgH.jEKvNdLqqcGyNeqKW", "0422453888", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jricastudio@gmail.com" });

            migrationBuilder.InsertData(
                table: "BlockOutDates",
                columns: new[] { "Id", "Created", "Date", "Updated" },
                values: new object[,]
                {
                    { new Guid("1eed7b69-3bea-47e4-8a8e-31f778d515b3"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(6001), new DateOnly(2024, 12, 10), null },
                    { new Guid("49247771-68e2-4ee2-9c80-04ad95852420"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(6042), new DateOnly(2024, 12, 14), null },
                    { new Guid("b6b1db24-e521-49c8-a313-ab7ceb0db2bc"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(6030), new DateOnly(2024, 12, 12), null }
                });

            migrationBuilder.InsertData(
                table: "BusinessHours",
                columns: new[] { "Id", "AfterHoursGraceRange", "CloseTime", "Created", "Day", "IsDisabled", "LocalTimeOffset", "OpenTime", "Updated" },
                values: new object[,]
                {
                    { new Guid("265fddf8-dfd1-48fc-aa0f-5cc191a6b13e"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5205), 0, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("32fcaf6f-5ab8-4cd7-91b3-09e6afda9d63"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5330), 5, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("7f8fc455-833c-45ab-9b73-0ecfc17eb67c"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5341), 6, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("964840b1-10de-48f5-a494-2a4e745ce998"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5302), 3, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("9e17ea5e-9f4f-4703-854b-9063dfac9f5f"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5314), 4, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("bb7aef54-e7e1-43dd-9a24-85fea17787db"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5290), 2, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("dcaae268-9fd6-428a-b71d-a12ea25487e8"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5277), 1, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null }
                });

            migrationBuilder.InsertData(
                table: "ImageUploads",
                columns: new[] { "Id", "ContentType", "Created", "FileName", "StoredFileName", "Updated" },
                values: new object[,]
                {
                    { new Guid("02a74cda-a35b-4a28-af43-ec1d9b97192a"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2108), "TestImage5", "ngsqjaxp.n4e", null },
                    { new Guid("09d951a7-dea5-4d6d-bf53-2ca8348590db"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2070), "TestImage2", "cxoakqsc.3bi", null },
                    { new Guid("1caa188e-295f-48d5-ad0a-4208a7be281b"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2631), "TestImage3", "mdzy12e5.uml", null },
                    { new Guid("1e317c07-f726-47a5-bb79-2cd887a06399"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2118), "TestImage6", "s2yyclvc.hig", null },
                    { new Guid("2bd5bc8f-94af-4a78-aab6-7d739aa15a20"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2009), "TestImage0", "3hclps3p.a1h", null },
                    { new Guid("3b4b0b8a-7107-4351-91cc-8db22cb531ae"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2596), "TestImage0", "4nuwndu0.buf", null },
                    { new Guid("7220a159-861b-46c7-bc3f-3dfe66d0ebdd"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2641), "TestImage4", "rru2y10u.2at", null },
                    { new Guid("8499a75d-ba93-487c-a3d7-3ed41ccc0602"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2611), "TestImage1", "c0bwlcik.ssu", null },
                    { new Guid("8e33d993-e2b1-4dce-8f06-e22e43a58d3d"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2083), "TestImage3", "dt02ly20.dnp", null },
                    { new Guid("a15adcc7-4339-4463-b587-8481238f98d4"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2059), "TestImage1", "cp3kaueq.n5c", null },
                    { new Guid("a3facd2e-3868-4ac7-b312-66429c6ee456"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2095), "TestImage4", "iqwsymby.kfi", null },
                    { new Guid("a9819b44-12dd-4ca2-bd0f-6ae45c91d7ca"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2622), "TestImage2", "kiy5oofa.lka", null },
                    { new Guid("b552dd17-095f-4ed6-b453-2262f0786cc1"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2140), "TestImage8", "yxrfdhmb.zpb", null },
                    { new Guid("c0acfc6a-3c0e-46eb-bf4b-5300e532e9a2"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2129), "TestImage7", "sae4fqsn.w4s", null },
                    { new Guid("d280e2f5-4ecc-4ab9-9406-fbf87faba588"), "image", new DateTime(2024, 12, 8, 0, 14, 49, 242, DateTimeKind.Utc).AddTicks(2156), "TestImage9", "zl3oilrm.f5n", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("87ffd916-9ba0-418e-9a10-0e61954d133c"), "Eye Lash Extensions" },
                    { new Guid("99330a1f-b086-4b7e-a217-7e3d0079c088"), "Lotion" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e29b9009-6e2a-4159-aa40-8c90968431ca"), "Eye Brow Shaping" },
                    { new Guid("ff1788c9-a3a0-4c67-9c75-86cc4c1c58c2"), "Eye Lash Extensions" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "ImageUploadId", "Name", "Price", "ProductCategoryId", "Quantity", "Updated" },
                values: new object[,]
                {
                    { new Guid("4ffa6b89-e1c6-4f2b-af68-3c34b7e600d6"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5708), "Description", new Guid("8499a75d-ba93-487c-a3d7-3ed41ccc0602"), "Wet Look Style Eyelash Extensions", 30.60m, new Guid("87ffd916-9ba0-418e-9a10-0e61954d133c"), 1, null },
                    { new Guid("60a7ca92-6d78-48ed-beac-0350d44aa555"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5513), "Description", new Guid("a9819b44-12dd-4ca2-bd0f-6ae45c91d7ca"), "Aveeno Body Lotion", 10.95m, new Guid("99330a1f-b086-4b7e-a217-7e3d0079c088"), 0, null },
                    { new Guid("76680d9f-8b31-4304-941e-33e59616d4e1"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5591), "Description", new Guid("1caa188e-295f-48d5-ad0a-4208a7be281b"), "Vaseline Body Lotion", 10.95m, new Guid("99330a1f-b086-4b7e-a217-7e3d0079c088"), 0, null },
                    { new Guid("7e9ec2bb-a7a5-4a8a-8e38-ad87827200ec"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5681), "Description", new Guid("3b4b0b8a-7107-4351-91cc-8db22cb531ae"), "Volume Style Eyelash Extensions", 35.60m, new Guid("87ffd916-9ba0-418e-9a10-0e61954d133c"), 1, null },
                    { new Guid("8e891258-7896-43e3-9df8-c89472baa728"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5728), "Description", new Guid("8499a75d-ba93-487c-a3d7-3ed41ccc0602"), "3D Style Eyelash Extensions", 35.60m, new Guid("87ffd916-9ba0-418e-9a10-0e61954d133c"), 1, null },
                    { new Guid("9e437704-c642-49fe-b2ec-2e6d42b1f439"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5658), "Description", new Guid("3b4b0b8a-7107-4351-91cc-8db22cb531ae"), "Classic Style Eyelash Extensions", 30.60m, new Guid("87ffd916-9ba0-418e-9a10-0e61954d133c"), 1, null },
                    { new Guid("bb99454a-c5a3-4fe5-81e2-18843a66444e"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5613), "Description", new Guid("3b4b0b8a-7107-4351-91cc-8db22cb531ae"), "Nivea Body Lotion", 10.95m, new Guid("99330a1f-b086-4b7e-a217-7e3d0079c088"), 0, null },
                    { new Guid("ef3c2a25-7c82-4901-b97d-ec936e844429"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5637), "Description", new Guid("8499a75d-ba93-487c-a3d7-3ed41ccc0602"), "Curel Body Lotion", 10.95m, new Guid("99330a1f-b086-4b7e-a217-7e3d0079c088"), 0, null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Created", "Description", "Duration", "ImageUploadId", "Name", "Price", "ServiceCategoryId", "Updated" },
                values: new object[,]
                {
                    { new Guid("19f71d23-f4a8-443e-8809-2a6662a26f31"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5892), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("a15adcc7-4339-4463-b587-8481238f98d4"), "9D Lashes Infill", 120m, new Guid("ff1788c9-a3a0-4c67-9c75-86cc4c1c58c2"), null },
                    { new Guid("262a7d9d-6055-4d3d-b137-3d20e70bcddc"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5847), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("b552dd17-095f-4ed6-b453-2262f0786cc1"), "7D Lashes Infill", 120m, new Guid("ff1788c9-a3a0-4c67-9c75-86cc4c1c58c2"), null },
                    { new Guid("36879fa4-fd5c-4fba-91ff-80b160fff825"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5904), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("b552dd17-095f-4ed6-b453-2262f0786cc1"), "10D Lashes Infill", 120m, new Guid("ff1788c9-a3a0-4c67-9c75-86cc4c1c58c2"), null },
                    { new Guid("5254e7cd-f1d2-4d9a-a819-100ead2e674f"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5809), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("c0acfc6a-3c0e-46eb-bf4b-5300e532e9a2"), "4D Lashes Infill", 120m, new Guid("ff1788c9-a3a0-4c67-9c75-86cc4c1c58c2"), null },
                    { new Guid("76d4b7d0-b8d6-4db0-b13e-82771aac1b55"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5821), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("8e33d993-e2b1-4dce-8f06-e22e43a58d3d"), "5D Lashes Infill", 120m, new Guid("ff1788c9-a3a0-4c67-9c75-86cc4c1c58c2"), null },
                    { new Guid("7a19c482-273c-4654-80df-f57bcdcdfe27"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5942), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("a15adcc7-4339-4463-b587-8481238f98d4"), "Classic Eye Brow lamination", 90.00m, new Guid("e29b9009-6e2a-4159-aa40-8c90968431ca"), null },
                    { new Guid("83ee7bff-d173-42f0-ab3a-148fbee446cc"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5754), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("09d951a7-dea5-4d6d-bf53-2ca8348590db"), "2D Lashes Infill", 120m, new Guid("ff1788c9-a3a0-4c67-9c75-86cc4c1c58c2"), null },
                    { new Guid("a00d2578-a77b-4386-83a2-ae5de48b7e7f"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5795), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("02a74cda-a35b-4a28-af43-ec1d9b97192a"), "3D Lashes Infill", 120m, new Guid("ff1788c9-a3a0-4c67-9c75-86cc4c1c58c2"), null },
                    { new Guid("a3b692b1-e83a-409a-a176-2d09bdb856e8"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5918), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("c0acfc6a-3c0e-46eb-bf4b-5300e532e9a2"), "Classic Eye Brow Trim and Shape", 90.00m, new Guid("e29b9009-6e2a-4159-aa40-8c90968431ca"), null },
                    { new Guid("a7530d63-cbb4-4440-98f7-4a0dbc6261a1"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5956), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("a3facd2e-3868-4ac7-b312-66429c6ee456"), "Volume Eye Brow Lamination", 90.00m, new Guid("e29b9009-6e2a-4159-aa40-8c90968431ca"), null },
                    { new Guid("db091346-f628-4010-a0e4-17a55dafe23e"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5930), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("c0acfc6a-3c0e-46eb-bf4b-5300e532e9a2"), "Volume Eye Brow Trim and Shape", 90.00m, new Guid("e29b9009-6e2a-4159-aa40-8c90968431ca"), null },
                    { new Guid("f3f48de7-ccbf-413a-8e38-7a4b0b780914"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5859), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("8e33d993-e2b1-4dce-8f06-e22e43a58d3d"), "8D Lashes Infill", 120m, new Guid("ff1788c9-a3a0-4c67-9c75-86cc4c1c58c2"), null },
                    { new Guid("ffad169e-0e51-4d8c-a8e7-314e6172780a"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5834), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("a15adcc7-4339-4463-b587-8481238f98d4"), "6D Lashes Infill", 120m, new Guid("ff1788c9-a3a0-4c67-9c75-86cc4c1c58c2"), null }
                });

            migrationBuilder.InsertData(
                table: "ProductShowcases",
                columns: new[] { "Id", "Created", "ProductId", "Updated" },
                values: new object[] { new Guid("68cc7699-c1fb-4556-918d-111a9cbd5979"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(6060), new Guid("9e437704-c642-49fe-b2ec-2e6d42b1f439"), null });

            migrationBuilder.InsertData(
                table: "ServicesShowcases",
                columns: new[] { "Id", "Created", "ServiceId", "Updated" },
                values: new object[] { new Guid("3e4bb6d8-1b3c-4aa1-a980-0374229fc68e"), new DateTime(2024, 12, 8, 0, 14, 49, 332, DateTimeKind.Utc).AddTicks(5976), new Guid("83ee7bff-d173-42f0-ab3a-148fbee446cc"), null });

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
