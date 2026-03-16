
namespace StudentManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSingleton<Services.IStudentService, Services.StudentService>();

            var app = builder.Build();

            // Swagger is disabled in this build to avoid requiring the Swashbuckle package.

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
