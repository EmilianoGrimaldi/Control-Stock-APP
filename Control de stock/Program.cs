using Entidades;
using EntidadesBD;
using System.Configuration;

namespace Control_de_stock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using (var context = new ApplicationDbContext())
            {
                // Ejemplo: Obtener todos los productos
                try
                {
                    var productos = from p in context.Productos
                                    select p;

                    foreach (var producto in productos)
                    {
                        Console.WriteLine(producto.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            //using (SqlConnection cs = new SqlConnection(stringConnection)) 
            //{
            //    try
            //    {
            //        cs.Open();
            //        var productos = from p in cs.Productos;                                         

            //        foreach (var p in productos)
            //        {
            //            Console.WriteLine(p);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"{ex.Message} Conexion Exitosa");
            //    }
            //}        
        }
    }
}
