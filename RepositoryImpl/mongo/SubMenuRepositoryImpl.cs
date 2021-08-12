using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Databases;
using DTO.mongo;
using EntityMongo;
using MongoDB.Driver;
using Repository.mongo;

namespace RepositoryImpl.mongo
{
    public class SubMenuRepositoryImpl : SubMenuRepository
    {
        private IMongoDatabase conexionMongo = ConexionMongo.getInstanceDB();
        public IList<Submenu> findAll()
        {
            IMongoCollection<Submenu> collectionDb = conexionMongo.GetCollection<Submenu>("submenu");
            var list = collectionDb.Find(x=>true);
            return list.ToList();
        }

        public SubmenuDTO findById(string id)
        {

            try
            {
                IMongoCollection<Submenu> collectionDb = conexionMongo.GetCollection<Submenu>("submenu");
                var result = collectionDb.Find(x => x._id == id).FirstOrDefaultAsync();
                if (result.Result!=null)
                {
                    MapperConfiguration mapperConfiguration = new MapperConfiguration(configure =>
                    {
                        configure.CreateMap<Submenu,SubmenuDTO>();
                    });
                    Mapper mapper = new Mapper(mapperConfiguration);
                    SubmenuDTO submenuDto = mapper.Map<Submenu,SubmenuDTO>(result.Result);
                    return submenuDto;
                }
                else
                {
                    throw new Exception("no se encontró resultados");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
               
        }

        public void insert(Submenu submenu)
        {
            IMongoCollection<Submenu> collectionDb = conexionMongo.GetCollection<Submenu>("submenu");
            collectionDb.InsertOne(submenu);
        }

        public TaskStatus update(Submenu updateSubmenu)
        {
            try
            {
                IMongoCollection<Submenu> collectionDb = conexionMongo.GetCollection<Submenu>("submenu");
                var update = Builders<Submenu>
                    .Update
                    .Set(_submenu=>_submenu.color,updateSubmenu.color)
                    .Set(_submenu=>_submenu.css,updateSubmenu.css)
                    .Set(_submenu=>_submenu.descripcion,updateSubmenu.descripcion)
                    .Set(_submenu=>_submenu.icono,updateSubmenu.icono)
                    .Set(_submenu=>_submenu.url,updateSubmenu.url)
                    .Set(_submenu=>_submenu.estado,updateSubmenu.estado)
                    .Set(_submenu=>_submenu._menu,updateSubmenu._menu)
                    .Set(_submenu=>_submenu.nombre,updateSubmenu.nombre)
                    .Set(_submenu=>_submenu.clases,updateSubmenu.clases);
                var result = collectionDb.UpdateOneAsync(x => x._id == updateSubmenu._id, update)
                    .Status;
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public TaskStatus delete(string id)
        {
            var update = Builders<Submenu>.Update.Set(_submenu =>_submenu.estado ,false);
            var result = conexionMongo.GetCollection<Submenu>("submenu")
                .FindOneAndUpdateAsync(x => x._id == id, update).Status;
            return result;
        }
    }
}