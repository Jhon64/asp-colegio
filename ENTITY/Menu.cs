using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace EntityMongo
{
    public class Menu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string icono { get; set; }
        public string css { get; set; }
        public bool estado { get; set; }
        public string url { get; set; } 
        public string clases { get; set; }
        public string color { get; set; }

        [DataMember]
        public List<Submenu> submenus { get; set; }
    }
}
