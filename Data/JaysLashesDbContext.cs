using BCrypt.Net;
using JricaStudioWebApi.Entities;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using JricaStudioWebApi.Models.Constants;
using System.Globalization;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JricaStudioWebApi.Data
{
    public class JaysLashesDbContext : DbContext
    {

        private readonly string _tempPW;
        private readonly string _email;
        public JaysLashesDbContext(DbContextOptions<JaysLashesDbContext> options, IConfiguration configuration) : base(options)
        {
            _tempPW = configuration.GetValue<string>("TemporaryPassword");
            _email = configuration.GetValue<string>("EmailUsername");

        }

        public DbSet<ImageUpload> ImageUploads { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentProduct> AppointmentProducts { get; set; }
        public DbSet<AppointmentService> AppointmentServices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductShowcase> ProductShowcases { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceShowCase> ServicesShowcases { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BusinessHours> BusinessHours { get; set; }
        public DbSet<BlockOutDate> BlockOutDates { get; set; }
        public DbSet<Policy> Policies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(appointment => appointment.User)
                .WithMany(user => user.Appointments)
                .HasForeignKey(appointment => appointment.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<AppointmentProduct>()
                .HasOne(appointmentProduct => appointmentProduct.Appointment)
                .WithMany(appointment => appointment.AppointmentProducts)
                .HasForeignKey(appointmentProducts => appointmentProducts.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppointmentProduct>()
                .HasOne(appointmentProduct => appointmentProduct.Product)
                .WithMany(product => product.AppointmentProducts)
                .HasForeignKey(appointmentProduct => appointmentProduct.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppointmentService>()
                .HasOne(appointmentService => appointmentService.Appointment)
                .WithMany(appointment => appointment.AppointmentServices)
                .HasForeignKey(appointmentServices => appointmentServices.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppointmentService>()
                .HasOne(appointmentService => appointmentService.Service)
                .WithMany(service => service.AppointmentServices)
                .HasForeignKey(appointmentService => appointmentService.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>().HasOne(service => service.ImageUpload).WithMany(imageupload => imageupload.Services).HasForeignKey(service => service.ImageUploadId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>().HasOne(product => product.ImageUpload).WithMany(imageUpload => imageUpload.Products).HasForeignKey(product => product.ImageUploadId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>().HasOne(product => product.ProductCategory).WithMany(category => category.Products).HasForeignKey(product => product.ProductCategoryId).OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);

            var classicSetExtentionsId = Guid.NewGuid();

            var lashExtensionProductCategoryId = Guid.NewGuid();

            var lashExtensionServiceCategoryId = Guid.NewGuid();

            var lotionProductCategoryId = Guid.NewGuid();

            var eyeBrowServiceCategoryId = Guid.NewGuid();

            var testServiceImagesUploadIds = new List<Guid>();

            var testProductImagesUploadIds = new List<Guid>();
            var serviceId = Guid.NewGuid();


            var serviceImagePath = "./wwwroot" + FileResources.serviceImageFilePath;

            DirectoryInfo serviceImageDirectory = new DirectoryInfo(serviceImagePath);

            if (serviceImageDirectory.EnumerateFiles().Count() == 0)
            {
                var TestServiceImagesPath = Path.Combine("./wwwroot/", "Images/", "TestImages/", "ServiceImages");

                DirectoryInfo TestServiceImageDirectory = new DirectoryInfo(TestServiceImagesPath);


                // read files from Test image folder save them as if they were uploaded

                if (TestServiceImageDirectory.EnumerateFiles().Any())
                {

                    var files = TestServiceImageDirectory.EnumerateFiles().ToList();
                    foreach (var file in files)
                    {
                        if (file != null)
                        {

                            byte[] data = new byte[file.Length];

                            using (var memStream = new MemoryStream())
                            {
                                using (var fileStream = File.OpenRead(file.FullName))
                                {
                                    fileStream.CopyTo(memStream);
                                    data = memStream.ToArray();
                                    fileStream.Close();
                                }
                                memStream.Position = 0;
                                memStream.Close();
                            }

                            var newFileName = Path.GetRandomFileName();


                            using (var stream = new MemoryStream(data))
                            {
                                var targetfile = Path.Combine(serviceImagePath, newFileName);
                                using (var fileStream = new FileStream(targetfile, FileMode.Create))
                                {
                                    stream.WriteTo(fileStream);
                                    fileStream.Close();
                                }
                                stream.Position = 0;
                                stream.Close();
                            }
                        }
                    }
                }
            }

            var serviceImageFiles = serviceImageDirectory.EnumerateFiles().ToList();
            // Store uploads in a list and use them iteratively through the context file.
            for (int i = 0; i < serviceImageFiles.Count; i++)
            {
                testServiceImagesUploadIds.Add(Guid.NewGuid());
                modelBuilder.Entity<ImageUpload>().HasData(new ImageUpload()
                {
                    Id = testServiceImagesUploadIds[i],
                    StoredFileName = serviceImageFiles[i].Name,
                    FileName = "TestImage" + i,
                    ContentType = "image"
                });

            }


            var productImagePath = "./wwwroot" + FileResources.productImageFilePath;

            DirectoryInfo productImageDirectory = new DirectoryInfo(productImagePath);

            if (productImageDirectory.EnumerateFiles().Count() == 0)
            {
                var testProductImagesPath = Path.Combine("./wwwroot/", "Images/", "TestImages/", "ProductImages");

                DirectoryInfo testProductImageDirectory = new DirectoryInfo(testProductImagesPath);


                // read files from Test image folder save them as if they were uploaded

                if (testProductImageDirectory.EnumerateFiles().Any())
                {

                    var files = testProductImageDirectory.EnumerateFiles().ToList();
                    foreach (var file in files)
                    {
                        if (file != null)
                        {

                            byte[] data = new byte[file.Length];

                            using (var memStream = new MemoryStream())
                            {
                                using (var fileStream = File.OpenRead(file.FullName))
                                {
                                    fileStream.CopyTo(memStream);
                                    data = memStream.ToArray();
                                    fileStream.Close();
                                }
                                memStream.Position = 0;
                                memStream.Close();
                            }

                            var newFileName = Path.GetRandomFileName();


                            using (var stream = new MemoryStream(data))
                            {
                                var targetfile = Path.Combine(productImagePath, newFileName);
                                using (var fileStream = new FileStream(targetfile, FileMode.Create))
                                {
                                    stream.WriteTo(fileStream);
                                    fileStream.Close();
                                }
                                stream.Position = 0;
                                stream.Close();
                            }
                        }
                    }
                }
            }

            var productImageFiles = productImageDirectory.EnumerateFiles().ToList();
            // Store uploads in a list and use them iteratively through the context file.
            for (int i = 0; i < productImageFiles.Count; i++)
            {
                testProductImagesUploadIds.Add(Guid.NewGuid());
                modelBuilder.Entity<ImageUpload>().HasData(new ImageUpload()
                {
                    Id = testProductImagesUploadIds[i],
                    StoredFileName = productImageFiles[i].Name,
                    FileName = "TestImage" + i,
                    ContentType = "image"
                });

            }


            modelBuilder.Entity<Admin>().HasData(new Admin()
            {
                Id = Guid.NewGuid(),
                AdminKey = Guid.NewGuid(),
                Username = _email,
                FirstName = "Jayrica",
                LastName = "Cunanan",
                Password = BCrypt.Net.BCrypt.HashPassword(_tempPW),
                Phone = "0422453888",

            });
            int utcOpenHourOfTheDay = 23;
            int utcCloseHourOfTheDay = 7;




        }

        private static Guid GetRandomId(List<Guid> guids)
        {
            var rand = new Random();
            return guids[rand.Next(0, guids.Count - 1)];
        }
    }
}
