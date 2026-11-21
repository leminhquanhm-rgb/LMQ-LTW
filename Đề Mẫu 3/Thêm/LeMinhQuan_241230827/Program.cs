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
            builder.Services.AddControllersWithViews(options =>
            {
                options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(f => "Nguyên giá phải là số");
                options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((v, f) => "Nguyên giá phải là số");
            });

            builder.Services.AddDbContext<QLTaiSanContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("QlTaiSan")));

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
