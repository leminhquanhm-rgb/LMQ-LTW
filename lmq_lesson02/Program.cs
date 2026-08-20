namespace lmq_lesson02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello Minh Quân ");

            app.Run();
        }
    }
}
