using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Databases
{
    public class ConexionMongo
    {
        private MongoDB.Driver.MongoClient client;
        private static IMongoDatabase mongoDatabase;
        private static ConexionMongo mongoDB;
        public string _cadenaConexion="mongodb+srv://jhon:sneider10@cluster0.nimo2.mongodb.net/ecommerceMongo";
        private ConexionMongo()
        {
            client = new MongoDB.Driver.MongoClient(_cadenaConexion);
            mongoDatabase = client.GetDatabase("ecommerceMongo");
        }


        public static IMongoDatabase getInstanceDB()
        {
            if (mongoDatabase == null)
            {
                mongoDB = new ConexionMongo();
            }
            return mongoDatabase;
        }

      
        
    }
}
