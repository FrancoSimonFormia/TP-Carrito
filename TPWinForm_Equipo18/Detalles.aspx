<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="TPWinForm_Equipo18.About" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Detalles.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.11.2/css/all.css" rel="stylesheet" />

    <main aria-labelledby="title">

        <section class="product">
            <div class="product__images">

                <div class="carousel slide" id="carouselDemo" data-bs-wrap="false">
                    <div class="carousel-inner">
                        <% for (int i = 0; i < seleccion.imagenes.Count; i++)
                            { %>
                        <div class="carousel-item active">
                            <img src="<%: seleccion.imagenes[i] %>" onerror="this.onerror=null;this.src='<%: invalidUrl %>';" class="w-100" alt="">
                        </div>
                        <% } %>
                    </div>


                    <a class="carousel-control-prev" href="#carouselDemo" role="button" data-bs-slide="prev">
                        <span><i class="fa fa-angle-left fa-2x" aria-hidden="true" style="color: #6c757d"></i></span>
                    </a>

                    <a class="carousel-control-next" href="#carouselDemo" role="button" data-bs-slide="next">
                        <span><i class="fa fa-angle-right fa-2x" aria-hidden="true" style="color: #6c757d"></i></span>
                    </a>

                   <!-- <button class="carousel-control-prev" type="button" data-bs-target="#carouselDemo" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon"></span>
                    </button>

                    <button class="carousel-control-next" type="button" data-bs-target="#carouselDemo" data-bs-slide="next">
                        <span class="carousel-control-next-icon"></span>
                    </button>
                    !-->
                    <div class="carousel-indicators">
                        <% for (int i = 0; i < seleccion.imagenes.Count; i++)
                            {  %>
                        <button type="button" class="active" data-bs-target="#carouselDemo" data-bs-slide-to="<%: i.ToString() %>">
                            <img src="<%: seleccion.imagenes[i] %>" onerror="this.onerror=null;this.src='<%: invalidUrl %>';" class="w-100" alt="">
                        </button>
                        <% } %>
                    </div>
                </div>

            </div>
            <div class="product__info col">
                <h2><%: seleccion.nombre %></h2>
                <span><%: seleccion.codigo %> </span>
                <p><%: seleccion.descripcion %></p>
                <span>$<%: seleccion.precio %></span>

                <div class="product__filters">
                    <span>Marca: <%: seleccion.marcaArticulo.ToString() %></span>
                </div>
                <div class="product__filters">
                    <span>Categoría: <%: seleccion.categoriaArticulo.ToString() %></span>
                </div>

                <div class="col-md-5">
                    <div class="input-group number-spinner">
                        <asp:LinkButton ID="btnRestar" runat="server" CssClass="btn btn-default" OnClientClick="substract(); return false;"><i class="fas fa-minus"></i>&nbsp;</asp:LinkButton>
                        <!--<button id="case-minus" class="btn btn-default"><i class="fas fa-minus"></i></button> !-->
                        <asp:TextBox runat="server" ReadOnly="true" ID="txtCantidad" CssClass="form-control text-center" type="number" min="1" />
                        <asp:HiddenField runat="server" ID="auxCantidad" />
                        <asp:LinkButton ID="btnSumar" runat="server" CssClass="btn btn-default" OnClientClick="add(); return false;"><i class="fas fa-plus"></i>&nbsp;</asp:LinkButton>
                        <!--<button  id="case-plus" class="btn btn-default"><i class="fas fa-plus"></i></button> !-->
                    </div>
                    <div class="buttons">
                        <asp:Button Text="Agregar" CssClass="btn btn-success" ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" />
                        <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="btnCancelar" OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </div>
        </section>


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




    </main>

    <script>
        function add() {

            const txtCantidad = document.getElementById('<%: txtCantidad.ClientID %>');
            const auxCantidad = document.getElementById('<%: auxCantidad.ClientID %>');
            let cantidad = parseInt(txtCantidad.value);
            cantidad = cantidad + 1;
            txtCantidad.value = cantidad;
            auxCantidad.value = cantidad;

            console.log("Estuve aquí")

            return false;
        }

        function substract() {
            const txtCantidad = document.getElementById('<%: txtCantidad.ClientID %>');
            const auxCantidad = document.getElementById('<%: auxCantidad.ClientID %>');
            let cantidad = parseInt(txtCantidad.value);

            if (cantidad > 1) {
                cantidad = cantidad - 1;
            }

            txtCantidad.value = cantidad;
            auxCantidad.value = cantidad;

            console.log("Estuve aquí")

            return false;
        }

        // esta funcion abre la modal cuando es llamada desde el codebehind
        function abirModalArticuloAgregado() {
            var myModal = new bootstrap.Modal(document.getElementById('successModal'), {
                keyboard: false
            });
            myModal.show();


        }

    </script>
</asp:Content>
