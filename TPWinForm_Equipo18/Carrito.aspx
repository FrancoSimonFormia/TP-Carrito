<%@ Page Title="Mi Carrito " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWinForm_Equipo18.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="estilosCarrito.css">
    <main aria-labelledby="title">

        <div style="display: flex; align-items: center;">
            <h2 id="title" style="margin-right: 10px;"><%: Title %></h2>
            <asp:Label ID="listaCount" runat="server" Text=""></asp:Label>
        </div>

        <a href="Default.aspx">
            <asp:Label ID="lblSeguirComprando" runat="server" Text=""></asp:Label>
        </a>


        <asp:GridView ID="GridCarrito" runat="server" AutoGenerateColumns="false" CssClass="table align-baseline w-75 border-0" OnRowDataBound="GridCarrito_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Image runat="server" ImageUrl='<%# Eval("imagenes[0].Url") %>' Alt="Imagen de artículo" Width="150px" Height="150px" onerror="this.onerror=null;this.src='https://static.vecteezy.com/system/resources/previews/004/639/366/non_2x/error-404-not-found-text-design-vector.jpg';" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField HeaderText="" DataField="nombre" />
                <asp:BoundField HeaderText="Precio Unitario" DataField="precio" />


                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-danger rounded-5" ID="btnRestar" runat="server" OnClick="btnRestar_Click" Text="-" CommandName="RestarArticulo" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField HeaderText="" DataField="cantidad" />


                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-success rounded-5" ID="btnSumar" OnClick="btnSumar_Click" runat="server" Text="+" CommandName="sumarArticulo" CommandArgument='<%# Eval("ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField HeaderText=" Total Por Articulo " DataField="total" />

                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="btn btn-danger rounded-5" OnClick="btnEliminar_Click1" runat="server" Text="X" CommandName="eliminarArticulo" CommandArgument='<%#Eval("id") %>' />

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>



        <div class="ContenedorCompra">
            <div class="tarjetaCompra">
                <div>
                    <label class="lblCompra1">Subtotal:</label>
                    <asp:Label ID="lblsubtot" runat="server" Text=""></asp:Label>
                </div>

                <div>
                    <label class="lblCompra1">Costo de envío:</label>
                    <asp:Label ID="lblenvio" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <label class="lblCompra1">Total:</label>
                    <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:Button CssClass="btn btn-primary btn-lg" ID="btnCompra" runat="server" Text="Ir a comprar" OnClick="btnCompra_Click" />
                </div>
            </div>
        </div>


        <div class="modal fade" id="successModal" tabindex="-1" aria-labelledby="successModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="successModalLabel"></h5>
                        <button type="button" class=" btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <p id="mensajeModal"></p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary " data-bs-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>


        <address>
            <br />
        </address>
    </main>

    <script>
        // esta funcion abre la modal cuando es llamada desde el codebehind
        function abrirModalCarritoVacio() {
            let mensaje = document.getElementById("mensajeModal");
            mensaje.innerText = "No posee artículos en el carrito";

            let titulo = document.getElementById("successModalLabel");
            titulo.innerText = "Carrito vacío";

            var myModal = new bootstrap.Modal(document.getElementById('successModal'), {
                keyboard: false
            });
            myModal.show();

        }

        function abrirModalVentaSuspendida() {
            let mensaje = document.getElementById("mensajeModal");
            mensaje.innerText = "Ventas suspendidas, intente nuevamente más tarde";

            let titulo = document.getElementById("successModalLabel");
            titulo.innerText = "Función no disponible";

            var myModal = new bootstrap.Modal(document.getElementById('successModal'), {
                keyboard: false
            });
            myModal.show();

        }



    </script>

</asp:Content>
