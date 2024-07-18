using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libPedidos
{
    internal static class CalculoPrecios
    {
        #region Propiedades
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        internal static decimal DesglosaImpuestos(decimal precio, recImpuestos PorcentajesImpuestos,
                                        recMontosImpuestos Montos)
        {
            decimal resultado = 0;
            resultado = precio / (1 + PorcentajesImpuestos.PorcentajeIva / 100m);
            Montos.MontoIva = Math.Round(resultado * (PorcentajesImpuestos.PorcentajeIva / 100m), 2);
            resultado = resultado / (1 + PorcentajesImpuestos.PorcentajeIeps / 100m);
            Montos.MontoIeps = Math.Round(resultado * (PorcentajesImpuestos.PorcentajeIeps / 100m), 2);
            return Math.Round(resultado, 2);
        }
        #endregion
    }
}
