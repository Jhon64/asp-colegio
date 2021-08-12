using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace EntityMongo
{
    public class Submenu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public String nombre { get; set; }
        public String descripcion { get; set; }
        public String icono { get; set; }
        public String css { get; set; }
        public bool estado { get; set; }
        public string url { get; set; }
        public string clases { get; set; }
        public string color { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_menuID")]
        public  string _menu{get; set; }
    }
}