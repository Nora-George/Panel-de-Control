namespace Panel_de_Control_IoT_Privadas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Historials
    {
        public int ID { get; set; }

        public int NumCasa { get; set; }

        public string Observacion { get; set; }

        public string Usuario { get; set; }

        public int FechaEpoch { get; set; }

        public int PrivadaID { get; set; }
        public DateTime Fechadatetime
        {
            get
            {
                Epoch epoch = new Epoch();
                return epoch.convertirFecha(this.FechaEpoch);
            }
        }


        public virtual Privadas Privadas { get; set; }
    }
    public partial class HistorialsDTO
    {
        public int ID { get; set; }

        public int NumCasa { get; set; }

        public string Observacion { get; set; }

        public string Usuario { get; set; }

        public int FechaEpoch { get; set; }

        public int PrivadaID { get; set; }

        public DateTime Fechadatetime { get; set; }
    }
}
