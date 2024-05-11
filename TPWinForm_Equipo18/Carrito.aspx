<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWinForm_Equipo18.Contact" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="estilosCarrito.css">
    <main aria-labelledby="title">

       <div style="display: flex; align-items: center;">
            <h2 id="title" style="margin-right: 10px;"><%: Title %></h2>
            <asp:Label ID="listaCount" runat="server" Text=""></asp:Label>
       </div>

        <a href="ListadoArticulos">
            <asp:Label ID="lblSeguirComprando" runat="server" Text=""></asp:Label>
        </a>

        
                <asp:GridView ID="GridCarrito" runat="server" AutoGenerateColumns="false" CssClass="table align-baseline w-75 border-0" >
                    <Columns>
                        <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Image runat="server" ImageUrl='<%# Eval("imagenes[0].Url") %>' Alt="Imagen de artículo" Width="150px" Height="150px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                        <asp:BoundField HeaderText="" DataField="nombre" />
                        <asp:BoundField HeaderText="" DataField="precio" />

                         <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button CssClass="btn btn-danger rounded-5" ID="btnRestar" runat="server" Text="-" CommandName="RestarArticulo" CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button CssClass="btn btn-success rounded-5" ID="btnSumar" runat="server" Text="+" CommandName="sumarArticulo" CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="b.png" CommandName="sumarArticulo" CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                    </Columns>
                </asp:GridView>
                


        <div class="ContenedorCompra">
            <div class="tarjetaCompra">
                <div>
                    <label class="lblCompra1">Subtotal:</label>
                    <asp:Label ID="lblsubtot" runat="server" Text="Label"></asp:Label>
                </div>
                <div>
                    <label class="lblCompra1">Costo de envío:</label>
                    <asp:Label ID="lblenvio" runat="server" Text="Label"></asp:Label>
                </div>
                <div>
                    <label class="lblCompra1">Total:</label>
                    <asp:Label ID="lbltotal" runat="server" Text="Label"></asp:Label>
                </div>
                <div>
                    <asp:Button CssClass="btn btn-primary btn-lg" ID="btnCompra" runat="server" Text="Ir a comprar" />
                </div>
            </div>
        </div>

         <address>           
            <br />
        </address>
    </main>
</asp:Content>
