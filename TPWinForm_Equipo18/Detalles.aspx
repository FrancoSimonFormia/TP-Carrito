<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="TPWinForm_Equipo18.About" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Detalles.css" rel="stylesheet" />

    <main aria-labelledby="title">

        <section class="product">
            <div class="product__images">

                <div class="carousel slide" id="carouselDemo" data-bs-wrap="false">
                    <div class="carousel-inner">
                  <% for (int i = 0; i < seleccion.imagenes.Count; i++)
                      { %>
                        <div class="carousel-item active">
                            <img src="<%: seleccion.imagenes[i] %>" class="w-100" alt="">
                        </div>
                   <% } %>
                    </div>

                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselDemo" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon"></span>
                    </button>

                    <button class="carousel-control-next" type="button" data-bs-target="#carouselDemo" data-bs-slide="next">
                        <span class="carousel-control-next-icon"></span>
                    </button>

                    <div class="carousel-indicators">
                  <% for (int i = 0; i < seleccion.imagenes.Count; i++)
                      {  %>
                        <button type="button" class="active" data-bs-target="#carouselDemo" data-bs-slide-to= "<%: i.ToString() %>" >
                            <img src="<%: seleccion.imagenes[i] %>" class="w-100" alt="">
                        </button>
                   <% } %>
                    </div>
                </div>

            </div>
            <div class="product__info">
                <h2><%: seleccion.nombre %></h2>
                <span> <%: seleccion.codigo %> </span>
                <p><%: seleccion.descripcion %></p>
                <span>$<%: seleccion.precio %></span>

                <div class="product__filters">
                    <span>Marca: <%: seleccion.marcaArticulo.ToString() %></span>
                </div>
                <div class="product__filters">
                    <span>Categoría: <%: seleccion.categoriaArticulo.ToString() %></span>
                </div>

                <asp:Button Text="Agregar" CssClass="btn btn-success" ID="btnAgregar" runat="server" OnClick="btnAgregar_Click"/>

            </div>
        </section>



    </main>
</asp:Content>
