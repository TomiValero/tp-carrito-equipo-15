<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="tp_carrito_equipo_15.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="margin-top: 50px;">
        <div class="row">
            <div class="col">

                <div class="card w-75 m-3">
                    <div class="card-body" style="position: relative;">
                        <%--<img src="" alt="Alternate Text" width="100" height="100" style="float: left;" />--%>
                        <h5 class="card-title"></h5>
                        <asp:Button runat="server" ID="btnDisminuirCantidad" Text="<" />
                        <asp:Label ID="lblNumerador" Text="1" runat="server" />
                        <asp:Button runat="server" ID="btnAumentarCantidad" Text=">" />
                        <label id="lblPrecio"></label>
                        <asp:Button ID="btnEliminarDeCarrito" class="btn-close" Style="position: absolute; top: 0; right: 0;" aria-label="Close" runat="server" />
                    </div>
                </div>
                <div class="card w-75 m-3" >
                    <div class="card-body" style="position: relative;">
                        <%--<img src="" alt="Alternate Text" width="100" height="100" style="float: left;" />--%>
                        <h5 class="card-title"></h5>
                        <asp:Button runat="server" ID="Button1" Text="<" />
                        <asp:Label ID="Label1" Text="1" runat="server" />
                        <asp:Button runat="server" ID="Button2" Text=">" />
                        <label id="lblPrecio"></label>
                        <asp:Button ID="Button3" class="btn-close" Style="position: absolute; top: 0; right: 0;" aria-label="Close" runat="server" />
                    </div>
                </div>

            </div>
            <div class="col" style="max-width: 30%;">
                <div class="card" style="width: 18rem;">
                    <div class="card-body" style="display: flex; flex-direction: column; align-items: start; gap: 10px;">
                        <h5 class="card-title">Resumen</h5>
                        <a href="" class="btn btn-primary">Continuar Compra</a>
                        <label id="lblcantidadProductos">cantidadproductos</label>
                        <h5 class="card-title">Total</h5>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--  --%>
</asp:Content>
