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
    
    public partial class ListadoArticulos : System.Web.UI.Page
    {   
        public List<Articulo> Articulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
              {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulos = negocio.listar();
                    Articulos = Articulos.GroupBy(a => a.id).Select(g => g.First()).ToList();

                }
               catch (Exception ex)
                {
                    Session["Error"] = ex.Message;
                    Response.Redirect("Error.aspx");
               }


                repRepetidor.DataSource = Articulos;
                repRepetidor.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> articulos = negocio.listar();
                string busqueda = txtBuscar.Text.ToLower();
                articulos = articulos.FindAll(x => x.nombre.ToLower().Contains(txtBuscar.Text.ToLower()) || x.codigo.ToLower().Contains(txtBuscar.Text.ToLower()) || x.marcaArticulo.descripcion.ToLower().Contains(txtBuscar.Text.ToLower()) || x.categoriaArticulo.Descripcion.ToLower().Contains(txtBuscar.Text.ToLower()));
                Articulos = articulos.GroupBy(a => a.id).Select(g => g.First()).ToList();
                repRepetidor.DataSource = Articulos;
                repRepetidor.DataBind();
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;
            int identero = int.Parse(id);
            Articulo DetalleArticulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaParaBuscarArticuloDetalle = negocio.listar();
            DetalleArticulo = listaParaBuscarArticuloDetalle.Find(x => x.id == identero);

            if (DetalleArticulo != null)
            {
                Session.Add("DetalleArticulo", DetalleArticulo);
                Response.Redirect("Detalles.aspx");
            }
            else
            {
                Session["Error"] = "No se encontro el articulo";
                Response.Redirect("Error.aspx");
            }


        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
                Button btn = (Button)sender;
                string id = btn.CommandArgument;
                int identero = int.Parse(id);
                Articulo articuloParaElCarrito = new Articulo();
                 ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> listaParaagregaralcarrito = negocio.listar();

            articuloParaElCarrito = listaParaagregaralcarrito.Find(x => x.id == identero);
            
            

            if (articuloParaElCarrito != null)
            {
                if (Session["Carrito"] == null)
                {
                    List<Articulo> carrito = new List<Articulo>();
                    carrito.Add(articuloParaElCarrito);
                    Session.Add("Carrito", carrito);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "abirModalArticuloAgregado();", true);
                }
                else
                {
                    List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
                    carrito.Add(articuloParaElCarrito);
                    Session["Carrito"] = carrito;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "abirModalArticuloAgregado();", true);

                }
            }
            else
            {
                Session["Error"] = "No se encontro el articulo";
                Response.Redirect("Error.aspx");
            }


        }
               

        }


    }


   
