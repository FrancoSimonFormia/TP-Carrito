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

        private void inicializarArticulo()
        {
            seleccion = (Articulo)Session["DetalleArticulo"];

        }

        private void validarCampos()
        {

            ///Validacion en caso de que algún dato esté omitido en la DB
            ///Podemos hacer que, en vez de mostrar estos datos, se cargue 
            ///un mensaje de "Articulo inexistente" en base a la gravedad
            ///del dato omitido

            if(seleccion.marcaArticulo == null)
            {
                Marca porDefault = new Marca();
                porDefault.descripcion = "N/A";
                porDefault.id = -1;

                seleccion.marcaArticulo = porDefault;
            }

            if(seleccion.categoriaArticulo == null)
            {
                Categoria porDefault = new Categoria();
                porDefault.Descripcion = "N/A";
                porDefault.ID = -2;

                seleccion.categoriaArticulo = porDefault;
            }

            if(seleccion.descripcion == null)
            {
                seleccion.descripcion = "N/A";
            }

            if(seleccion.nombre == null)
            {
                seleccion.nombre = "N/A";
            }

            if(seleccion.codigo == null)
            {
                seleccion.codigo = "N/A";
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

            inicializarArticulo();
            validarCampos();
            cargarImagenes();
            Title = seleccion.nombre;


        }
    }
}