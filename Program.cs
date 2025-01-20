
using JricaStudioWebApi.Data;
using JricaStudioWebApi.Repositories.Contracts;
using JricaStudioWebApi.Repositories.Sqlite;
using JricaStudioWebApi.Services.Contracts;
using JricaStudioWebApi.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace JricaStudioWebApi
{
    public class Program
    {
        public static void Main( string[] args )
        {
            var builder = WebApplication.CreateBuilder( args );

            var baseConnectionString = builder.Configuration.GetConnectionString( "JaysLashesContext" ) ?? throw new InvalidOperationException( "Connection string 'JaysLashesContext' not found." );

            var connectionString = new SqliteConnectionStringBuilder( baseConnectionString )
            {
                Mode = SqliteOpenMode.ReadWriteCreate,

#if DEBUG
                Password = builder.Configuration.GetValue<string>( "SQLiteDBPassword" )
#else
    Password = Environment.GetEnvironmentVariable("SQLiteDBPassword")
#endif
            };
            builder.Services.AddDbContext<JaysLashesDbContext>( options =>
                            options.UseSqlite( connectionString.ToString() ) );

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<IEncryptionService, EncryptionService>();
            builder.Services.AddScoped<IImageAccessService, ImageAccessService>();

            builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();

            builder.Services.AddScoped<IStringEncryptionService, StringEncryptionService>();
            builder.Services.AddScoped<IProductRepository, ProductSqliteRepository>();
            builder.Services.AddScoped<IServiceRepository, ServiceSqliteRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentSqliteRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ISchedulingRepository, SchedulingSqliteRepository>();
            builder.Services.AddScoped<IAdminRepository, AdminSqliteRepository>();
            builder.Services.AddScoped<IImageUploadRepository, ImageUploadSqliteRepository>();
            builder.Services.AddScoped<ISchedulingService, SchedulingService>();
            builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if ( app.Environment.IsDevelopment() )
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseCors( policy => policy.WithOrigins( "https://localhost:7239/", "https://localhost:7239" ).AllowAnyMethod().WithHeaders( HeaderNames.ContentType, "adminkey" ) );
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
