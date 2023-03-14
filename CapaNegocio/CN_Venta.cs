using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Venta
    {

        private CD_Venta objcd_Venta = new CD_Venta();

        public bool RestarStock(int idproducto, int cantidad){
            return objcd_Venta.RestarStock(idproducto, cantidad);
        }

        public bool SumarStock(int idproducto, int cantidad)
        {
            return objcd_Venta.SumarStock(idproducto, cantidad);
        }

        public int ObtenerCorrelativo()
        {
            return objcd_Venta.ObtenerCorrelativo();
        }
        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            return objcd_Venta.Registrar(obj, DetalleVenta, out Mensaje);
        }

        public Venta ObtenerVenta(string numero) {
            Venta oVenta = objcd_Venta.ObtenerVenta(numero);

            if (oVenta.IdVenta != 0){
                List<Detalle_Venta> oDetalleVenta = objcd_Venta.ObtenerDetallVenta(oVenta.IdVenta);
                oVenta.oDetalle_Venta = oDetalleVenta;
            }
            return oVenta;
        }
    }
}
