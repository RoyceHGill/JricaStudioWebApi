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
                values: new object[] { new Guid("289f72b9-dd5e-4c62-8cc3-bd9238be78aa"), new Guid("00b4f2d5-4ca2-41ba-81f3-7e23a76f93bf"), new DateTime(2025, 1, 24, 0, 32, 44, 57, DateTimeKind.Utc).AddTicks(7645), "Jayrica", "Cunanan", "$2a$11$5jZmL66zrBNR68t3.xKZOu92/FtKL344Vkjz3vqqL877aa6Tw8qg6", "0422453888", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jricastudio@gmail.com" });

            migrationBuilder.InsertData(
                table: "BlockOutDates",
                columns: new[] { "Id", "Created", "Date", "Updated" },
                values: new object[,]
                {
                    { new Guid("ca2a1114-2061-4751-9208-3d4594b46da4"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5851), new DateOnly(2025, 1, 26), null },
                    { new Guid("df962ca5-f7ab-4944-932c-5a86a2fafabb"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5880), new DateOnly(2025, 1, 28), null },
                    { new Guid("f1594056-9203-42ad-898d-c76d41290b8c"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5890), new DateOnly(2025, 1, 30), null }
                });

            migrationBuilder.InsertData(
                table: "BusinessHours",
                columns: new[] { "Id", "AfterHoursGraceRange", "CloseTime", "Created", "Day", "IsDisabled", "LocalTimeOffset", "OpenTime", "Updated" },
                values: new object[,]
                {
                    { new Guid("344da2fc-51a7-4c90-bdd4-143a1fe73f45"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5302), 6, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("aebfb927-c479-4c33-b335-57545c2fecb9"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5292), 5, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("c7ebeb74-1847-4496-b008-bbac45f99007"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5262), 2, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("cfbca67a-55f3-4df6-8841-a6ef37de8649"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5272), 3, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("d5ef645f-6417-46d8-89d7-fcb763761e0c"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5251), 1, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("dd251297-40cb-4cdc-9adc-c061985643fa"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5213), 0, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("e3721ccd-e3cb-47c2-9c7e-8f6b18917b1f"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5281), 4, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null }
                });

            migrationBuilder.InsertData(
                table: "ImageUploads",
                columns: new[] { "Id", "ContentType", "Created", "FileName", "StoredFileName", "Updated" },
                values: new object[,]
                {
                    { new Guid("00bdf40c-870a-42a5-a3be-0208d133edca"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4383), "TestImage7", "wcf3svy4.jnn", null },
                    { new Guid("0fecd0b9-60de-408e-8ca3-cc317e0da539"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4902), "TestImage0", "jvkwqnf2.mre", null },
                    { new Guid("15303be6-ff19-444f-808f-9138f3ab7683"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4395), "TestImage8", "ynyhyfjf.yym", null },
                    { new Guid("46b83dab-354c-41f2-a3e8-87177e383bd1"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4929), "TestImage2", "oz1c3ma1.kd1", null },
                    { new Guid("569a70a7-87a7-44fe-97e8-c6f59f659c7c"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4919), "TestImage1", "ohtn2czj.s4o", null },
                    { new Guid("5911a2bb-5811-4362-90c1-abcb125c0fde"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4309), "TestImage2", "bdoiftgs.rax", null },
                    { new Guid("62ad02b9-c784-4eba-bf9c-d672a19bfb72"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4321), "TestImage3", "bqkge5do.iss", null },
                    { new Guid("6bbf7b0b-e224-4b79-888f-7543abf59410"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4350), "TestImage5", "k3u5m2si.spe", null },
                    { new Guid("a3b66ef9-0f71-4b72-9003-a109953a65a7"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4407), "TestImage9", "yuyzgysh.wjy", null },
                    { new Guid("a79f8f85-0c38-4315-8f3f-cefaee7787e8"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4939), "TestImage3", "ttt312ik.ffr", null },
                    { new Guid("cc3764eb-7199-403f-bc6e-5384cc703eed"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4291), "TestImage1", "4fchlbk2.rya", null },
                    { new Guid("f2d1e8e9-258e-4dd1-b1f2-9b4b94b655ea"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4334), "TestImage4", "e1uaxcux.m1n", null },
                    { new Guid("f537b478-4f69-4ecf-8452-08eceab8638f"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4370), "TestImage6", "tmbf3kzl.zwn", null },
                    { new Guid("fe0900ac-8d15-46ce-8891-1f1160cdc507"), "image", new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(4237), "TestImage0", "2njo3fl0.43m", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("30ad4efc-ed66-4f54-8d56-b12006b3a331"), "Lotion" },
                    { new Guid("3628ee5c-474d-43ca-b8dc-8973dfb7ecdf"), "Eye Lash Extensions" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0eea9506-3887-4b46-b6f7-dfbd463be983"), "Eye Lash Extensions" },
                    { new Guid("70da8673-bb77-4a49-80bb-d893f85ddcd3"), "Eye Brow Shaping" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "ImageUploadId", "Name", "Price", "ProductCategoryId", "Quantity", "Updated" },
                values: new object[,]
                {
                    { new Guid("021b8052-06c1-4017-b953-6525fd87f23c"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5414), "Description", new Guid("569a70a7-87a7-44fe-97e8-c6f59f659c7c"), "Aveeno Body Lotion", 10.95m, new Guid("30ad4efc-ed66-4f54-8d56-b12006b3a331"), 0, null },
                    { new Guid("13981371-e6c9-4cb3-a322-c6dbf6121261"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5588), "Description", new Guid("46b83dab-354c-41f2-a3e8-87177e383bd1"), "3D Style Eyelash Extensions", 35.60m, new Guid("3628ee5c-474d-43ca-b8dc-8973dfb7ecdf"), 1, null },
                    { new Guid("5c783771-7ad0-49f8-9c7c-bffd7575daf0"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5535), "Description", new Guid("569a70a7-87a7-44fe-97e8-c6f59f659c7c"), "Curel Body Lotion", 10.95m, new Guid("30ad4efc-ed66-4f54-8d56-b12006b3a331"), 0, null },
                    { new Guid("9c585caf-c771-4e53-bec8-b15c1825b86a"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5522), "Description", new Guid("569a70a7-87a7-44fe-97e8-c6f59f659c7c"), "Nivea Body Lotion", 10.95m, new Guid("30ad4efc-ed66-4f54-8d56-b12006b3a331"), 0, null },
                    { new Guid("a54c2de5-e609-4d9e-a0a6-b4445e70f0d0"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5574), "Description", new Guid("46b83dab-354c-41f2-a3e8-87177e383bd1"), "Wet Look Style Eyelash Extensions", 30.60m, new Guid("3628ee5c-474d-43ca-b8dc-8973dfb7ecdf"), 1, null },
                    { new Guid("d062a4d0-402e-4d32-b5cd-dbe34de701c8"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5549), "Description", new Guid("46b83dab-354c-41f2-a3e8-87177e383bd1"), "Classic Style Eyelash Extensions", 30.60m, new Guid("3628ee5c-474d-43ca-b8dc-8973dfb7ecdf"), 1, null },
                    { new Guid("fd891922-8d6a-423f-81a4-16b056c39738"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5506), "Description", new Guid("569a70a7-87a7-44fe-97e8-c6f59f659c7c"), "Vaseline Body Lotion", 10.95m, new Guid("30ad4efc-ed66-4f54-8d56-b12006b3a331"), 0, null },
                    { new Guid("fdbfe3ba-00e5-4ed6-828d-f14c63bd4564"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5561), "Description", new Guid("46b83dab-354c-41f2-a3e8-87177e383bd1"), "Volume Style Eyelash Extensions", 35.60m, new Guid("3628ee5c-474d-43ca-b8dc-8973dfb7ecdf"), 1, null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Created", "Description", "Duration", "ImageUploadId", "Name", "Price", "ServiceCategoryId", "Updated" },
                values: new object[,]
                {
                    { new Guid("00d654fa-3075-44dd-a823-8aabb415f8de"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5668), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("15303be6-ff19-444f-808f-9138f3ab7683"), "5D Lashes Infill", 120m, new Guid("0eea9506-3887-4b46-b6f7-dfbd463be983"), null },
                    { new Guid("01dde994-25f9-4a79-aa90-7fed7da10fdf"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5642), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("62ad02b9-c784-4eba-bf9c-d672a19bfb72"), "3D Lashes Infill", 120m, new Guid("0eea9506-3887-4b46-b6f7-dfbd463be983"), null },
                    { new Guid("1de24c0e-4169-430b-b34b-cb330b15cd43"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5788), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("15303be6-ff19-444f-808f-9138f3ab7683"), "Classic Eye Brow lamination", 90.00m, new Guid("70da8673-bb77-4a49-80bb-d893f85ddcd3"), null },
                    { new Guid("30bfc842-9b50-4a8e-8347-13a346c56484"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5707), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("5911a2bb-5811-4362-90c1-abcb125c0fde"), "8D Lashes Infill", 120m, new Guid("0eea9506-3887-4b46-b6f7-dfbd463be983"), null },
                    { new Guid("311f4f1f-ea70-484f-87e1-d34d832d7180"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5609), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("62ad02b9-c784-4eba-bf9c-d672a19bfb72"), "2D Lashes Infill", 120m, new Guid("0eea9506-3887-4b46-b6f7-dfbd463be983"), null },
                    { new Guid("37f4335a-56df-4bfe-b7ad-4ef3d5c7c856"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5733), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("fe0900ac-8d15-46ce-8891-1f1160cdc507"), "10D Lashes Infill", 120m, new Guid("0eea9506-3887-4b46-b6f7-dfbd463be983"), null },
                    { new Guid("45a40bf9-fbdb-455f-9ebb-97ef16342817"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5803), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("6bbf7b0b-e224-4b79-888f-7543abf59410"), "Volume Eye Brow Lamination", 90.00m, new Guid("70da8673-bb77-4a49-80bb-d893f85ddcd3"), null },
                    { new Guid("64ba7397-8448-40bd-9c88-e344ed84365b"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5745), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("62ad02b9-c784-4eba-bf9c-d672a19bfb72"), "Classic Eye Brow Trim and Shape", 90.00m, new Guid("70da8673-bb77-4a49-80bb-d893f85ddcd3"), null },
                    { new Guid("90415701-0ee3-49fa-81c3-96c96cad462f"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5695), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("00bdf40c-870a-42a5-a3be-0208d133edca"), "7D Lashes Infill", 120m, new Guid("0eea9506-3887-4b46-b6f7-dfbd463be983"), null },
                    { new Guid("920a6164-4683-4f6c-aadf-ee5b584e731a"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5682), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("f537b478-4f69-4ecf-8452-08eceab8638f"), "6D Lashes Infill", 120m, new Guid("0eea9506-3887-4b46-b6f7-dfbd463be983"), null },
                    { new Guid("93390daa-f6c8-4f77-93eb-645f00be7480"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5721), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("f2d1e8e9-258e-4dd1-b1f2-9b4b94b655ea"), "9D Lashes Infill", 120m, new Guid("0eea9506-3887-4b46-b6f7-dfbd463be983"), null },
                    { new Guid("b83a7850-71f7-41b9-a679-3b697c8f25bc"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5656), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("f537b478-4f69-4ecf-8452-08eceab8638f"), "4D Lashes Infill", 120m, new Guid("0eea9506-3887-4b46-b6f7-dfbd463be983"), null },
                    { new Guid("f7d099f9-7876-4027-a569-cd0c87240586"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5758), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("15303be6-ff19-444f-808f-9138f3ab7683"), "Volume Eye Brow Trim and Shape", 90.00m, new Guid("70da8673-bb77-4a49-80bb-d893f85ddcd3"), null }
                });

            migrationBuilder.InsertData(
                table: "ProductShowcases",
                columns: new[] { "Id", "Created", "ProductId", "Updated" },
                values: new object[] { new Guid("be4bc69f-0b8c-487b-ab9c-05c635b519d2"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5912), new Guid("d062a4d0-402e-4d32-b5cd-dbe34de701c8"), null });

            migrationBuilder.InsertData(
                table: "ServicesShowcases",
                columns: new[] { "Id", "Created", "ServiceId", "Updated" },
                values: new object[] { new Guid("80796371-d14a-4975-b347-149cae0e4c12"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5825), new Guid("311f4f1f-ea70-484f-87e1-d34d832d7180"), null });

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
