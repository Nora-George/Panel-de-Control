using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Panel_de_Control_IoT_Privadas.Models
{
    public class Epoch
    {
        public int convertirEpoch(DateTime fecha)
        {
            DateTime fechaInicial = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int epoch = (int)(fecha.ToUniversalTime() - fechaInicial).TotalSeconds;
            return epoch;
        }
        public DateTime convertirFecha(int epoch)
        {
            DateTime fechaInicial = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            fechaInicial = fechaInicial.AddSeconds(epoch).ToLocalTime();
            return fechaInicial;
        }
    }
}