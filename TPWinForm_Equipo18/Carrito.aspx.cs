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
        
        
        //public CarritoClase carrito {  get; set; }
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
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alert('Ventas suspendidas, intente nuevamente más tarde'); window.location.href = 'ListadoArticulos.aspx';", true);
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            List<Articulo> listaCarrito = (List<Articulo>)Session["Carrito"];
            //List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            int idArticulo = Convert.ToInt32(btn.CommandArgument);
            Articulo articulo = listaCarrito.FirstOrDefault(a=>a.id == idArticulo);
            //Articulo articulo = carrito.FirstOrDefault(a => a.id == idArticulo);
            decimal total = 0;

            //if (carrito.Count() > 1)
            if(listaCarrito.Count > 1)
            {
                total = 5000;
            }
            if (articulo != null)
            {     
                articulo.cantidad++;
                listaCarrito.Add(articulo);
                //carrito.Add(articulo);
              listaCount.Text = "  (" + listaCarrito.Count.ToString() + " productos)";
                CarritoClase carro = new CarritoClase();
                listaCarrito = carro.agrupar(listaCarrito);
                //carrito = carro.agrupar(carrito);
                decimal subtotal = carro.calcularTotal(listaCarrito);
                //decimal subTotal = carro.calcularTotal(carrito);
                lblsubtot.Text = subtotal.ToString();
                //lblsubtot.Text = subTotal.ToString();
                total += subtotal;
                //total += subTotal;
                lbltotal.Text = total.ToString();
            }

            Title = "Mi carrito";
            //listaCount.Text = "  (" + carrito.Count.ToString() + " productos)";
            GridCarrito.DataSource = listaCarrito;
            GridCarrito.DataBind();
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
             Button btn = (Button)sender;
             int idArticulo = Convert.ToInt32(btn.CommandArgument);
             List<Articulo> listaCarrito = (List<Articulo>)Session["Carrito"];
             //List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
             //Articulo articulo = carrito.FirstOrDefault(a => a.id == idArticulo);
             Articulo articulo = listaCarrito.FirstOrDefault(a => a.id == idArticulo);
             decimal total = 0;
                 CarritoClase carro = new CarritoClase();
             if(listaCarrito.Count > 0)
             //if(carrito.Count() > 0)
             {
                 total = 5000;
             }

             if (articulo != null)//) && articulo.cantidad > 0)
             {              
                 /*if (articulo.cantidad == 0)
                 {
                     listaCarrito.RemoveAll(a=>a.id == idArticulo);
                     //carrito.RemoveAll(a => a.id == idArticulo);

                     articulo.cantidad = 0;
                 }
                 else*/
                 //{
                  int cantidad = articulo.cantidad;
                  articulo.cantidad--;

                 listaCarrito.Remove(articulo);
                 //carrito.Remove(articulo);

                 //listaCarrito = carro.agrupar(listaCarrito);
                 //carrito = carro.agrupar(carrito);

                 decimal subTotal = carro.calcularTotal(listaCarrito);
                 //decimal subTotal = carro.calcularTotal(carrito);
                 lblsubtot.Text = subTotal.ToString();
                 total += subTotal;
                 lbltotal.Text = total.ToString();
                 Response.Redirect("Carrito.aspx");       
                //}

            }
             Title = "Mi carrito";
             listaCount.Text = "  (" + listaCarrito.Count.ToString() + " productos)";
             listaCarrito = carro.agrupar(listaCarrito);
             GridCarrito.DataSource = listaCarrito;
             GridCarrito.DataBind();

           


        }
        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            List<Articulo> listaCarrito = (List<Articulo>)Session["Carrito"];
            //List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            CarritoClase carro = new CarritoClase();
            Button btn = (Button)sender;
            decimal total = 0;
            int idArticulo = Convert.ToInt32(btn.CommandArgument);

            //Articulo articulo = carrito.FirstOrDefault(a => a.id == idArticulo);
            Articulo articulo = listaCarrito.FirstOrDefault(a => a.id == idArticulo);
            if (articulo != null)
            {
                listaCarrito.RemoveAll(a => a.id == idArticulo);
                //carrito.RemoveAll(a => a.id == idArticulo);
                articulo.cantidad = 0;
                //carrito.Remove(articulo);
            }
            listaCarrito = carro.agrupar(listaCarrito);
            //carrito = carro.agrupar(carrito);
            //decimal subTotal = carro.calcularTotal(carrito);
            decimal subTotal = carro.calcularTotal(listaCarrito);
            lblsubtot.Text = subTotal.ToString();
            total += subTotal;
            if(listaCarrito.Count > 0) 
            {
                total += 5000;
            }
            else
            {
                total = 0;
                lblenvio.Text = "0";
            }
            
            Title = "Mi carrito";
            listaCount.Text = "  (" + listaCarrito.Count.ToString() + " productos)";
            lbltotal.Text = total.ToString();
            GridCarrito.DataSource = listaCarrito;
            GridCarrito.DataBind();
        }

    }
}



//Aca va cambio