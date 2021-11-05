using System;

namespace NetCore.Mensajeria.BL
{
    /// <summary>
    /// Clase para envío de mensajes
    /// </summary>
    public class Mensaje
    {
        public Mensaje()
        {

        }

        public Mensaje(string Remitente, string Destinatario, String Texto)
        {
            this.Remitente = Remitente;
            this.Destinatario = Destinatario;
            this.Texto = Texto;
        }

        /// <summary>
        /// Nombre de quien envía el mensaje
        /// </summary>
        public string Remitente;

        /// <summary>
        /// Nombre de quien recibe el mensaje
        /// </summary>
        public string Destinatario;

        /// <summary>
        /// Cuerpo del mensaje
        /// </summary>
        public string Texto;
    }
}
