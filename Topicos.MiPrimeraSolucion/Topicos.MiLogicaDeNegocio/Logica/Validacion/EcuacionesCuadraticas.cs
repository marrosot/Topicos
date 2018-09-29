using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Topicos.MiLogicaDeNegocio.Logica.Validacion
{
    internal class EcuacionesCuadraticas
    {
        internal bool AEsDiferenteDeCero (double a)
        {
            return (a != 0);
        }

        internal bool ElDiscriminanteEsMayorOIgualQueCero(double elDiscriminante)
        {
            return (elDiscriminante >= 0);
        }

    }
}