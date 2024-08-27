namespace Panel_de_Control_IoT_Privadas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        public int ID { get; set; }

        public string Correo { get; set; }

        public int CasaID { get; set; }

        public bool Estatus { get; set; }

        public virtual Casas Casas { get; set; }
    }
}
