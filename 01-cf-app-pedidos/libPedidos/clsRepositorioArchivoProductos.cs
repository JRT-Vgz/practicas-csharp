using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace libPedidos
{
    public class clsRepositorioArchivoProductos : intRepositorioProductos
    {
        #region Propiedades
        public string NombreArchivo { get; set; }
        #endregion

        #region Constructor
        public clsRepositorioArchivoProductos(string nombreArchivo)
        {
            NombreArchivo = nombreArchivo;
        }
        #endregion

        #region Metodos
        public Dictionary<string, recProductos> ObtenTodos()
        {
            TextReader txtReader;
            string linea;
            Dictionary<string, recProductos> Productos = new Dictionary<string, recProductos>();
            if (File.Exists(NombreArchivo))
            {
                using (txtReader = new StreamReader(NombreArchivo))
                {
                    do
                    {
                        linea = txtReader.ReadLine();
                        if (linea != null)
                        {
                            string[] campos = linea.Split(',');
                            Productos.Add(campos[2], new recProductos(Convert.ToInt32(campos[0]), campos[1], campos[2]));
                        }
                    } while (linea != null);
                }
                txtReader.Close();
            }
            return Productos;
        }
        #endregion
    }
}
