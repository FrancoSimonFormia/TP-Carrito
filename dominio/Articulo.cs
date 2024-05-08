using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int id { get; set; }
        [DisplayName("Número")]
        public string codigo { get; set; }
        [DisplayName("nombre")]
        public string nombre { get; set; }
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
        [DisplayName("Precio")]
        public decimal precio { get; set; }
        [DisplayName("Marca")]
        public Marca marcaArticulo { get; set; }
        [DisplayName("Categoría")]
        public Categoria categoriaArticulo { get; set; }
        public string urlImagen { get; set; }

        public List<Imagen> imagenes { get; set; }
    }
}
