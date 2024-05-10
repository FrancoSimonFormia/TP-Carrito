<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="TPWinForm_Equipo18.ListadoArticulos" %>

<%@ Import Namespace="dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">
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
                        <asp:Button runat="server" ID="btnDetalles" Text="Detalles" CssClass="btn btn-primary" OnClick="btnDetalles_Click" />
                        <asp:Button runat="server" ID="btnAgregarCarrito" Text="Agregar al Carrito" CssClass="btn btn-primary" OnClick="btnAgregarCarrito_Click" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
    </main>

</asp:Content>


