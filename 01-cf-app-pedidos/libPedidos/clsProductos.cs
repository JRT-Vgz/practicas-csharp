using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libPedidos
{
    public class clsProductos
    {
        #region Propiedades
        public int idProducto { get; set; }
        public string Descripcion { get; set; }
        public string CodigoBarras { get; set; }
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        public override string ToString()
        {
            string cadena = $"idProducto: {idProducto}, Descripcion: {Descripcion}, CodigoBarras: {CodigoBarras}";
            return cadena;
        }
        #endregion
    }
}