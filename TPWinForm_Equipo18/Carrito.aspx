<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWinForm_Equipo18.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
    
    
    <main aria-labelledby="title">

        
       <div style="display: flex; align-items: center;">
            <h2 id="title" style="margin-right: 10px;"><%: Title %></h2>
            <asp:Label ID="listaCount" runat="server" Text=""></asp:Label>
       </div>
        <a href="ListadoArticulos">
            <asp:Label ID="lblSeguirComprando" runat="server" Text=""></asp:Label>
        </a>

        <div >
            <asp:GridView ShowHeader="false" ID="dgvArticulos" class="container text-center" CssClass="table table-dark align-baseline" runat="server" AutoGenerateColumns="false" HeaderStyle-Wrap="True">
                <Columns>

                     
                     <asp:TemplateField HeaderText="">
                         <ItemTemplate>
                             <asp:Button ID="btnIzquierda"  runat="server" Text="<<" CommandName="deslizarIzquierda" CommandArgument='<%# Eval("ID") %>' />
                         </ItemTemplate>
                    </asp:TemplateField>

                   
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
               
                            <asp:Image runat="server" ImageUrl='<%# Eval("imagenes[0].Url") %>' Alt="Imagen de artículo" Width="150px" Height="150px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="">
                         <ItemTemplate>
                             <asp:Button ID="btnDerecha" runat="server" Text=">>" CommandName="deslizarDerecha" CommandArgument='<%# Eval("ID") %>' />
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:BoundField HeaderText="" DataField="nombre" />
                     <asp:BoundField HeaderText="" DataField="precio" />

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                             <asp:Button ID="btnRestar" runat="server" Text="-" CommandName="restarArticulo" CommandArgument='<%# Eval("ID") %>' />
                         </ItemTemplate>
                     </asp:TemplateField>




                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button CssClass="btn-success rounded-5" ID="btnSumar" runat="server" Text="+" CommandName="sumarArticulo" CommandArgument='<%# Eval("ID") %>' />
                         </ItemTemplate>
                    </asp:TemplateField>


           
                </Columns>
            </asp:GridView>




        </div>
            <address>
            
            
            <br />


        </address>

        <address>
            

        </address>
    </main>
</asp:Content>
