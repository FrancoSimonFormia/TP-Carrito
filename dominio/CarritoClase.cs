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
            foreach (ArticuloDeCarrito x in canasto)
            {
                if(x.id == restado.id)
                {
                    if(x.cantidad > 1)
                    {
                        x.cantidad--;
                    }
                    else
                    {
                        canasto.Remove(x);
                    }
                    return;
                }
            }
        }

        public void eliminarDeCanasto(int id)
        {
            foreach (ArticuloDeCarrito x in canasto)
            {
                if(x.id == id)
                {
                    canasto.Remove(x);
                }
            }
        }

        public decimal calcularTotal(List<Articulo> lista)
        {
            decimal total = 0;
            foreach (Articulo x in lista) 
            {
                total += x.precio * x.cantidad;
            }
            return total;
        }









        public int cantidad { get; set; }
        public List<Articulo> articulosAgrupados = new List<Articulo>();
        public List<Articulo> agrupar(List<Articulo> lista)
        {
            
            var articulosAgrupadosTemp = lista.GroupBy(x => x.id)
                                      .Select(y => new Articulo
                                      {
                                          id = y.Key,
                                          
                                          cantidad = y.Count(),
                                          
                                          descripcion = y.First().descripcion,
                                          nombre = y.First().nombre,
                                          precio = y.First().precio,
                                          imagenes = y.First().imagenes,
                                          marcaArticulo = y.First().marcaArticulo,
                                          categoriaArticulo = y.First().categoriaArticulo,
                                          codigo = y.First().codigo,
                                          total = y.Count() * y.First().precio
                                      })
                                      .ToList();



            articulosAgrupados.Clear();
            articulosAgrupados.AddRange(articulosAgrupadosTemp);
            return articulosAgrupados;
        }

        

    }
}
