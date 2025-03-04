using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JricaStudioWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addtimetoblockoutDateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid( "289f72b9-dd5e-4c62-8cc3-bd9238be78aa" ) );

            migrationBuilder.DeleteData(
                table: "BlockOutDates",
                keyColumn: "Id",
                keyValue: new Guid( "ca2a1114-2061-4751-9208-3d4594b46da4" ) );

            migrationBuilder.DeleteData(
                table: "BlockOutDates",
                keyColumn: "Id",
                keyValue: new Guid( "df962ca5-f7ab-4944-932c-5a86a2fafabb" ) );

            migrationBuilder.DeleteData(
                table: "BlockOutDates",
                keyColumn: "Id",
                keyValue: new Guid( "f1594056-9203-42ad-898d-c76d41290b8c" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "344da2fc-51a7-4c90-bdd4-143a1fe73f45" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "aebfb927-c479-4c33-b335-57545c2fecb9" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "c7ebeb74-1847-4496-b008-bbac45f99007" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "cfbca67a-55f3-4df6-8841-a6ef37de8649" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "d5ef645f-6417-46d8-89d7-fcb763761e0c" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "dd251297-40cb-4cdc-9adc-c061985643fa" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "e3721ccd-e3cb-47c2-9c7e-8f6b18917b1f" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "0fecd0b9-60de-408e-8ca3-cc317e0da539" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "a3b66ef9-0f71-4b72-9003-a109953a65a7" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "a79f8f85-0c38-4315-8f3f-cefaee7787e8" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "cc3764eb-7199-403f-bc6e-5384cc703eed" ) );

            migrationBuilder.DeleteData(
                table: "ProductShowcases",
                keyColumn: "Id",
                keyValue: new Guid( "be4bc69f-0b8c-487b-ab9c-05c635b519d2" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "021b8052-06c1-4017-b953-6525fd87f23c" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "13981371-e6c9-4cb3-a322-c6dbf6121261" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "5c783771-7ad0-49f8-9c7c-bffd7575daf0" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "9c585caf-c771-4e53-bec8-b15c1825b86a" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "a54c2de5-e609-4d9e-a0a6-b4445e70f0d0" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "fd891922-8d6a-423f-81a4-16b056c39738" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "fdbfe3ba-00e5-4ed6-828d-f14c63bd4564" ) );

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid( "0eea9506-3887-4b46-b6f7-dfbd463be983" ) );

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid( "70da8673-bb77-4a49-80bb-d893f85ddcd3" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "00d654fa-3075-44dd-a823-8aabb415f8de" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "01dde994-25f9-4a79-aa90-7fed7da10fdf" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "1de24c0e-4169-430b-b34b-cb330b15cd43" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "30bfc842-9b50-4a8e-8347-13a346c56484" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "37f4335a-56df-4bfe-b7ad-4ef3d5c7c856" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "45a40bf9-fbdb-455f-9ebb-97ef16342817" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "64ba7397-8448-40bd-9c88-e344ed84365b" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "90415701-0ee3-49fa-81c3-96c96cad462f" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "920a6164-4683-4f6c-aadf-ee5b584e731a" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "93390daa-f6c8-4f77-93eb-645f00be7480" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "b83a7850-71f7-41b9-a679-3b697c8f25bc" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "f7d099f9-7876-4027-a569-cd0c87240586" ) );

            migrationBuilder.DeleteData(
                table: "ServicesShowcases",
                keyColumn: "Id",
                keyValue: new Guid( "80796371-d14a-4975-b347-149cae0e4c12" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "00bdf40c-870a-42a5-a3be-0208d133edca" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "15303be6-ff19-444f-808f-9138f3ab7683" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "569a70a7-87a7-44fe-97e8-c6f59f659c7c" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "5911a2bb-5811-4362-90c1-abcb125c0fde" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "6bbf7b0b-e224-4b79-888f-7543abf59410" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "f2d1e8e9-258e-4dd1-b1f2-9b4b94b655ea" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "f537b478-4f69-4ecf-8452-08eceab8638f" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "fe0900ac-8d15-46ce-8891-1f1160cdc507" ) );

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid( "30ad4efc-ed66-4f54-8d56-b12006b3a331" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "d062a4d0-402e-4d32-b5cd-dbe34de701c8" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "311f4f1f-ea70-484f-87e1-d34d832d7180" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "46b83dab-354c-41f2-a3e8-87177e383bd1" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "62ad02b9-c784-4eba-bf9c-d672a19bfb72" ) );

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid( "3628ee5c-474d-43ca-b8dc-8973dfb7ecdf" ) );

            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndTime",
                table: "BlockOutDates",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly( 0, 0, 0 ) );

            migrationBuilder.AddColumn<TimeOnly>(
                name: "StartTime",
                table: "BlockOutDates",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly( 0, 0, 0 ) );

            //migrationBuilder.InsertData(
            //    table: "Admins",
            //    columns: new[] { "Id", "AdminKey", "Created", "FirstName", "LastName", "Password", "Phone", "ResetKey", "ResetKeySent", "Updated", "Username" },
            //    values: new object[] { new Guid( "895b8598-ce49-4b18-94a8-806ecfc9f283" ), new Guid( "1d9f0c95-62cc-42de-a3c6-28dad362017d" ), new DateTime( 2025, 3, 3, 23, 47, 54, 363, DateTimeKind.Utc ).AddTicks( 6976 ), "Jayrica", "Cunanan", "$2a$11$U0y.ukVPaWDwAgfy2GCNqurr9Dp33.oJ/yghVxYPeGqbOWhR15iwy", "0422453888", new Guid( "00000000-0000-0000-0000-000000000000" ), new DateTime( 1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified ), null, "jricastudio@gmail.com" } );

            //migrationBuilder.InsertData(
            //    table: "BlockOutDates",
            //    columns: new[] { "Id", "Created", "Date", "EndTime", "StartTime", "Updated" },
            //    values: new object[,]
            //    {
            //        { new Guid("26a9bd0f-f587-4bf8-ac29-78f368312721"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9287), new DateOnly(2025, 3, 7), new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), null },
            //        { new Guid("2e6f82e1-1042-447f-b510-bb62c5f294ef"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9298), new DateOnly(2025, 3, 9), new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), null },
            //        { new Guid("97ab2988-1e28-41d2-a207-05280b73c64f"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9262), new DateOnly(2025, 3, 5), new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), null }
            //    } );

            //migrationBuilder.InsertData(
            //    table: "BusinessHours",
            //    columns: new[] { "Id", "AfterHoursGraceRange", "CloseTime", "Created", "Day", "IsDisabled", "LocalTimeOffset", "OpenTime", "Updated" },
            //    values: new object[,]
            //    {
            //        { new Guid("15adfcdf-f01b-4693-9041-6975da0c2e87"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8707), 2, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
            //        { new Guid("1e0c0441-8153-470c-915c-d9e464e51720"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8738), 5, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
            //        { new Guid("755b8754-403b-408a-95eb-0a4bb318a97c"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8717), 3, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
            //        { new Guid("a71e6f0c-a2fe-49f1-86c9-4fe287a5d32f"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8748), 6, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
            //        { new Guid("b7e6faff-000f-4b34-9bed-23b534aaabcf"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8727), 4, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
            //        { new Guid("c1ff44f6-b889-44f4-ac60-42e25b44eb74"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8658), 0, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null },
            //        { new Guid("f86c60dd-c1d8-4222-bde7-3f69101557fb"), 2, new TimeOnly(7, 0, 0), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8697), 1, false, new TimeSpan(0, 10, 0, 0, 0), new TimeOnly(23, 0, 0), null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "ImageUploads",
            //    columns: new[] { "Id", "ContentType", "Created", "FileName", "StoredFileName", "Updated" },
            //    values: new object[,]
            //    {
            //        { new Guid("12083513-d677-4c80-b4e1-663a5efe861d"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(7828), "TestImage2", "bdoiftgs.rax", null },
            //        { new Guid("179c7307-69fd-4fe1-ac15-b7dddf5ca7c4"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(7881), "TestImage4", "e1uaxcux.m1n", null },
            //        { new Guid("20c81532-37f9-4b58-b583-c3d1c50b8571"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(7896), "TestImage5", "k3u5m2si.spe", null },
            //        { new Guid("2757aad8-cafc-4d31-b3f5-f9d03b0d320f"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(7840), "TestImage3", "bqkge5do.iss", null },
            //        { new Guid("35b79c9f-25c7-4987-a74d-d6370e2f1b5f"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8408), "TestImage2", "oz1c3ma1.kd1", null },
            //        { new Guid("3c9b8e19-b924-420f-9c6d-8c348b72ec56"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8354), "TestImage0", "jvkwqnf2.mre", null },
            //        { new Guid("50ced4a5-af31-489e-840b-e33aabca814a"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(7765), "TestImage0", "2njo3fl0.43m", null },
            //        { new Guid("5474364a-a628-45ab-809e-2c70737a3986"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(7911), "TestImage6", "tmbf3kzl.zwn", null },
            //        { new Guid("752d2923-ab54-42ab-944c-074d26740a63"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8369), "TestImage1", "ohtn2czj.s4o", null },
            //        { new Guid("892cf801-8a68-4c81-8635-441dc81a0ff9"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(7814), "TestImage1", "4fchlbk2.rya", null },
            //        { new Guid("915295a6-e48f-431b-aced-adcbabcdc229"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(7922), "TestImage7", "wcf3svy4.jnn", null },
            //        { new Guid("9aa8ab3e-82b7-42a5-97ba-cf46540d548e"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(7945), "TestImage9", "yuyzgysh.wjy", null },
            //        { new Guid("bf7cbcd1-3a49-47a6-aa68-56100a5713ff"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(7934), "TestImage8", "ynyhyfjf.yym", null },
            //        { new Guid("d82b2772-eef8-4137-9e07-53b3b65d63cb"), "image", new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8418), "TestImage3", "ttt312ik.ffr", null }
            //    } );

            //migrationBuilder.InsertData(
            //    table: "ProductCategories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("267dcea7-cc40-403f-a256-562b2c051617"), "Lotion" },
            //        { new Guid("f704d750-eda8-40c8-b854-07b62f2ad985"), "Eye Lash Extensions" }
            //    } );

            //migrationBuilder.InsertData(
            //    table: "ServiceCategories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("3718b242-5a0c-4064-813a-aa290b13e9f9"), "Eye Brow Shaping" },
            //        { new Guid("98b7ef20-87a3-4f5a-851c-0f62d9ccacc9"), "Eye Lash Extensions" }
            //    } );

            //migrationBuilder.InsertData(
            //    table: "Products",
            //    columns: new[] { "Id", "Created", "Description", "ImageUploadId", "Name", "Price", "ProductCategoryId", "Quantity", "Updated" },
            //    values: new object[,]
            //    {
            //        { new Guid("7e6497df-2c88-420e-9a94-055cc058fa19"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8924), "Description", new Guid("3c9b8e19-b924-420f-9c6d-8c348b72ec56"), "Nivea Body Lotion", 10.95m, new Guid("267dcea7-cc40-403f-a256-562b2c051617"), 0, null },
            //        { new Guid("877d2702-f0e2-4a99-8032-ee69e9b5aae1"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8848), "Description", new Guid("3c9b8e19-b924-420f-9c6d-8c348b72ec56"), "Aveeno Body Lotion", 10.95m, new Guid("267dcea7-cc40-403f-a256-562b2c051617"), 0, null },
            //        { new Guid("8d10ab2c-03a1-4164-a1cb-44ea2b17feae"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8911), "Description", new Guid("752d2923-ab54-42ab-944c-074d26740a63"), "Vaseline Body Lotion", 10.95m, new Guid("267dcea7-cc40-403f-a256-562b2c051617"), 0, null },
            //        { new Guid("8f213f86-02e8-4067-b3c6-b3006300de6b"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8976), "Description", new Guid("752d2923-ab54-42ab-944c-074d26740a63"), "Wet Look Style Eyelash Extensions", 30.60m, new Guid("f704d750-eda8-40c8-b854-07b62f2ad985"), 1, null },
            //        { new Guid("9c437b3b-b25c-4be2-ab62-5184630b3af0"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9012), "Description", new Guid("752d2923-ab54-42ab-944c-074d26740a63"), "3D Style Eyelash Extensions", 35.60m, new Guid("f704d750-eda8-40c8-b854-07b62f2ad985"), 1, null },
            //        { new Guid("cc881505-7ff6-46b7-9bd8-c3ac68feea8a"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8937), "Description", new Guid("35b79c9f-25c7-4987-a74d-d6370e2f1b5f"), "Curel Body Lotion", 10.95m, new Guid("267dcea7-cc40-403f-a256-562b2c051617"), 0, null },
            //        { new Guid("cca8cc78-05e5-4c7d-966c-c4a2a67a2d18"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8950), "Description", new Guid("3c9b8e19-b924-420f-9c6d-8c348b72ec56"), "Classic Style Eyelash Extensions", 30.60m, new Guid("f704d750-eda8-40c8-b854-07b62f2ad985"), 1, null },
            //        { new Guid("d294f357-b641-42a1-9ef2-bcbd1bfad3d3"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(8963), "Description", new Guid("752d2923-ab54-42ab-944c-074d26740a63"), "Volume Style Eyelash Extensions", 35.60m, new Guid("f704d750-eda8-40c8-b854-07b62f2ad985"), 1, null }
            //    } );

            //migrationBuilder.InsertData(
            //    table: "Services",
            //    columns: new[] { "Id", "Created", "Description", "Duration", "ImageUploadId", "Name", "Price", "ServiceCategoryId", "Updated" },
            //    values: new object[,]
            //    {
            //        { new Guid("06938412-ff7a-4a1b-a462-6d9d51eb6a1b"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9070), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("20c81532-37f9-4b58-b583-c3d1c50b8571"), "3D Lashes Infill", 120m, new Guid("98b7ef20-87a3-4f5a-851c-0f62d9ccacc9"), null },
            //        { new Guid("1d1ff609-6468-4dd1-bccd-7756c60b3685"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9200), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("892cf801-8a68-4c81-8635-441dc81a0ff9"), "Classic Eye Brow lamination", 90.00m, new Guid("3718b242-5a0c-4064-813a-aa290b13e9f9"), null },
            //        { new Guid("2dd37c42-d712-4592-98cd-10cbf42876de"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9084), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("5474364a-a628-45ab-809e-2c70737a3986"), "4D Lashes Infill", 120m, new Guid("98b7ef20-87a3-4f5a-851c-0f62d9ccacc9"), null },
            //        { new Guid("414270ed-e553-4511-b73f-d10e196068e8"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9214), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("915295a6-e48f-431b-aced-adcbabcdc229"), "Volume Eye Brow Lamination", 90.00m, new Guid("3718b242-5a0c-4064-813a-aa290b13e9f9"), null },
            //        { new Guid("44d3af12-6c29-4f52-8758-64b2a765efc4"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9163), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("5474364a-a628-45ab-809e-2c70737a3986"), "10D Lashes Infill", 120m, new Guid("98b7ef20-87a3-4f5a-851c-0f62d9ccacc9"), null },
            //        { new Guid("4630994f-f6b8-44cd-8172-4d3cb4ef4e68"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9111), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("2757aad8-cafc-4d31-b3f5-f9d03b0d320f"), "6D Lashes Infill", 120m, new Guid("98b7ef20-87a3-4f5a-851c-0f62d9ccacc9"), null },
            //        { new Guid("6d4c6e87-3713-4458-82f6-28d9ff3fea3a"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9188), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("5474364a-a628-45ab-809e-2c70737a3986"), "Volume Eye Brow Trim and Shape", 90.00m, new Guid("3718b242-5a0c-4064-813a-aa290b13e9f9"), null },
            //        { new Guid("a840afc0-6632-4c6b-adc7-417e8248fb18"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9124), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("2757aad8-cafc-4d31-b3f5-f9d03b0d320f"), "7D Lashes Infill", 120m, new Guid("98b7ef20-87a3-4f5a-851c-0f62d9ccacc9"), null },
            //        { new Guid("b66cc7ce-c72d-4651-be48-75dd752a144a"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9175), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("892cf801-8a68-4c81-8635-441dc81a0ff9"), "Classic Eye Brow Trim and Shape", 90.00m, new Guid("3718b242-5a0c-4064-813a-aa290b13e9f9"), null },
            //        { new Guid("ca04967c-8818-4fb5-9904-e4faec1d4faa"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9137), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("892cf801-8a68-4c81-8635-441dc81a0ff9"), "8D Lashes Infill", 120m, new Guid("98b7ef20-87a3-4f5a-851c-0f62d9ccacc9"), null },
            //        { new Guid("cfd655b0-a064-4633-b8da-050d95a5cca2"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9038), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("12083513-d677-4c80-b4e1-663a5efe861d"), "2D Lashes Infill", 120m, new Guid("98b7ef20-87a3-4f5a-851c-0f62d9ccacc9"), null },
            //        { new Guid("d32e7942-6d68-40b4-814f-f24fc9b3567a"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9098), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("50ced4a5-af31-489e-840b-e33aabca814a"), "5D Lashes Infill", 120m, new Guid("98b7ef20-87a3-4f5a-851c-0f62d9ccacc9"), null },
            //        { new Guid("d56db7e9-51db-42ff-a2e2-81f194394120"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9150), "Description", new TimeSpan(0, 3, 0, 0, 0), new Guid("892cf801-8a68-4c81-8635-441dc81a0ff9"), "9D Lashes Infill", 120m, new Guid("98b7ef20-87a3-4f5a-851c-0f62d9ccacc9"), null }
            //    } );

            //migrationBuilder.InsertData(
            //    table: "ProductShowcases",
            //    columns: new[] { "Id", "Created", "ProductId", "Updated" },
            //    values: new object[] { new Guid("715a3cae-8159-4911-b2c1-61101cd4dd23"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9317), new Guid("cca8cc78-05e5-4c7d-966c-c4a2a67a2d18"), null });

            //migrationBuilder.InsertData(
            //    table: "ServicesShowcases",
            //    columns: new[] { "Id", "Created", "ServiceId", "Updated" },
            //    values: new object[] { new Guid("6a7f6d04-7941-4640-a712-f8ccf8fe7fd9"), new DateTime(2025, 3, 3, 23, 47, 54, 454, DateTimeKind.Utc).AddTicks(9235), new Guid("cfd655b0-a064-4633-b8da-050d95a5cca2"), null });
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid( "895b8598-ce49-4b18-94a8-806ecfc9f283" ) );

            migrationBuilder.DeleteData(
                table: "BlockOutDates",
                keyColumn: "Id",
                keyValue: new Guid( "26a9bd0f-f587-4bf8-ac29-78f368312721" ) );

            migrationBuilder.DeleteData(
                table: "BlockOutDates",
                keyColumn: "Id",
                keyValue: new Guid( "2e6f82e1-1042-447f-b510-bb62c5f294ef" ) );

            migrationBuilder.DeleteData(
                table: "BlockOutDates",
                keyColumn: "Id",
                keyValue: new Guid( "97ab2988-1e28-41d2-a207-05280b73c64f" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "15adfcdf-f01b-4693-9041-6975da0c2e87" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "1e0c0441-8153-470c-915c-d9e464e51720" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "755b8754-403b-408a-95eb-0a4bb318a97c" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "a71e6f0c-a2fe-49f1-86c9-4fe287a5d32f" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "b7e6faff-000f-4b34-9bed-23b534aaabcf" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "c1ff44f6-b889-44f4-ac60-42e25b44eb74" ) );

            migrationBuilder.DeleteData(
                table: "BusinessHours",
                keyColumn: "Id",
                keyValue: new Guid( "f86c60dd-c1d8-4222-bde7-3f69101557fb" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "179c7307-69fd-4fe1-ac15-b7dddf5ca7c4" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "9aa8ab3e-82b7-42a5-97ba-cf46540d548e" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "bf7cbcd1-3a49-47a6-aa68-56100a5713ff" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "d82b2772-eef8-4137-9e07-53b3b65d63cb" ) );

            migrationBuilder.DeleteData(
                table: "ProductShowcases",
                keyColumn: "Id",
                keyValue: new Guid( "715a3cae-8159-4911-b2c1-61101cd4dd23" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "7e6497df-2c88-420e-9a94-055cc058fa19" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "877d2702-f0e2-4a99-8032-ee69e9b5aae1" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "8d10ab2c-03a1-4164-a1cb-44ea2b17feae" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "8f213f86-02e8-4067-b3c6-b3006300de6b" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "9c437b3b-b25c-4be2-ab62-5184630b3af0" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "cc881505-7ff6-46b7-9bd8-c3ac68feea8a" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "d294f357-b641-42a1-9ef2-bcbd1bfad3d3" ) );

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid( "3718b242-5a0c-4064-813a-aa290b13e9f9" ) );

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: new Guid( "98b7ef20-87a3-4f5a-851c-0f62d9ccacc9" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "06938412-ff7a-4a1b-a462-6d9d51eb6a1b" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "1d1ff609-6468-4dd1-bccd-7756c60b3685" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "2dd37c42-d712-4592-98cd-10cbf42876de" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "414270ed-e553-4511-b73f-d10e196068e8" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "44d3af12-6c29-4f52-8758-64b2a765efc4" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "4630994f-f6b8-44cd-8172-4d3cb4ef4e68" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "6d4c6e87-3713-4458-82f6-28d9ff3fea3a" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "a840afc0-6632-4c6b-adc7-417e8248fb18" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "b66cc7ce-c72d-4651-be48-75dd752a144a" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "ca04967c-8818-4fb5-9904-e4faec1d4faa" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "d32e7942-6d68-40b4-814f-f24fc9b3567a" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "d56db7e9-51db-42ff-a2e2-81f194394120" ) );

            migrationBuilder.DeleteData(
                table: "ServicesShowcases",
                keyColumn: "Id",
                keyValue: new Guid( "6a7f6d04-7941-4640-a712-f8ccf8fe7fd9" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "20c81532-37f9-4b58-b583-c3d1c50b8571" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "2757aad8-cafc-4d31-b3f5-f9d03b0d320f" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "35b79c9f-25c7-4987-a74d-d6370e2f1b5f" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "50ced4a5-af31-489e-840b-e33aabca814a" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "5474364a-a628-45ab-809e-2c70737a3986" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "752d2923-ab54-42ab-944c-074d26740a63" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "892cf801-8a68-4c81-8635-441dc81a0ff9" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "915295a6-e48f-431b-aced-adcbabcdc229" ) );

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid( "267dcea7-cc40-403f-a256-562b2c051617" ) );

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid( "cca8cc78-05e5-4c7d-966c-c4a2a67a2d18" ) );

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid( "cfd655b0-a064-4633-b8da-050d95a5cca2" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "12083513-d677-4c80-b4e1-663a5efe861d" ) );

            migrationBuilder.DeleteData(
                table: "ImageUploads",
                keyColumn: "Id",
                keyValue: new Guid( "3c9b8e19-b924-420f-9c6d-8c348b72ec56" ) );

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid( "f704d750-eda8-40c8-b854-07b62f2ad985" ) );

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "BlockOutDates" );

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "BlockOutDates" );

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AdminKey", "Created", "FirstName", "LastName", "Password", "Phone", "ResetKey", "ResetKeySent", "Updated", "Username" },
                values: new object[] { new Guid( "289f72b9-dd5e-4c62-8cc3-bd9238be78aa" ), new Guid( "00b4f2d5-4ca2-41ba-81f3-7e23a76f93bf" ), new DateTime( 2025, 1, 24, 0, 32, 44, 57, DateTimeKind.Utc ).AddTicks( 7645 ), "Jayrica", "Cunanan", "$2a$11$5jZmL66zrBNR68t3.xKZOu92/FtKL344Vkjz3vqqL877aa6Tw8qg6", "0422453888", new Guid( "00000000-0000-0000-0000-000000000000" ), new DateTime( 1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified ), null, "jricastudio@gmail.com" } );

            migrationBuilder.InsertData(
                table: "BlockOutDates",
                columns: new[] { "Id", "Created", "Date", "Updated" },
                values: new object[,]
                {
                    { new Guid("ca2a1114-2061-4751-9208-3d4594b46da4"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5851), new DateOnly(2025, 1, 26), null },
                    { new Guid("df962ca5-f7ab-4944-932c-5a86a2fafabb"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5880), new DateOnly(2025, 1, 28), null },
                    { new Guid("f1594056-9203-42ad-898d-c76d41290b8c"), new DateTime(2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc).AddTicks(5890), new DateOnly(2025, 1, 30), null }
                } );

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
                } );

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
                } );

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("30ad4efc-ed66-4f54-8d56-b12006b3a331"), "Lotion" },
                    { new Guid("3628ee5c-474d-43ca-b8dc-8973dfb7ecdf"), "Eye Lash Extensions" }
                } );

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0eea9506-3887-4b46-b6f7-dfbd463be983"), "Eye Lash Extensions" },
                    { new Guid("70da8673-bb77-4a49-80bb-d893f85ddcd3"), "Eye Brow Shaping" }
                } );

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
                } );

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
                } );

            migrationBuilder.InsertData(
                table: "ProductShowcases",
                columns: new[] { "Id", "Created", "ProductId", "Updated" },
                values: new object[] { new Guid( "be4bc69f-0b8c-487b-ab9c-05c635b519d2" ), new DateTime( 2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc ).AddTicks( 5912 ), new Guid( "d062a4d0-402e-4d32-b5cd-dbe34de701c8" ), null } );

            migrationBuilder.InsertData(
                table: "ServicesShowcases",
                columns: new[] { "Id", "Created", "ServiceId", "Updated" },
                values: new object[] { new Guid( "80796371-d14a-4975-b347-149cae0e4c12" ), new DateTime( 2025, 1, 24, 0, 32, 44, 150, DateTimeKind.Utc ).AddTicks( 5825 ), new Guid( "311f4f1f-ea70-484f-87e1-d34d832d7180" ), null } );
        }
    }
}
