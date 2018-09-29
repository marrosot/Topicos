using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Topicos.MiLogicaDeNegocio.Logica.Accion
{
    public class ResolverEcuacionCuadratica
    {
        internal ResultadoEcuacionCuadratica ResuelvaEcuacionCuadratica(float a, float b, float c)
        {
            var elResultado = new ResultadoEcuacionCuadratica();
            elResultado.PrimeraRaiz = elResultado.SegundaRaiz = null;
            // validar las entradas
            var laValidacion = new Validacion.EcuacionesCuadraticas();
            if (laValidacion.AEsDiferenteDeCero(a))
            {
                elResultado.Discriminante = CalcularDiscriminante(a, b, c);
                if (laValidacion.ElDiscriminanteEsMayorOIgualQueCero(elResultado.Discriminante))
                {
                    elResultado.PrimeraRaiz = CalcularRaiz(a, b, c, elResultado.Discriminante, true);
                    elResultado.SegundaRaiz = CalcularRaiz(a, b, c, elResultado.Discriminante, false);
                }
            }
            return elResultado;
        }

        internal double CalcularDiscriminante (double a, double b, double c)
        {
            double elResultado = (b * b - 4 * a * c);
            return elResultado;
        }

        [Obsolete]
        internal double CalcularRaizConMas (double a, double b, double c, double elDiscriminante)
        {
            var elResultado = (-b + Math.Sqrt(elDiscriminante)) / (2 * a);
            return elResultado;
        }

        [Obsolete]
        internal double CalcularRaizConMenos(double a, double b, double c, double elDiscriminante)
        {
            var elResultado = (-b - Math.Sqrt(elDiscriminante)) / (2 * a);
            return elResultado;
        }

        internal double CalcularRaiz(double a, double b, double c, double elDiscriminante, bool hagoUnaSuma)
        {
            double elSigno = (hagoUnaSuma) ? 1.0: -1.0;
            var elResultado = (-b + (elSigno) * Math.Sqrt(elDiscriminante)) / (2 * a);
            return elResultado;
        }

    }
}