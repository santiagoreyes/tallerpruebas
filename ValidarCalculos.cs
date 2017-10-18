using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace WcfTallerAutomatizacionCasosPrueba
{
    public class ValidarCalculos
    {
        public ResultadoValidaciones validar(string mensajeXml, ResultadoValidaciones resultadoValidaciones)
        {
            XPathDocument document = new XPathDocument(XmlReader.Create(new StringReader(mensajeXml)));

            XPathNavigator navigator = document.CreateNavigator();
            try
            {
                string categoria = navigator.SelectSingleNode("/notaVenta/categoria").Value;
                Double monto = Double.Parse(navigator.SelectSingleNode("/notaVenta/monto").Value);
                Double porcentajeImpuesto = Double.Parse(navigator.SelectSingleNode("/notaVenta/porcentajeImpuesto").Value);
                Double total = Double.Parse(navigator.SelectSingleNode("/notaVenta/total").Value);
                if (categoria == "VIVERES" && porcentajeImpuesto != 0) {
                    resultadoValidaciones.agregarEvento(new EventoValidacion { error = "Tasa no aplica a " + categoria, accion = "Corregir" });
                }
                if (categoria == "LICORES" && porcentajeImpuesto != 10)
                {
                    resultadoValidaciones.agregarEvento(new EventoValidacion { error = "Tasa no aplica a " + categoria, accion = "Corregir" });
                }
                if (categoria == "LIMPIEZA" && porcentajeImpuesto != 7)
                {
                    resultadoValidaciones.agregarEvento(new EventoValidacion { error = "Tasa no aplica a " + categoria, accion = "Corregir" });
                }
                Double totalCalculado = monto +(monto*porcentajeImpuesto/100);
                if (totalCalculado != total) { 
                    resultadoValidaciones.agregarEvento(
                        new EventoValidacion { 
                            error = "Total no cuadra con monto por impuesto (calculado: " + totalCalculado + " total: " + total , 
                            accion = "Corregir total" });
                }

            }
            catch (Exception ex) {
                resultadoValidaciones.agregarEvento(new EventoValidacion { error = "No se pudo evaluar los calculos" + ex.Message, accion = "Revisar" });
            }
            return resultadoValidaciones;
        }
    }
}
