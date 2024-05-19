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

        public List<string> Img;
        public int CantidadActualArticulos { get; set; }
        public SqlMoney TotalPagoArticulos = 0;
        public int Cant = 0;
        List<Articulo> listaArticulosSeleccionados = new List<Articulo>();

        private bool ComprobarDato(Articulo a, List<Articulo> lista)
        {
            foreach (Articulo item in lista)
            {
                if (item.Id == a.Id)
                {
                    return true;
                }
            }
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo auxArticulo = new Articulo();
            ImagenNegocio imagenNegocio = new ImagenNegocio();


            int ID = 0;
            SqlMoney precioTotalXArticulo = 0;
            if (Request.QueryString["ID"] != null && Request.QueryString["Cant"] != null)
            {
                ID = int.Parse(Request.QueryString["ID"]);
                Cant = int.Parse(Request.QueryString["Cant"]);
                CantidadActualArticulos += Cant;
                auxArticulo = articuloNegocio.BuscarPorId(ID);
                Session["cantArt"] = CantidadActualArticulos; //Session.Add("cantArt", CantidadActualArticulos); Session.Add("cantArt", CantidadActualArticulos); Session.Add("cantArt", CantidadActualArticulos); Session.Add("cantArt"], CantidadActualArticulos);
                if (auxArticulo != null)
                {
                    {
                        if (Session["listaArticulos"] != null)
                        {
                            listaArticulosSeleccionados = (List<Articulo>)Session["listaArticulos"];
                            if (!ComprobarDato(auxArticulo, listaArticulosSeleccionados))
                            {
                                listaArticulosSeleccionados.Add(auxArticulo);
                                Session["listaArticulos"] = listaArticulosSeleccionados;
                            }
                        }
                        else
                        {
                            if (!ComprobarDato(auxArticulo, listaArticulosSeleccionados))
                            {

                                listaArticulosSeleccionados.Add(auxArticulo);
                                Session.Add("listaArticulos", listaArticulosSeleccionados);
                            }
                        }
                        Img = imagenNegocio.Imagenes(auxArticulo);
                    }
                }
                CantidadActualArticulos += (int)Session["cantArt"];
                precioTotalXArticulo = Cant * auxArticulo.Precio;
            }

            TotalPagoArticulos = precioTotalXArticulo;

            Session.Add("CantidadArticulos", CantidadActualArticulos);
            Session.Add("TotalPagoArticulos", TotalPagoArticulos);


            if (!IsPostBack)
            {
                if (listaArticulosSeleccionados != null)
                {
                    repetidor1.DataSource = (List<Articulo>)Session["listaArticulos"];
                    repetidor1.DataBind();
                }

            }





        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo auxArticulo = new Articulo();
            int id = int.Parse(((Button)sender).CommandArgument);

            if (id != 0 && Cant > 0)
            {
                auxArticulo = articuloNegocio.BuscarPorId(id);

                if (auxArticulo != null)
                {
                    Cant--;
                    CantidadActualArticulos--;
                    Session["cantArt"] = CantidadActualArticulos;
                    Response.Redirect("Carrito.aspx?Id=" + id + "&Cant=" + Cant, false);
                    //CantidadActualArticulos -= 1;
                    TotalPagoArticulos = (int)Session["cantArt"] * auxArticulo.Precio;
                }
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo auxArticulo = new Articulo();
            int id = int.Parse(((Button)sender).CommandArgument);

            if (id != 0)
            {
                auxArticulo = articuloNegocio.BuscarPorId(id);
                if (auxArticulo != null)
                {
                    Cant++;
                    CantidadActualArticulos--;
                    Session["cantArt"] = CantidadActualArticulos;
                    Response.Redirect("Carrito.aspx?Id=" + id + "&Cant=" + Cant, false);//CantidadActualArticulos += 1;
                    TotalPagoArticulos = (int)Session["cantArt"] * auxArticulo.Precio;
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo auxArticulo = new Articulo();
            int id = int.Parse(((Button)sender).CommandArgument);
            if (id != 0)
            {

                auxArticulo = articuloNegocio.BuscarPorId(id);

                if (auxArticulo != null)
                {

                    CantidadActualArticulos -= Cant;
                    Session["cantArt"] = Cant;
                    listaArticulosSeleccionados.Remove(auxArticulo);

                    Response.Redirect("Carrito.aspx?", false);
                }
            }
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {

        }
    }
}
}