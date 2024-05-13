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
           CarritoClase carro = new CarritoClase();
           
                Button btn = (Button)sender;
                int rowIndex = Convert.ToInt32(btn.CommandArgument);
                Articulo aux = new Articulo();
                foreach (Articulo item in listaCarrito)
                {
                    if(item.id == rowIndex)
                    {
                        aux = item;
                        item.cantidad++; 
                        listaCarrito.Add(aux);
                        listaCarrito = carro.agrupar(listaCarrito);
                        break;
                    }
                }

            
            
            GridCarrito.DataSource = listaCarrito;
            GridCarrito.DataBind();
            
        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Articulo aux = new Articulo();
            CarritoClase carro = new CarritoClase();
            int idAeliminar = int.Parse(btn.CommandArgument);
            int x;

            if(!IsPostBack)
            {


            foreach (Articulo item in listaCarrito)
            {
                if (item.id == idAeliminar)
                    aux = item;
                    x = listaCarrito.IndexOf(item);
                    
                    listaCarrito.RemoveAt(x);
                    listaCarrito = carro.agrupar(listaCarrito);
            }
            }
            //listaCarrito = carrito.agrupar(listaCarrito);
            GridCarrito.DataSource = listaCarrito;
            GridCarrito.DataBind();
        }
    }
}