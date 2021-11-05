using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Mensajeria.BL.Logica.Acciones
{
    internal class MensajeriaPlana
    {
        /// <summary>
        /// Para enviar mensajes
        /// </summary>
        /// <param name="elMensaje">Mensaje enviado</param>
        public void Enviar(Mensaje elMensaje)
        {
            Console.WriteLine($"Mensaje de {elMensaje.Remitente} para {elMensaje.Destinatario}:[{elMensaje.Texto}].");
        }

        /// <summary>
        /// Para leer los mensajes
        /// </summary>
        /// <param name="Propietario">Nombre del propietario cuyos mensajes queremos leer</param>
        /// <returns>La lista de los mensajes</returns>
        public IList<Mensaje> Leer(string Propietario)
        {
            List<Mensaje> elResultado = new List<Mensaje> { new Mensaje("Mi", "Ti", "Hola Mundo.") };
            return elResultado;
        }
    }
}
