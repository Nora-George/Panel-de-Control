namespace Panel_de_Control_IoT_Privadas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Casas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Casas()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int ID { get; set; }

        public int NumCasa { get; set; }

        public int PrivadaID { get; set; }

        public bool Estatus { get; set; }

        public virtual Privadas Privadas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
    public partial class CasasDTO
    {
        public int ID { get; set; }

        public int NumCasa { get; set; }

        public string PrivadaNombre { get; set; }

        public bool Estatus { get; set; }
        //public List<Usuarios> Usuarios { get; set; }
    }
}
