using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ApplicationLayer.Exceptions
{
    public class ValidationException : Exception
    {
        #region Propiedades
        #endregion

        #region Constructor
        #endregion
        public ValidationException() : base("Error de validación.") { }
        public ValidationException(string error) : base(error) { }
        #region Metodos
        #endregion
    }
}
