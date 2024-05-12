using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class CarritoClase
    {
        public int cantidad { get; set; }
        public List<Articulo> articulosAgrupados = new List<Articulo>();
        public List<Articulo> agrupar(List<Articulo> lista)
        {
            /*
            var articulosAgrupadosTemp = lista.GroupBy(a => a.id)
                                      .Select(g => new Articulo { id = g.Key, cantidad = g.Count() })
                                      .ToList();
            */

            var articulosAgrupadosTemp = lista.GroupBy(a => a.id)
                                      .Select(g => new Articulo
                                      {
                                          id = g.Key,
                                          
                                          cantidad = g.Count(),
                                          
                                          descripcion = g.First().descripcion,
                                          nombre = g.First().nombre,
                                          precio = g.First().precio,
                                          imagenes = g.First().imagenes,
                                          marcaArticulo = g.First().marcaArticulo,
                                          categoriaArticulo = g.First().categoriaArticulo,
                                          codigo = g.First().codigo,
                                          total = g.Count() * g.First().precio
                                      })
                                      .ToList();



            articulosAgrupados.Clear();
            articulosAgrupados.AddRange(articulosAgrupadosTemp);
            return articulosAgrupados;
        }

        

    }
}
