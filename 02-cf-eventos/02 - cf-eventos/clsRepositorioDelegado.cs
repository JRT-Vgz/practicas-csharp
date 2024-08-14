using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___cf_eventos
{
    public class clsRepositorioDelegado
    {
        public delegate void AvisaLinea(int valor);

        #region Propiedades
        #endregion

        #region Eventos
        public event AvisaLinea ReportaAvance;
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        public void ObtenTodos()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(250);
                ReportaAvance(i + 1);
            }
        }
        #endregion
    }
}
