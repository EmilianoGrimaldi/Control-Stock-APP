using Entidades;
using EntidadesBD;
using System.Configuration;

namespace Control_de_stock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           ProductoDAO productoDAO = new ProductoDAO();
            productoDAO.LeerTodos().ForEach(p =>
            {
                Console.WriteLine(p.ToString());
            });
        }
    }
}
