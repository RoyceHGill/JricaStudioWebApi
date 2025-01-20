
using JricaStudioWebApi.Data;
using JricaStudioWebApi.Repositories.Contracts;
using JricaStudioWebApi.Repositories.Sqlite;
using JricaStudioWebApi.Services.Contracts;
using JricaStudioWebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.Data.SqlClient;

namespace JricaStudioWebApi
{
    public class Program
    {
        public static void Main( string[] args )
        {
            var builder = WebApplication.CreateBuilder( args );

#if DEBUG
            var connectionString = builder.Configuration.GetConnectionString( "JaysLashesLocalDBTest" ) ?? throw new InvalidOperationException( "Connection string 'JaysLashesLocalDBTest' not found." );

#else
            var connectionString = Environment.GetEnvironmentVariable("JaysLashesAzureDB") ?? throw new InvalidOperationException("Connection string 'JaysLashesAzureDB' not found.");
#endif


            builder.Services.AddDbContext<JaysLashesDbContext>( options =>
            {
                options.UseSqlServer( connectionString.ToString() );
            } );


            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<IEncryptionService, EncryptionService>();
            builder.Services.AddScoped<IImageAccessService, ImageAccessService>();

            builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();

            builder.Services.AddScoped<IStringEncryptionService, StringEncryptionService>();
            builder.Services.AddScoped<IProductRepository, ProductSqlRepository>();
            builder.Services.AddScoped<IServiceRepository, ServiceSqlRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentSqlRepository>();
            builder.Services.AddScoped<IUserRepository, UserSqlRepository>();
            builder.Services.AddScoped<ISchedulingRepository, SchedulingSqlRepository>();
            builder.Services.AddScoped<IAdminRepository, AdminSqlRepository>();
            builder.Services.AddScoped<IImageUploadRepository, ImageUploadSqlRepository>();
            builder.Services.AddScoped<ISchedulingService, SchedulingService>();
            builder.Services.AddScoped<IPolicyRepository, PolicySqlRepository>();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<JaysLashesDbContext>();
            dbContext.Database.EnsureCreated();

            // Configure the HTTP request pipeline.
            if ( app.Environment.IsDevelopment() )
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseCors( policy => policy.WithOrigins( "https://localhost:7239/", "https://localhost:7239" ).AllowAnyMethod().WithHeaders( HeaderNames.ContentType, "adminkey" ) );
            }

            app.UseCors( policy => policy.WithOrigins( "https://www.jricastudio.com/", "https://www.jricastudio.com", "https://polite-flower-07d8d6d0f.4.azurestaticapps.net/", "https://polite-flower-07d8d6d0f.4.azurestaticapps.net", "https://jricastudio.com/", "https://jricastudio.com" ).AllowAnyMethod().WithHeaders( HeaderNames.ContentType, "adminkey" ) );

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
