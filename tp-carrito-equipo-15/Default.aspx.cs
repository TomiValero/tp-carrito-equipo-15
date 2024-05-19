using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace tp_carrito_equipo_15 {
    public partial class Default : System.Web.UI.Page {
        public List<Articulo> listaArticulos;
        protected void Page_Load(object sender, EventArgs e) {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            listaArticulos = articuloNegocio.listar();
        }
    }
}