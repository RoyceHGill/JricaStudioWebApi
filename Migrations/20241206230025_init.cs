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
                values: new object[] { new Guid("9e0fb1f1-0a06-4e53-82ba-145e237358da"), new Guid("3406dc36-e888-4d89-9ce0-5540633f64c8"), new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8918), "Jayrica", "Cunanan", "$2a$11$MQNFw0GnW1QPsOVHLxQPjukU77yqRAp.cAFQ7z2.LPDAvdswvRdyi", "0422453888", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jricastudio@gmail.com" });

            migrationBuilder.InsertData(
                table: "BlockOutDates",
                columns: new[] { "Id", "Created", "Date", "Updated" },
                values: new object[,]
                {
                    { new Guid("47396174-21e8-4175-9eb2-f36e0f948fb3"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9493), new DateOnly(2024, 12, 12), null },
                    { new Guid("a2213a69-37c6-41e7-8b84-5491c23c47f5"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9438), new DateOnly(2024, 12, 8), null },
                    { new Guid("aaa1d54c-25ff-4bfb-8ed3-ff76172ea3a5"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9464), new DateOnly(2024, 12, 10), null }
                });

            migrationBuilder.InsertData(
                table: "BusinessHours",
                columns: new[] { "Id", "AfterHoursGraceRange", "CloseTime", "Created", "Day", "IsDisabled", "LocalTimeOffset", "OpenTime", "Updated" },
                values: new object[,]
                {
                    { new Guid("12ed3d64-594f-490a-a85f-add548bcb371"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(8828), 2, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("196e21ee-e456-4dd3-b416-fc8a20cf27e8"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(8724), 0, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("1dfa0064-f3a1-4dcc-ab15-c3019bb03694"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(8840), 3, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("1fb86cc3-52a1-495d-aab0-cecc1f1ea388"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(8851), 4, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("28cc5c14-5371-49cc-b325-e51f5f5963ff"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(8875), 6, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("76a4d3fc-2b68-45f6-993d-ea4013088910"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(8865), 5, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
                    { new Guid("8162bff2-49fa-4b9c-98b2-8153d6735542"), 2, new TimeOnly(7, 0, 0), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(8815), 1, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null }
                });

            migrationBuilder.InsertData(
                table: "ImageUploads",
                columns: new[] { "Id", "ContentType", "Created", "FileName", "StoredFileName", "Updated" },
                values: new object[,]
                {
                    { new Guid("041c6602-1a32-4c84-a057-b96db3cfdaf8"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8869), "TestImage1", "axlbdjel.hyc", null },
                    { new Guid("08671e08-861a-4a26-8d71-c2e6036ca4d5"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8374), "TestImage5", "tcpkt35n.gr2", null },
                    { new Guid("0872f471-2e73-4c4f-b305-88550d37aaf2"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8893), "TestImage3", "ncn0uwbu.bom", null },
                    { new Guid("0a917f53-d153-40d9-8516-0db0db0f1780"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8904), "TestImage4", "xzu2yu4v.njt", null },
                    { new Guid("26c03dbf-9ced-4236-b7e1-6829c9239130"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8324), "TestImage1", "1r4zqyu0.gi4", null },
                    { new Guid("39b06fa9-7431-4ed2-9645-a1cf1b4bc45b"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8347), "TestImage3", "gaxx0wp3.shv", null },
                    { new Guid("713a415c-40ab-486f-ba8f-808333538a6f"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8855), "TestImage0", "0vqtv5tb.w0h", null },
                    { new Guid("86690a51-247a-4621-b1db-abc6423ca4c1"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8358), "TestImage4", "kmg5yef0.sur", null },
                    { new Guid("8d6386ac-2456-46fb-97fc-481ad7affee3"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8397), "TestImage7", "uwvxthvt.goa", null },
                    { new Guid("8f29696f-bd0f-43d4-908b-0d138329c0c9"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8427), "TestImage9", "zunfse5i.1zu", null },
                    { new Guid("a17297b8-2320-4790-a89d-f7c9a954b691"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8881), "TestImage2", "lrc1hkcq.ljd", null },
                    { new Guid("aa0d082d-8233-4ae6-b5b1-593c0261b96b"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8386), "TestImage6", "tzfm3wxw.gs0", null },
                    { new Guid("b579f16b-9481-40ae-aca0-1a85f77e792e"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8409), "TestImage8", "zocriik1.vc2", null },
                    { new Guid("c7d67191-5ff4-42e2-8caf-6dae0d33a0f8"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8336), "TestImage2", "3eq2p4lu.qa4", null },
                    { new Guid("d476c346-d3f1-4294-96c2-5daadb45504e"), "image", new DateTime(2024, 12, 6, 23, 0, 24, 729, DateTimeKind.Utc).AddTicks(8282), "TestImage0", "1nfgmnyz.bl2", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ac0e012a-ad7f-4e8e-bbad-ff3e8ffbb53f"), "Lotion" },
                    { new Guid("e419294e-2d16-46de-9d37-f71bbac55ca7"), "Eye Lash Extensions" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2f86ab85-ed62-4db9-a3ad-6b4760440ed8"), "Eye Brow Shaping" },
                    { new Guid("cb94f68a-e464-4c21-bb67-4101b2991a30"), "Eye Lash Extensions" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "ImageUploadId", "Name", "Price", "ProductCategoryId", "Quantity", "Updated" },
                values: new object[,]
                {
                    { new Guid("18cbb031-74cc-4b49-8a4c-a5b4dda30170"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9149), "Description", new Guid("041c6602-1a32-4c84-a057-b96db3cfdaf8"), "3D Style Eyelash Extensions", 35.60m, new Guid("e419294e-2d16-46de-9d37-f71bbac55ca7"), 1, null },
                    { new Guid("3b44b5f9-1dea-4499-833c-73235775977e"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9053), "Description", new Guid("041c6602-1a32-4c84-a057-b96db3cfdaf8"), "Curel Body Lotion", 10.95m, new Guid("ac0e012a-ad7f-4e8e-bbad-ff3e8ffbb53f"), 0, null },
                    { new Guid("7250a8aa-7514-4516-bb32-547295b72ac4"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(8972), "Description", new Guid("a17297b8-2320-4790-a89d-f7c9a954b691"), "Aveeno Body Lotion", 10.95m, new Guid("ac0e012a-ad7f-4e8e-bbad-ff3e8ffbb53f"), 0, null },
                    { new Guid("85558091-6d75-4405-9ee5-7ef30c6687ba"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9135), "Description", new Guid("0872f471-2e73-4c4f-b305-88550d37aaf2"), "Wet Look Style Eyelash Extensions", 30.60m, new Guid("e419294e-2d16-46de-9d37-f71bbac55ca7"), 1, null },
                    { new Guid("8f50546a-06ca-4cec-bba0-c401efc6597e"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9078), "Description", new Guid("a17297b8-2320-4790-a89d-f7c9a954b691"), "Volume Style Eyelash Extensions", 35.60m, new Guid("e419294e-2d16-46de-9d37-f71bbac55ca7"), 1, null },
                    { new Guid("cb808d2c-a43f-4271-a199-ae420c2afbff"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9066), "Description", new Guid("713a415c-40ab-486f-ba8f-808333538a6f"), "Classic Style Eyelash Extensions", 30.60m, new Guid("e419294e-2d16-46de-9d37-f71bbac55ca7"), 1, null },
                    { new Guid("f7f19deb-2203-4c53-8337-0fc2f84fa46c"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9027), "Description", new Guid("0872f471-2e73-4c4f-b305-88550d37aaf2"), "Vaseline Body Lotion", 10.95m, new Guid("ac0e012a-ad7f-4e8e-bbad-ff3e8ffbb53f"), 0, null },
                    { new Guid("ff9253ad-ba8a-448a-bd46-132798906631"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9040), "Description", new Guid("0872f471-2e73-4c4f-b305-88550d37aaf2"), "Nivea Body Lotion", 10.95m, new Guid("ac0e012a-ad7f-4e8e-bbad-ff3e8ffbb53f"), 0, null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Created", "Description", "Duration", "ImageUploadId", "Name", "Price", "ServiceCategoryId", "Updated" },
                values: new object[,]
                {
                    { new Guid("1f45cbf8-99ab-4247-a07a-468ed79f458d"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9267), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("8d6386ac-2456-46fb-97fc-481ad7affee3"), "7D Lashes Infill", 120m, new Guid("cb94f68a-e464-4c21-bb67-4101b2991a30"), null },
                    { new Guid("34b74d74-535d-4469-a617-327fafcc5c8a"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9368), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("c7d67191-5ff4-42e2-8caf-6dae0d33a0f8"), "Volume Eye Brow Trim and Shape", 90.00m, new Guid("2f86ab85-ed62-4db9-a3ad-6b4760440ed8"), null },
                    { new Guid("70489aec-a433-4d7c-8495-95d031470e26"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9206), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("8d6386ac-2456-46fb-97fc-481ad7affee3"), "3D Lashes Infill", 120m, new Guid("cb94f68a-e464-4c21-bb67-4101b2991a30"), null },
                    { new Guid("89129b41-3359-460f-8af2-159bfe430a0a"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9385), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("aa0d082d-8233-4ae6-b5b1-593c0261b96b"), "Classic Eye Brow lamination", 90.00m, new Guid("2f86ab85-ed62-4db9-a3ad-6b4760440ed8"), null },
                    { new Guid("aa97bd1d-929c-4cb0-9df8-e15b76e0177d"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9399), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("8d6386ac-2456-46fb-97fc-481ad7affee3"), "Volume Eye Brow Lamination", 90.00m, new Guid("2f86ab85-ed62-4db9-a3ad-6b4760440ed8"), null },
                    { new Guid("bdb17bc1-cb5e-43c5-b81e-218e37a948f0"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9309), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("08671e08-861a-4a26-8d71-c2e6036ca4d5"), "9D Lashes Infill", 120m, new Guid("cb94f68a-e464-4c21-bb67-4101b2991a30"), null },
                    { new Guid("bffcdd56-5ffd-470b-9bfb-1b8493758bfd"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9170), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("39b06fa9-7431-4ed2-9645-a1cf1b4bc45b"), "2D Lashes Infill", 120m, new Guid("cb94f68a-e464-4c21-bb67-4101b2991a30"), null },
                    { new Guid("c8f908e2-4f4a-45e8-8a5e-509e6e7b0947"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9245), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("26c03dbf-9ced-4236-b7e1-6829c9239130"), "6D Lashes Infill", 120m, new Guid("cb94f68a-e464-4c21-bb67-4101b2991a30"), null },
                    { new Guid("cb5fb109-d92e-4da4-ad0c-520c8295bcfa"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9348), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("aa0d082d-8233-4ae6-b5b1-593c0261b96b"), "Classic Eye Brow Trim and Shape", 90.00m, new Guid("2f86ab85-ed62-4db9-a3ad-6b4760440ed8"), null },
                    { new Guid("d1ca79be-3c9b-488a-9b01-1b42cc0c4c93"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9232), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("08671e08-861a-4a26-8d71-c2e6036ca4d5"), "5D Lashes Infill", 120m, new Guid("cb94f68a-e464-4c21-bb67-4101b2991a30"), null },
                    { new Guid("e77e959f-50a1-4b7f-8e49-d7890ad9ae18"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9286), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("d476c346-d3f1-4294-96c2-5daadb45504e"), "8D Lashes Infill", 120m, new Guid("cb94f68a-e464-4c21-bb67-4101b2991a30"), null },
                    { new Guid("f039a117-93b9-4d4f-bee7-07196491a6bd"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9329), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("39b06fa9-7431-4ed2-9645-a1cf1b4bc45b"), "10D Lashes Infill", 120m, new Guid("cb94f68a-e464-4c21-bb67-4101b2991a30"), null },
                    { new Guid("f95b206d-cf66-4aff-b848-9bfebc576c31"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9219), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("8d6386ac-2456-46fb-97fc-481ad7affee3"), "4D Lashes Infill", 120m, new Guid("cb94f68a-e464-4c21-bb67-4101b2991a30"), null }
                });

            migrationBuilder.InsertData(
                table: "ProductShowcases",
                columns: new[] { "Id", "Created", "ProductId", "Updated" },
                values: new object[] { new Guid("2bb25e7a-987f-42f4-8ff7-ec3bedf4770b"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9512), new Guid("cb808d2c-a43f-4271-a199-ae420c2afbff"), null });

            migrationBuilder.InsertData(
                table: "ServicesShowcases",
                columns: new[] { "Id", "Created", "ServiceId", "Updated" },
                values: new object[] { new Guid("316a8c48-00df-4940-8552-512fed889211"), new DateTime(2024, 12, 6, 23, 0, 24, 818, DateTimeKind.Utc).AddTicks(9415), new Guid("bffcdd56-5ffd-470b-9bfb-1b8493758bfd"), null });

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
