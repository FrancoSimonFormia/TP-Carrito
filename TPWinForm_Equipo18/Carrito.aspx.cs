using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWinForm_Equipo18
{
    public partial class Contact : Page
    {
        List<Articulo> listaCarrito = new List<Articulo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            listaCarrito = (List<Articulo>)Session["Carrito"];
            decimal env = 5000;
            Title = "Mi carrito";
            if(listaCarrito == null || listaCarrito.Count == 0)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alert('no posee articulos en el carrito');", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "setTimeout", "setTimeout('2000')", true);
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alert('No posee artículos en el carrito'); window.location.href = 'ListadoArticulos.aspx';", true);
                //Response.Redirect("ListadoArticulos.aspx");
                
            }
            else { 
            listaCount.Text = "  (" + listaCarrito.Count.ToString() + " productos)";
            lblSeguirComprando.Text = "seguir comprando";

            GridCarrito.DataSource = listaCarrito;  
            GridCarrito.DataBind();
            lblsubtot.Text = "$" + subtotalArticulos().ToString();
            decimal sub = subtotalArticulos();
            lblenvio.Text = "$5000";           
            decimal total = env + sub;
            lbltotal.Text = "$" + total.ToString();

            }

        }
        public decimal subtotalArticulos()
        {
            decimal subtotal = 0;

            foreach (Articulo item in listaCarrito)
            {
                subtotal += item.precio;
            }
                      
            return subtotal;
        }

        protected void btnCompra_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            listaCarrito.RemoveAll(listaCarrito.Contains);
        }
    }
}