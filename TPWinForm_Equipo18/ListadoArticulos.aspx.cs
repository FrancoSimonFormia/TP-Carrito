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
                    List<Articulo> articulos = negocio.listar();

                    // Agrupar los artículos por su ID para eliminar duplicados
                    Articulos = articulos.GroupBy(a => a.id).Select(g => g.First()).ToList();
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
        protected void btnDetalles_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;
            Response.Redirect("Carrito.aspx?idArticulo=" + id);
        }

    }
}