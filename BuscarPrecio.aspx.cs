using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfTallerAutomatizacionCasosPrueba
{
    public partial class Calcular : System.Web.UI.Page
    {

        private string tiempoEsperaPar = System.Configuration.ConfigurationManager.AppSettings["tiempoEspera"];
        private int tiempoEspera = 0;
        Dictionary<string, double> lista = new Dictionary<string, double>{
{"pan",0.82},
{"leche",0.44},
{"huevos",0.18},
{"harina",0.42},
{"azucar",0.54},
{"sal",0.66},
{"yogurth",0.26},


        };
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32.TryParse(tiempoEsperaPar, out tiempoEspera);
            lblRespuesta.Text = "";
            lblTiempo.Text = "";
            lblPrecioEs.Visible = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            int waitTime = tiempoEspera > 0 ? tiempoEspera*(new Random().Next(1000)): new Random().Next(200);
            System.Threading.Thread.Sleep(waitTime);
            //simular tarea intensiva
            if (tiempoEspera > 0) Util.FindPrimeNumber(waitTime * 20);

            if (tbxProducto.Text == "") lblRespuesta.Text = "Debe ingresar un valor";
            string producto = tbxProducto.Text;
            if (!lista.ContainsKey(producto))
            {
                lblRespuesta.Text = "No tenemos este producto.";
                lblPrecioEs.Visible = false;
            }
            else {
                double precio = lista[producto];
                lblPrecioEs.Visible = true;
                lblRespuesta.Text = precio.ToString();
            }
            lblTiempo.Text = " Tiempo de búsqueda: ( " + waitTime.ToString() + " ) ms.";
            
        }
    }
}