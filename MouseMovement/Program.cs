using Microsoft.EntityFrameworkCore;
using MouseMovementApp.Application;
using MouseMovementContext.infrastructure;
using MouseMovementContext.Models;
using MouseMovementDomain.Domain;

namespace MouseMovement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<mousemovementContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.RootDirectory = "/Presentation/Pages"; // ���������  ���� � ����� Pages
            });


            builder.Services.AddScoped<ICoordinateRepository, CoordinateRepository>();
            builder.Services.AddScoped<MouseMovementService>();


            builder.Services.AddControllers(); // ��������� ��������� API-������������
            builder.Services.AddEndpointsApiExplorer(); // ��� Swagger (���� ������������)
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // �������� ��� API-������������
                endpoints.MapRazorPages();  // �������� ��� Razor Pages
            });

            app.Run();
        }
    }
}
