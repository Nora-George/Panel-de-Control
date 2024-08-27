using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Panel_de_Control_IoT_Privadas.Models
{
    [TableName("Administradores")]
    public class Administrador
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public bool Estatus { get; set; }
    }
}