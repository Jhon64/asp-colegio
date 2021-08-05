using System;
using System.Collections.Generic;
using Databases;
using EntityMongo;
using MongoDB.Driver;
using Repository.mongo;

namespace RepositoryImpl.mongo
{
    public class MenuRepositoryImpl:MenuRepository
    {
        private IMongoDatabase conexionMongo = ConexionMongo.getInstanceDB();
        public IList<Menu> findAll()
        {
            IMongoCollection<Menu> collectionDb = conexionMongo.GetCollection<Menu>("menu");
            var list = collectionDb.Find(x=>true);
            Console.Write(list.ToString());
            return list.ToList();
        }

        public Menu findById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void insert(Menu menu)
        {
            IMongoCollection<Menu> collectionDb = conexionMongo.GetCollection<Menu>("menu");
            collectionDb.InsertOne(menu);
        }

        public int update(Menu updateMenu)
        {
            throw new System.NotImplementedException();
        }

        public int delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}