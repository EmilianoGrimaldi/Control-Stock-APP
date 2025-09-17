namespace Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

        public override string ToString()
        {
            return $"{Id} | {Descripcion} | {Nombre} | {Precio} | {Cantidad}";
        }
    }
}
