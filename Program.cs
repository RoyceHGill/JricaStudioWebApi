
using JricaStudioWebAPI.Data;
using JricaStudioWebAPI.Repositories.Contracts;
using JricaStudioWebAPI.Repositories.SqLite;
using JricaStudioWebAPI.Services.Contracts;
using JricaStudioWebAPI.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace JricaStudioWebAPI
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

            builder.Services.AddTransient<IEncryptionService, EncryptionService>();
            builder.Services.AddTransient<IImageAccessService, ImageAccessService>();

            builder.Services.AddSingleton<IEmailSenderService, EmailSenderService>();

            builder.Services.AddScoped<IStringEncryptionService, StringEncryptionService>();
            builder.Services.AddScoped<IProductRepository, ProductSqLiteRepository>();
            builder.Services.AddScoped<IServiceRepository, ServiceSqLiteRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentSqliteRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ISchedulingRepository, SchedulingSqLiteRepository>();
            builder.Services.AddScoped<IAdministratorRepository, AdministratorSqLiteRepository>();
            builder.Services.AddScoped<IImageUploadRepository, ImageUploadSqliteRepository>();
            builder.Services.AddScoped<ISchedulingService, SchedulingService>();
            builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1);
            });

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

            app.UseSession();

            app.MapControllers();

            app.Run();
        }
    }
}
