
namespace WebApplicationDocker
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Urls.Clear(); // Fjerner alle eksisterende URL på listen Urls.
            app.Urls.Add("http://+:8080"); /* Tilføjer til listen + betyder alle netværksinterfaces på maskinen
                                            * alle IP-adresser, inklusiv localhost og enhver ekstern IP */
            app.MapControllers();

            app.Run();
        }
    }
}
