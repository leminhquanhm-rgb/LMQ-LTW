
namespace lmq_lesson10_lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.MapStaticAssets();

            // Route cho Admin/Student/List và Admin/Student/Add
            app.MapControllerRoute(
                name: "lmqStudent",
                pattern: "Admin/Student/{action}",
                defaults: new
                {
                    controller = "LmqStudent",
                    action = "List"
                });

            // Route mặc định
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=LmqStudent}/{action=LmqIndex}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
