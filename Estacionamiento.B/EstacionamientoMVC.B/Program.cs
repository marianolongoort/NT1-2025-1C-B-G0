using EstacionamientoMVC.B.Models;

namespace EstacionamientoMVC.B
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();


            Persona persona1 = new Persona() {
                Nombre = "Pablo",
                Apellido = "Marmol"                
            };

            persona1.Nombre = "Pedro";
            persona1.Apellido = "Picapiedra";
            //uso de modificador de acceso set
            string unavariable = persona1.Apellido;
            
            //uso de modificador de acceso get
            persona1.Apellido = "Otro apellido";

            Direccion direccion = new Direccion();

            string apellido = direccion.Persona.Apellido;

            direccion.Persona.Apellido = string.Empty;
        }
    }
}
