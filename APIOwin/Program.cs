
using Microsoft.AspNetCore.DataProtection;

namespace APIOwin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication("Identity.Application")
                .AddCookie("Identity.Application", options => {
                    options.Cookie.Name = "AUTH";                    
                });

            builder.Services.AddDataProtection()
                .SetApplicationName("SharedCookieApp")
                .PersistKeysToFileSystem(new DirectoryInfo(@"c:\ring-folder")); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

          

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

           

            
        }

        
    }
}
