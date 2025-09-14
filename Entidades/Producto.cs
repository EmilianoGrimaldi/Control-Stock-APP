namespace Entidades
{
    public class Producto
    {
        string nombre;
        string descripcion;
        int cantidad;

        public Producto(string nombre, string descripcion, int cantidad)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
        }
        public string Nombre 
        { 
            get => nombre; 
            set =>  nombre = !String.IsNullOrEmpty(value) ? value : Nombre; 
        }
        public string Descripcion 
        { get => descripcion; 
          set => descripcion = !String.IsNullOrEmpty(value) ? value : Descripcion; 
        }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public override string ToString()
        {
            return $"{Nombre} | {Descripcion} | {Cantidad}";
        }
    }
}
