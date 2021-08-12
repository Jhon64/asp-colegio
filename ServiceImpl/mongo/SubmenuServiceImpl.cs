using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DTO.mongo;
using EntityMongo;
using MongoDB.Bson;
using MongoDB.Driver;
using Repository.mongo;
using RepositoryImpl.mongo;
using Service.mongo;

namespace ServiceImpl.mongo
{
    public class SubmenuServiceImpl:SubmenuService
    {
        private SubMenuRepository _submenuRepository = new SubMenuRepositoryImpl();
        public IList<Submenu> findAll()
        {
           return _submenuRepository.findAll();
        }

        public void save(SubmenuCreateDTO newSumenu)
        {
           /* MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<SubmenuCreateDTO,Submenu>();
            });
            
           IMapper iMapper = mapperConfiguration.CreateMapper();*/
            //Submenu submenu=iMapper.Map<SubmenuCreateDTO,Submenu>(newSumenu);
            Submenu submenu = new Submenu();
            submenu.clases = newSumenu.clases;
            submenu.color = newSumenu.color;
            submenu.css = newSumenu.css;
            submenu.descripcion = newSumenu.descripcion;
            submenu.estado = newSumenu.estado;
            submenu.icono = newSumenu.icono;
            submenu.nombre =newSumenu.nombre;
            submenu.url = newSumenu.url;
            submenu._menu =newSumenu._menuID;
            Console.Write(submenu.ToString());
            //submenu.menu = menu;

            _submenuRepository.insert(submenu);
        }

        public SubmenuDTO findById(string _id)
        {
            return _submenuRepository.findById(_id);
        }

        public TaskStatus delete(string _id)
        {
            return _submenuRepository.delete(_id);
        }

        public TaskStatus update(SubmenuUpdateDTO updateSubmenu)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(configure =>
            {
                configure.CreateMap<SubmenuUpdateDTO, Submenu>();
            });
            Mapper mapper = new Mapper(mapperConfiguration);
            Submenu submenu = mapper.Map<SubmenuUpdateDTO,Submenu>(updateSubmenu);
            return _submenuRepository.update(submenu);
        }
    }
}