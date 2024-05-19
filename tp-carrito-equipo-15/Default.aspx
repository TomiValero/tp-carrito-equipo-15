<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_carrito_equipo_15.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://http2.mlstatic.com/D_NQ_688120-MLA76025194258_052024-OO.webp" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://http2.mlstatic.com/D_NQ_946704-MLA76296870887_052024-OO.webp" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://http2.mlstatic.com/D_NQ_732245-MLA76247333205_052024-OO.webp" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://http2.mlstatic.com/D_NQ_606738-MLA76267875949_052024-OO.webp" class="d-block w-100" alt="...">
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
    <div class="row row-cols-1 row-cols-md-4 g-4 m-5 mx-auto w-75">
        <% foreach(dominio.Articulo articulo in listaArticulos) { %>
        <div class="col">
            <div class="card h-100">
                <asp:Image class="card-img-top" runat="server" id="imagenArticulo" alt="..."/>
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                    <p class="card-text"><%: articulo.Descripcion %></p>
                </div>
                <button type="button" class="btn btn-primary w-50 mx-auto">
                    <a href="Detalles.aspx?id=<%: articulo.Id %>" class="btn btn-primary w-100">Ver detalle</a>
                </button>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
