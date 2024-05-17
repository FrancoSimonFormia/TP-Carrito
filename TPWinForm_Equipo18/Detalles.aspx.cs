using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using static System.Net.WebRequestMethods;

namespace TPWinForm_Equipo18
{
    public partial class About : Page
    {
        public Articulo seleccion = new Articulo();
        public string invalidUrl = "https://static.vecteezy.com/system/resources/previews/004/639/366/non_2x/error-404-not-found-text-design-vector.jpg";

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
            ///
            if(seleccion == null)
            {
                seleccion = new Articulo();
                Response.Redirect("ListadoArticulos.aspx");
            }

            if (seleccion.marcaArticulo == null)
            {  
                Marca porDefault = new Marca();
                porDefault.descripcion = "N/A";
                porDefault.id = -1;

                seleccion.marcaArticulo = porDefault;
            }

            if (seleccion.categoriaArticulo == null)
            {
                Categoria porDefault = new Categoria();
                porDefault.Descripcion = "N/A";
                porDefault.ID = -2;

                seleccion.categoriaArticulo = porDefault;
            }

            if (seleccion.descripcion == null)
            {
                seleccion.descripcion = "N/A";
            }

            if (seleccion.nombre == null)
            {
                seleccion.nombre = "N/A";
            }

            if (seleccion.codigo == null)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
         {
            inicializarArticulo();
            validarCampos();
            cargarImagenes();
            Title = seleccion.nombre;

            if (!IsPostBack)
                txtCantidad.Text = "1";



        }


        private void agregarAlCarrito(Articulo aniadir, List<Articulo> carritoCompras)
        {
            int cantidad = int.Parse(auxCantidad.Value);

            for (int i = 0; i < cantidad; i++)
            {
                carritoCompras.Add(aniadir);
            }

        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
           
            if (Session["Carrito"] == null)
            {
                List<Articulo> carrito = new List<Articulo>();
                agregarAlCarrito(seleccion, carrito);
                Session.Add("Carrito", carrito);
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alert('Artículo agregado al carrito exitosamente');", true);
            }
            else
            {
                List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
                agregarAlCarrito(seleccion, carrito);
                Session["Carrito"] = carrito;
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alert('Artículo agregado al carrito exitosamente');", true);


            }


        }


    }
}