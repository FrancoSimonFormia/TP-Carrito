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
        
        
        public CarritoClase carrito {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                listaCarrito = (List<Articulo>)Session["Carrito"];

                decimal env = 5000;
                Title = "Mi carrito";
                CarritoClase carro = new CarritoClase();
            
                if(listaCarrito == null || listaCarrito.Count == 0)
                {
                     //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alert('no posee articulos en el carrito');", true);
                    //ClientScript.RegisterStartupScript(this.GetType(), "setTimeout", "setTimeout('2000')", true);
                     ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alert('No posee artículos en el carrito'); window.location.href = 'ListadoArticulos.aspx';", true);
                     //Response.Redirect("ListadoArticulos.aspx");
                
                }
                else 
                { 
                    listaCount.Text = "  (" + listaCarrito.Count.ToString() + " productos)";
                    lblSeguirComprando.Text = "seguir comprando";

                    listaCarrito = carro.agrupar(listaCarrito);

                    lblsubtot.Text = "$" + carro.calcularTotal(listaCarrito).ToString();
                    decimal sub = carro.calcularTotal(listaCarrito);
                    lblenvio.Text = "$5000";    
                    decimal total = env + sub;
                    
                    lbltotal.Text = "$" + total.ToString();
                
                
                }
            GridCarrito.DataSource = listaCarrito; 
            GridCarrito.DataBind();
            }

        }
        
       

        protected void btnCompra_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            int idArticulo = Convert.ToInt32(btn.CommandArgument);
            Articulo articulo = carrito.FirstOrDefault(a => a.id == idArticulo);
            decimal total = 0;
            if(carrito.Count() > 1)
            {
                total = 5000;
            }
            if (articulo != null)
            {     
                articulo.cantidad++;
                carrito.Add(articulo);
                CarritoClase carro = new CarritoClase();
                carrito = carro.agrupar(carrito);
                decimal subTotal = carro.calcularTotal(carrito);
                lblsubtot.Text = subTotal.ToString();
                total += subTotal;
                lbltotal.Text = total.ToString();
            }         
            listaCount.Text = "  (" + carrito.Count.ToString() + " productos)";
            GridCarrito.DataSource = carrito;
            GridCarrito.DataBind();
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int idArticulo = Convert.ToInt32(btn.CommandArgument);
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            Articulo articulo = carrito.FirstOrDefault(a => a.id == idArticulo);
            decimal total = 0;

            if(carrito.Count() > 0)
            {
                total = 5000;
            }
            if (articulo != null && articulo.cantidad > 0)
            {              
                if (articulo.cantidad == 0)
                {
                    carrito.RemoveAll(a => a.id == idArticulo);
                    //carrito.Remove(articulo);
                    
                }
                articulo.cantidad--;
                carrito.Remove(articulo);
                CarritoClase carro = new CarritoClase();
                carrito = carro.agrupar(carrito);
                decimal subTotal = carro.calcularTotal(carrito);
                lblsubtot.Text = subTotal.ToString();
                total += subTotal;
                lbltotal.Text = total.ToString();
            }
            GridCarrito.DataSource = carrito;
            GridCarrito.DataBind();
        }
        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            CarritoClase carro = new CarritoClase();
            Button btn = (Button)sender;
            decimal total = 0;
            int idArticulo = Convert.ToInt32(btn.CommandArgument);


            Articulo articulo = carrito.FirstOrDefault(a => a.id == idArticulo);
            if (articulo != null)
            {
                carrito.RemoveAll(a => a.id == idArticulo);
                articulo.cantidad = 0;
                //carrito.Remove(articulo);
            }
            carrito = carro.agrupar(carrito);
            decimal subTotal = carro.calcularTotal(carrito);
            lblsubtot.Text = subTotal.ToString();
            total += subTotal;
            if(carrito.Count() > 0)
            {
                total += 5000;
            }
            else
            {
                total = 0;
                lblenvio.Text = "0";
            }
            lbltotal.Text = total.ToString();
            GridCarrito.DataSource = carrito;
            GridCarrito.DataBind();
        }

    }
}