using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySQL
{
    public class Persona
    {
        public int personaID { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string sexo { get; set; }
        public DateTime nacimiento { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }


    }
}
