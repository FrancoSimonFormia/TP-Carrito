using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ArticuloDeCarrito : Articulo
    {
        public ArticuloDeCarrito(Articulo aux) 
        {
            id = aux.id;
            codigo = aux.codigo;
            descripcion = aux.descripcion;
            precio = aux.precio;
            imagenes = aux.imagenes;
            cantidad = 1;
            marcaArticulo = aux.marcaArticulo;
            categoriaArticulo = aux.categoriaArticulo;
            nombre = aux.nombre;
            

        }
        public ArticuloDeCarrito() { }
        public int cantidad { get; set; }
        
    }
}
