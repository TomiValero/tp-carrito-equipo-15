using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_carrito_equipo_15
{
    public partial class Carrito : System.Web.UI.Page
    {

        public string auxCant;

        public int CantidadActualArticulos { get; set; }
        public SqlMoney TotalPagoArticulos = 0;
        List<ArticuloCarrito> listaArticulosSeleccionados = new List<ArticuloCarrito>();

        private bool ComprobarDato(ArticuloCarrito a, int c, SqlMoney precio)
        {
            foreach (ArticuloCarrito item in listaArticulosSeleccionados)
            {
                if (item.Id == a.Id)
                {
                    item.Cant += c;
                    item.Precio = item.Cant * precio;
                    return true;
                }
            }
            return false;
        }



        protected void Page_Load(object sender, EventArgs e)
        {


            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo auxArticulo = new Articulo();
            ArticuloCarrito auxArtcart = new ArticuloCarrito();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<string> Img;
            int ID = 0;
            int Cant = 0;




            SqlMoney precioTotalXArticulo = 0;


            if (Session["cant"] != null)
            {
                Cant = (int)Session["cant"];
            }



            if (Cant != -1 && Cant != 0)
            {
                Cant = (int)Session["cant"];
                ID = (int)Session["idArt"];


                auxArticulo = articuloNegocio.BuscarPorId(ID);
                Img = imagenNegocio.Imagenes(auxArticulo);

                auxArtcart.Id = auxArticulo.Id;
                auxArtcart.Cant = Cant;
                auxArtcart.Titulo = auxArticulo.Nombre;
                auxArtcart.Precio = auxArticulo.Precio * Cant;
                auxArtcart.Img = Img[0];
                Session["cant"] = -1;
                Session["idArt"] = -1;

                if (Session["listaArticulos"] != null)
                {
                    listaArticulosSeleccionados = (List<ArticuloCarrito>)Session["listaArticulos"];
                    if (!(ComprobarDato(auxArtcart, Cant, auxArticulo.Precio)))
                    {

                        listaArticulosSeleccionados.Add(auxArtcart);
                    }
                }
                else
                {

                    if (!(ComprobarDato(auxArtcart, Cant, auxArticulo.Precio)))
                    {
                        listaArticulosSeleccionados.Add(auxArtcart);
                    }
                    Session.Add("listaArticulos", listaArticulosSeleccionados);
                }

                Session["listaArticulos"] = listaArticulosSeleccionados;



            }
            else
            {
                if (Session["listaArticulos"] != null)
                {
                    listaArticulosSeleccionados = (List<ArticuloCarrito>)Session["listaArticulos"];

                }
                else
                {

                    Session.Add("listaArticulos", listaArticulosSeleccionados);
                }

                Session["listaArticulos"] = listaArticulosSeleccionados;
            }



            TotalPagoArticulos = TotalProductosPrecio();

            Session["TotalPagoArticulos"] = TotalPagoArticulos;

            Session["cantArt"] = TotalProductos();


            if (!IsPostBack)
            {
                if (listaArticulosSeleccionados != null)
                {
                    repetidor1.DataSource = listaArticulosSeleccionados;
                    repetidor1.DataBind();
                }

            }

        }


        private int TotalProductos()
        {
            int total = 0;
            foreach (ArticuloCarrito item in listaArticulosSeleccionados)
            {
                total += item.Cant;
            }
            return total;
        }

        private SqlMoney TotalProductosPrecio()
        {
            SqlMoney total = 0;
            foreach (ArticuloCarrito item in listaArticulosSeleccionados)
            {
                total += (SqlMoney)item.Precio;
            }
            return total;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            int id = int.Parse(((Button)sender).CommandArgument);
            ArticuloCarrito seleccionado = listaArticulosSeleccionados.Find(x => x.Id == id);

            listaArticulosSeleccionados.Remove(seleccionado);

            Session["listaArticulos"] = listaArticulosSeleccionados;

            Session["cant"] = -1;
            Session["idArt"] = -1;
            Response.Redirect("Carrito.aspx", false);
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {

            Articulo auxArticulo = new Articulo();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            int id = int.Parse(((Button)sender).CommandArgument);
            ArticuloCarrito seleccionado = listaArticulosSeleccionados.Find(x => x.Id == id);


            auxArticulo = articuloNegocio.BuscarPorId(id);

            seleccionado.Cant++;

            seleccionado.Precio = auxArticulo.Precio * seleccionado.Cant;



            Session["listaArticulos"] = listaArticulosSeleccionados;

            Session["cant"] = -1;
            Session["idArt"] = -1;
            Response.Redirect("Carrito.aspx", false);
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            Articulo auxArticulo = new Articulo();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            int id = int.Parse(((Button)sender).CommandArgument);
            ArticuloCarrito seleccionado = listaArticulosSeleccionados.Find(x => x.Id == id);

            if (seleccionado.Cant > 1)
            {
                auxArticulo = articuloNegocio.BuscarPorId(id);

                seleccionado.Cant--;

                seleccionado.Precio = auxArticulo.Precio * seleccionado.Cant;

            }

            Session["listaArticulos"] = listaArticulosSeleccionados;

            Session["cant"] = -1;
            Session["idArt"] = -1;
            Response.Redirect("Carrito.aspx", false);
        }
    }
}
