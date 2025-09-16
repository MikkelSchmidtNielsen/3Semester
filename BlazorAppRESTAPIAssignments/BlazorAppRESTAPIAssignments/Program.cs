using BlazorAppRESTAPIAssignments.Client.Pages;
using BlazorAppRESTAPIAssignments.Client.Services;
using BlazorAppRESTAPIAssignments.Components;
using BlazorAppRESTAPIAssignments.Components.Models;

namespace BlazorAppRESTAPIAssignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            // Add services for controller
            builder.Services.AddControllers();

            builder.Services.AddScoped<IShoppingService, ShoppingService>(); // Hvorfor her?!
            builder.Services.AddScoped<IBookService, BookService>();

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7027/")
            });

            builder.Services.AddScoped<IShoppingRepository, ShoppingRepository>();

            // Hvis denne ikke er der -> Unable to resolve service for type 'IBookRepository' while attempting to activate 'BookController'.
            builder.Services.AddScoped<IBookRepository, BookRepository>(); 

            var app = builder.Build();

            // Map controllers
            app.MapControllers();

            // Map Blazor endpoints
            app.MapBlazorHub();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseWebAssemblyDebugging();
                app.UseDeveloperExceptionPage(); // Viser fejl ved api kald skriv i browseren "localhost:XXXX/api/bookapi".
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
