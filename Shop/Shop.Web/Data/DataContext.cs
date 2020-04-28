namespace Shop.Web.Data
{
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Data.Entities;
    public class DataContext : DbContext // El Context funciona para realizar inyeccion de base de datos cada vez que se llama desde
                                         //otra clase
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
*/
        public DbSet<Productos> productos { get; set; }
        // prop
        //ctor
        public DataContext(DbContextOptions<DataContext> options) : base(options)

        {

        }
    }
}
