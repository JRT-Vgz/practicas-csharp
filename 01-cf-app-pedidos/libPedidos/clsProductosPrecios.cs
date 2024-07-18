using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace libPedidos
{
    public class clsProductosPrecios : clsProductos
    {
        #region Propiedades
        public decimal PrecioPublico { get; set; }
        public decimal PrecioMayoreo { get; set; }
        public decimal PorcentajeIva { get; set; }
        public decimal PorcentajeIeps { get; set; }
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        public override string ToString()
        {
            string cadena = base.ToString() + $". PrecioPublico: {PrecioPublico}, PrecioMayoreo: {PrecioMayoreo}, PorcenajeIva: {PorcentajeIva}, PorcentajeIeps: {PorcentajeIeps}";
            return cadena;
        }

        public decimal DesglosaImpuestos(recMontosImpuestos Montos)
        {
            decimal resultado = 0;
            recImpuestos Impuestos = new recImpuestos(PorcentajeIva, PorcentajeIeps);
            resultado = CalculoPrecios.DesglosaImpuestos(PrecioPublico, Impuestos,
                                                    Montos);
            return resultado;
        }
        #endregion
    }
}
