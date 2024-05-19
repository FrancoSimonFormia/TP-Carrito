<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWinForm_Equipo18.ListadoArticulos" EnableEventValidation="false" %>

<%@ Import Namespace="dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <main aria-labelledby="title">


        <div class="d-inline mb-3">
            <asp:TextBox ID="txtBuscar" runat="server" AutoPostBack="false" class="form-control d-inline" MaxLength="30"></asp:TextBox>
            <button type="button" class="btn btn-outline-danger d-inline" id="btnBuscar">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-filter-circle-fill" viewBox="0 0 16 16">
                    <path d="M8 16A8 8 0 1 0 8 0a8 8 0 0 0 0 16M3.5 5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1 0-1M5 8.5a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5m2 3a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5"></path>
                </svg>
                Buscar
            </button>
        </div>

        <!--  -----  boton clave, por defecto recibe el enter (si movemos esta linea tenemos que manejar el postback) y tambien funciona recibiendo el evencto click del otro boton mas bonito. ---->

        <asp:Button ID="hiddenBtnBuscar" runat="server" OnClick="btnBuscar_Click" Style="display: none" />

        <!--  ------------------------------------------------------------------------------------------------------------------ ---->

        <div class="row row-cols-1 row-cols-md-3 g-4 mt-3">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col">
                        <div class="card" style="width: 18rem;">
                            <div class="card-body">
                                <img src="<%# ((Articulo)Container.DataItem).imagenes[0]?.Url %>" class="card-img-top" onerror="this.onerror=null;this.src='<%: invalidUrl %>';" alt="...">
                                <h5 class="card-title"><%# Eval("nombre") %></h5>
                                <p class="card-text"><%# Eval("descripcion") %></p>
                                <p class="card-text"><%# Eval("precio") %></p>
                                <asp:Button runat="server" ID="btnDetalles" Text="Detalles" CssClass="btn btn-primary" OnClick="btnDetalles_Click" CommandArgument='<%# Eval("id") %>' />
                                <asp:Button runat="server" ID="btnAgregarCarrito" Text="Agregar al Carrito" CssClass="btn btn-primary" OnClick="btnAgregarCarrito_Click" CommandArgument='<%# Eval("id") %>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <!--  -----  MODAL DEL AGREGAR CARRITO :d ---->

        <div class="modal fade" id="successModal" tabindex="-1" aria-labelledby="successModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="successModalLabel">Artículo Agregado</h5>
                        <button type="button" class=" btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        El artículo ha sido agregado al carrito exitosamente.
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary " data-bs-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
        <!--  ------------------------------------- -->

    </main>



    <script>
        // Siempre que ya se haya cargado la pagina alli recien es cuando aplicamos el script / filtros.
        document.addEventListener("DOMContentLoaded", function () {
            var txtBuscar = document.getElementById("<%= txtBuscar.ClientID %>");
            var btnBuscar = document.getElementById("btnBuscar");
            var hiddenBtnBuscar = document.getElementById("<%= hiddenBtnBuscar.ClientID %>");

            // evaluamos el imput del txtBuscar y si esta vacio redirigimos a la pagina principal
            txtBuscar.addEventListener("input", function () {
                if (txtBuscar.value.trim() === "") {
                    window.location.href = window.location.pathname;
                }
            });

            //Cuando se hace click en el botton buscar se hace un postback con el boton hiddenBtnBuscar 
            //hice esto porque Asp no me permitia agregar personalizacion al boton por defecto :( entonces lo oculte y lo manejo con js
            btnBuscar.addEventListener("click", function () {

                __doPostBack('<%= hiddenBtnBuscar.UniqueID %>', '');
            });

        });

        // esta funcion abre la modal cuando es llamada desde el codebehind
        function abirModalArticuloAgregado() {
            var myModal = new bootstrap.Modal(document.getElementById('successModal'), {
                keyboard: false
            });
            myModal.show();


        }


    </script>
</asp:Content>


