<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="tp_carrito_equipo_15.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin:20px" >

    <div Class="col-sm-7 rounded"> 

      <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">

          <div class="carousel-inner">
              <div class="carousel-item active">
                  <asp:Image ID="Imagen" runat="server" CssClass="d-block w-100" style="width:400px; margin:20px; height:400px;"/>
              </div>
          </div>

          <asp:LinkButton ID="BtnAnterior" runat="server" CssClass="carousel-control-prev">
              <span class="carousel-control-prev-icon" aria-hidden="true"></span>
          </asp:LinkButton>
           <asp:LinkButton ID="BtnProxima" runat="server" CssClass="carousel-control-next">
               <span class="carousel-control-next-icon" aria-hidden="true"></span>
          </asp:LinkButton>

      </div>

    </div>

  <div class="col-sm" style="margin:20px">
      <h2 class="h2">Titulo del Producto</h2>
      <h3 class="h3">$10000</h3>

      <div style="margin:5px;">
          <span class="badge badge-primary bg-black">Marca</span>
          <span class="badge badge-primary bg-black">Categoria</span>
          <span class="badge badge-primary bg-black">Codigo</span>
      </div>
      
      <p class="lead">Traditional heading elements are designed to work best in the meat of your page content. When you need a heading to stand out, consider using a display heading—a larger, slightly more opinionated heading style.
      </p>
      <div>
          <asp:Label ID="LblCantidad" runat="server" Text="Cantidad:" ></asp:Label>
      </div>
      <div style="margin-bottom:10px">  
          <asp:TextBox ID="TxtCantidad" runat="server" TextMode="Number" CssClass="custom-select" />
      </div>
      <asp:Button ID="BtnAgregar" runat="server" Text="Agregar al Carrito" CssClass="btn btn-secondary btn-lg btn-block bg-black" />     
  </div>


  </div>

</asp:Content>
