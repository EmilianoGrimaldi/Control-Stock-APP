using Entidades;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;    
using System.Collections.Generic;
using System.Configuration;

namespace EntidadesBD
{
    // Define una clase pública llamada ProductoDAO que hereda de DbContext
    // DbContext es la clase base de Entity Framework que representa una sesión con la base de datos
    public class ProductoDAO : DbContext
    {

        // Define una propiedad DbSet para la entidad Producto
        // Un DbSet representa una tabla en la base de datos y permite realizar operaciones CRUD
        // Entity Framework usará esta propiedad para mapear la tabla Productos
        public DbSet<Producto> Productos { get; set; }

        // Este método se sobreescribe para configurar las opciones del DbContext
        // Se ejecuta automáticamente cuando se crea una instancia del DbContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verifica si el optionsBuilder ya ha sido configurado previamente
            // Esto es útil para evitar sobreescribir configuraciones que puedan venir desde fuera
            if (!optionsBuilder.IsConfigured)
            {
                // Obtiene la cadena de conexión desde el archivo de configuración (App.config o Web.config)
                // "connectionBD" es el nombre de la connection string definida en el archivo de configuración
                string connectionString = ConfigurationManager.ConnectionStrings["connectionBD"].ConnectionString;

                // Configura el DbContext para usar SQL Server como proveedor de base de datos
                // y le pasa la cadena de conexión obtenida del archivo de configuración
                object value = optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public List<Producto> LeerTodos()
        {
            using (var context = new ProductoDAO())
            {
                try
                {
                    var productos = from p in context.Productos
                                    select p;

                    return productos.ToList();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public bool AgregarProducto(Producto p)
        {
            using (var context = new ProductoDAO())
            {
                try
                {
                    context.Productos.Add(p);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public bool EliminarProducto(int id)
        {
            using (var context = new ProductoDAO())
            {
                try
                {
                    var producto = context.Productos.Find(id);
                    if (producto != null)
                    {
                        context.Productos.Remove(producto);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public bool ModificarProducto(Producto p)
        {
            using (var context = new ProductoDAO())
            {
                try
                {
                    var producto = context.Productos.Find(p.Id);
                    if (producto != null)
                    {
                        producto.Nombre = p.Nombre;
                        producto.Descripcion = p.Descripcion;
                        producto.Precio = p.Precio;
                        producto.Cantidad = p.Cantidad;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
