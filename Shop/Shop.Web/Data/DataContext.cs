namespace Shop.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class DataContext : IdentityDbContext<Usuarios> // Este modelo ya viene actualizado con todas las entidades de usuario y la
                                                           //seguridad integrada de .netcore ypodemod pasar un modelo especifico


    //public class DataContext : DbContext // El DbContext funciona para realizar inyeccion de base de datos cada vez que se llama desde
    //otra clase es el modelo tradicional
    {
        /*
        pasos que tuve que hacer para que funcionara

1.agregar Microsoft.EntityFrameworkCore.Design de nuget
2.usar el using Microsoft.EntityFrameworkCore.Design; en DataContext y en startup
3.abrir powershell y ejecutar este commando desde la ruta de Shop.Web "dotnet tool install --global dotnet-ef"
4.agregar using System.ComponentModel.DataAnnotations.Schema; en Product
5.poner encima del[displayformat()][Column(TypeName = "decimal(18,2)")] tanta en Price como en stock
6.Ejecutar comando "dotnet ef database update" desde la ruta de Shop.Web
7.dotnet ef migrations add InitialDb
8.para borrar migraciones usar dotnet ef migrations remove
9.agregar nueva migracion add-migration ModifyProducts desde administracion paquete nuguet console
10.usar Remove-Migration para borrar migracion desde administracion paquete nuguet console
11.Ejecutar comando "dotnet ef database drop" desde la ruta de Shop.Web borra la base de datos
12.agregar nueva migracion add-migration Users desde administracion paquete nuguet console o dotnet ef migrations add Users desde consola
13.dotnet ef migrations remove  borra la ultima migracion ejecutada */
        public DbSet<Productos> productos { get; set; }
        public DbSet<Pais> paises { get; set; }
        // prop
        //ctor
        public DataContext(DbContextOptions<DataContext> options) : base(options)

        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Productos>()
        .Property(p => p.Precio)
        .HasColumnType("decimal(18,2)");

            var cascadeFKs = builder.Model
        .G­etEntityTypes()
        .SelectMany(t => t.GetForeignKeys())
        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }


            base.OnModelCreating(builder);
        }
    }
}
