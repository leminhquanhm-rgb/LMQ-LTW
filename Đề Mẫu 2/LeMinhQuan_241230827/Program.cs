using LeMinhQuan_241230827.Models;
using Microsoft.EntityFrameworkCore;

namespace LeMinhQuan_241230827
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddMvcOptions(o => 
                {
                    o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(_ => "Giá phải là số");   
                }); 
                


            // Lấy chuỗi kết nối

            var LmqConnection = builder.Configuration.GetConnectionString("QLNhaSachContext");
            builder.Services.AddDbContext<QLNhaSachContext>(x => x.UseSqlServer(LmqConnection));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
