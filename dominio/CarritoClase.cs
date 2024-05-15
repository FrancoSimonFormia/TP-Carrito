using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class CarritoClase
    {
        public List<Articulo> canasto {  get; set; } = new List<Articulo>();
        public decimal Total
        {
            get 
            {  
                return canasto.Sum(a => a.subtotal);
            }

        }
        public int cantidadArticulo 
        { 
            get
            {
                return canasto.Sum(a=>a.cantidad); 
            }
        }

        public void sumarAlCanasto(Articulo agregado)
        {

            



            
            foreach (ArticuloDeCarrito item in canasto)
            {
                if(item.id == agregado.id)
                {
                    item.cantidad++;
                    return;
                }
            }
            canasto.Add(new ArticuloDeCarrito(agregado));
        }

        public void restarAlCanasto(Articulo restado)
        {
            foreach (ArticuloDeCarrito item in canasto)
            {
                if(item.id == restado.id)
                {
                    if(item.cantidad > 1)
                    {
                        item.cantidad--;
                    }
                    else
                    {
                        canasto.Remove(item);
                    }
                    return;
                }
            }
        }

        public void eliminarDeCanasto(int id)
        {
            foreach (ArticuloDeCarrito item in canasto)
            {
                if(item.id == id)
                {
                    canasto.Remove(item);
                }
            }
        }

        public decimal calcularTotal(List<Articulo> lista)
        {
            decimal total = 0;
            foreach (Articulo item in lista) 
            {
                total += item.precio * item.cantidad;
            }
            return total;
        }









        public int cantidad { get; set; }
        public List<Articulo> articulosAgrupados = new List<Articulo>();
        public List<Articulo> agrupar(List<Articulo> lista)
        {
            
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
