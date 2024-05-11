using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPWinForm_Equipo18
{
    public partial class About : Page
    {
        public Articulo seleccion = new Articulo();
        public List<Articulo> coleccion = new List<Articulo>();

        private void inicializarArticulo(int idArticulo)
        {
            foreach (Articulo articulo in coleccion)
            {
                if(articulo.id == idArticulo)
                {
                    seleccion = articulo;
                    break;
                }
            }
        }

        private void cargarImagenes()
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Imagen> imagenes = new List<Imagen>();

            try
            {
                imagenes = negocio.generarListaImagenes(seleccion.id);
                seleccion.imagenes = imagenes;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            coleccion = negocio.listar();

            inicializarArticulo(2);
            cargarImagenes();
            Title = seleccion.nombre;


        }
    }
}