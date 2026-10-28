using LmqLesson11Lab4.Data;
using Microsoft.EntityFrameworkCore;

namespace LmqLesson11Lab4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Đăng ký DbContext và kết nối SQL Server
            builder.Services.AddDbContext<LmqSchoolContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("LmqSchoolContext")));

            var app = builder.Build();

            // Khởi tạo dữ liệu mẫu
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                LmqDbInitializer.Initialize(services);
            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}