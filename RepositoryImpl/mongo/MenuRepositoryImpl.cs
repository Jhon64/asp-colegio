using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Databases;
using DTO.mongo;
using EntityMongo;
using EntitySQL;
using MongoDB.Bson;
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
            return list.ToList();
        }

        public Menu findById(string id)
        {
            var collectionDb = conexionMongo.GetCollection<Menu>("menu");
            var menu = collectionDb.Find(x=>x._id==id).First();
            return menu;
        }

        public void insert(Menu menu)
        {
            IMongoCollection<Menu> collectionDb = conexionMongo.GetCollection<Menu>("menu");
            collectionDb.InsertOne(menu);
        }

        public TaskStatus update(Menu updateMenu)
        {
            IMongoCollection<Menu> collectionDb = conexionMongo.GetCollection<Menu>("menu");
            var update = Builders<Menu>
                .Update
                .Set(_menu => _menu.clases, updateMenu.clases)
                .Set(_menu => _menu.color, updateMenu.color)
                .Set(_menu=>_menu.css,updateMenu.color)
                .Set(_menu=>_menu.descripcion,updateMenu.descripcion)
                .Set(_menu=>_menu.icono,updateMenu.icono)
                .Set(_menu=>_menu.nombre,updateMenu.nombre)
                .Set(_menu=>_menu.url,updateMenu.url);
            var updateResult=collectionDb
                .FindOneAndUpdateAsync(x=>x._id==updateMenu._id,update)
                .Status;
            return updateResult;
        }

        public TaskStatus delete(string _id)
        {
            var update = Builders<Menu>.Update.Set(menu =>menu.estado ,false);
            var result = conexionMongo.GetCollection<Menu>("menu")
                .FindOneAndUpdateAsync(x => x._id == _id, update).Status;
           return result;
        }

        public ICollection<MenuSubmenuDTO> findAllDetailSubmenus()
        {
          
            List<Menu> personaCollection =conexionMongo.GetCollection<Menu>("menu").Find(x=>x.estado).ToList();
            List<MenuSubmenuDTO> listResult = new List<MenuSubmenuDTO>();

            personaCollection.ForEach(elem =>
            {
                //parseamos la clase Menu en MenuSubmenuDto
                MapperConfiguration mcMenuSubmenu= new MapperConfiguration(config =>
                {
                    config.CreateMap<Menu,MenuSubmenuDTO>();
                });
                Mapper mpMenuSubmenu = new Mapper(mcMenuSubmenu);
                MenuSubmenuDTO menuSubmenuDto = mpMenuSubmenu.Map<Menu,MenuSubmenuDTO>(elem);

                //buscamos la informacion correspondiente en el enlace mongo
                // y parseamos 
                List<Submenu> submenus = conexionMongo.GetCollection<Submenu>("submenu").Find(x => x._menu == elem._id).ToList();
                MapperConfiguration mcSubmenu = new MapperConfiguration(config => {
                    config.CreateMap<Submenu,SubmenuDTO>();
                });
                Mapper mpTest = new Mapper(mcSubmenu);
                List<SubmenuDTO> listSubmenuDTO = new List<SubmenuDTO>();
                submenus.ForEach(_submen =>
                {
                    SubmenuDTO submenuDTO = mpTest.Map<Submenu, SubmenuDTO>(_submen);
                    listSubmenuDTO.Add(submenuDTO);
                });
                menuSubmenuDto.submenus = listSubmenuDTO;
                listResult.Add(menuSubmenuDto);

            });
            return listResult;
        }
    }
}