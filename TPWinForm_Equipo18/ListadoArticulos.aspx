<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="TPWinForm_Equipo18.ListadoArticulos" EnableEventValidation="false" %>

<%@ Import Namespace="dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">

        <asp:TextBox ID="txtBuscar" runat="server" AutoPostBack="false"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />


        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col">
                        <div class="card" style="width: 18rem;">
                            <div class="card-body">
                                <img src="<%# ((Articulo)Container.DataItem).imagenes[0]?.Url %>" class="card-img-top" alt="...">
                                <h5 class="card-title"><%# Eval("nombre") %></h5>
                                <p class="card-text"><%# Eval("descripcion") %></p>
                                <p class="card-text"><%# Eval("id") %></p>
                                <asp:Button runat="server" ID="btnDetalles" Text="Detalles" CssClass="btn btn-primary" OnClick="btnDetalles_Click" CommandArgument='<%# Eval("id") %>' />
                                <asp:Button runat="server" ID="btnAgregarCarrito" Text="Agregar al Carrito" CssClass="btn btn-primary" OnClick="btnAgregarCarrito_Click" CommandArgument='<%# Eval("id") %>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </main>

    <script>
        // Espera a que el DOM esté cargado
        document.addEventListener("DOMContentLoaded", function () {
            // Obtén la caja de texto por su ID
            var txtBuscar = document.getElementById("<%= txtBuscar.ClientID %>");

        // Agrega un event listener para el evento input
        txtBuscar.addEventListener("input", function () {
            // Si la caja de texto está vacía, recarga la página sin aplicar filtro
            if (txtBuscar.value.trim() === "") {
                window.location.href = window.location.pathname;
            }
        });
    });
    </script>


</asp:Content>


