using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Mensajeria.BL
{
    //Esta interface se encarga de enviar y recibir mensajes.
    public interface IMensajeria
    {
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elMensaje">Mensaje para enviar</param>
        public void Enviar(Mensaje elMensaje);

        /// <summary>
        /// Para leer los mensajes de un buzón
        /// </summary>
        /// <param name="Propietario">Nombre del dueño del buzón</param>
        /// <returns>Lista de todos los mensajes del buzón</returns>
        public IList<Mensaje> Leer(string Propietario);

    
    }
}
