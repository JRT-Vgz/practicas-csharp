using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libPedidos
{
    public class clsPersonas
    {
        #region Propiedades
        private int _idPersona;
        private string _NombreCompleto;

        protected int IdPersona
        {
            get => _idPersona;
            set => _idPersona = value;
        }
        public string NombreCompleto
        {
            get => _NombreCompleto;
            set => _NombreCompleto = value;
        }
        #endregion

        #region Constructor
        public clsPersonas()
        {
            _idPersona = 0;
            _NombreCompleto = String.Empty;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
