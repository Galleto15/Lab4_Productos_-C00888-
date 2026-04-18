using System.Collections.Generic;
using System.Linq;

namespace Lab4_Productos__C00888.Models
{
    public static class ProductoRepositorio
    {
        private static List<Producto> productos = new List<Producto>();
        private static int nextId = 1;

        public static List<Producto> ObtenerTodos()
        {
            return productos;
        }

        public static Producto ObtenerPorId(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        public static void Agregar(Producto p)
        {
            p.Id = nextId++;
            productos.Add(p);
        }

        public static void Actualizar(Producto p)
        {
            var productoExistente = ObtenerPorId(p.Id);
            if (productoExistente != null)
            {
                productoExistente.Nombre = p.Nombre;
                productoExistente.Precio = p.Precio;
                productoExistente.Categoria = p.Categoria;
            }
        }

        public static void Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null)
            {
                productos.Remove(producto);
            }
        }
    }
}
