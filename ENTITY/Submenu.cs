using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMongo
{
   public class Submenu
    {

        public ObjectId _id { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public String icono { get; set; }
        public String css { get; set; }
        public bool estado { get; set; }
        public string url { get; set; }
        public string clases { get; set; }
        public string color { get; set; }
    }
}
