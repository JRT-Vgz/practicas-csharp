using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libPedidos
{
    public class clsRepositorioMemProductos: intRepositorioProductos
    {
        #region Propiedades
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        public Dictionary<string, recProductos> ObtenTodos()
        {
            Dictionary<string, recProductos> Productos = new Dictionary<string, recProductos>();
            Productos.Add("00001", new recProductos(1, "Refresco de manzana", "00001"));
            Productos.Add("00002", new recProductos(2, "Refresco de pomelo", "00002"));
            Productos.Add("00003", new recProductos(3, "Refresco de naranja", "00003"));
            Productos.Add("00004", new recProductos(4, "Refresco de limon", "00004"));
            Productos.Add("00005", new recProductos(5, "Refresco de fresa", "00005"));
            return Productos;
        }
        #endregion
    }
}
