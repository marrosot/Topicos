using NetCore.Mensajeria.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.ConsoleApp
{
    public class LogicaPrincipal
    {
        public void HagaLaMagiaOld()
        {
            Console.WriteLine("Hello World!");
        }

        public void HagaLaMagia()
        {
            var elMensaje = new Mensaje("Yo", "Usted", "Hello Word!");
            var elServicio = new MensajeriaPlana();
            elServicio.Enviar(elMensaje);
        }
    }
}
