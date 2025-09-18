using Entidades;
using EntidadesBD;

namespace ProductoDAO
{
    public static class ProductoDAO
    {
        public static List<Producto> ObtenerTodos(ApplicationDbContext )
        {
            using (var context = new ApplicationDbContext())
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
    }
}
