namespace Panel_de_Control_IoT_Privadas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Privadas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Privadas()
        {
            Casas = new HashSet<Casas>();
            Historials = new HashSet<Historials>();
        }

        public int ID { get; set; }

        public string Nombre { get; set; }

        public string NumeroSerie { get; set; }

        public string Contraseña { get; set; }

        public string NombreAdministrador { get; set; }

        public string ContraseñaAdministrador { get; set; }

        public bool Estatus { get; set; }

        public bool ServicioCompleto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Casas> Casas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historials> Historials { get; set; }
    }
}
