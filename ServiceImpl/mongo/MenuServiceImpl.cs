using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
    public class MenuServiceImpl:MenuService
    {
        private MenuRepository _menuRepository = new MenuRepositoryImpl();

        public List<MenuDTO> listar()
        {
            List<Menu> resultList =_menuRepository.findAll().ToList();
            List<MenuDTO> listDto = new List<MenuDTO>();
            foreach (var menu in resultList)
            {
                MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
                {
                    config.CreateMap<Menu, MenuDTO>();
                });
                IMapper iMapper = mapperConfiguration.CreateMapper();
                MenuDTO menuDto=iMapper.Map<Menu,MenuDTO>(menu);
                listDto.Add(menuDto);
            }
           
            return listDto;
        }

        public void save(MenuCreateDTO newMenu)
        {
          
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<MenuCreateDTO,Menu>();
            });
            IMapper iMapper = mapperConfiguration.CreateMapper();
            Menu menu=iMapper.Map<MenuCreateDTO,Menu>(newMenu);
            _menuRepository.insert(menu);
            
        }

        public MenuDTO findById(string _id)
        {
            Menu findMenu=_menuRepository.findById(_id);
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Menu,MenuDTO>();
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            MenuDTO menuDto = mapper.Map<Menu, MenuDTO>(findMenu);
            return menuDto;

        }

        public ICollection<MenuSubmenuDTO> listarMenuSubmenus()
        {
            return _menuRepository.findAllDetailSubmenus();
        }

        public TaskStatus eliminar(string _id)
        {
            return _menuRepository.delete(_id);
        }

        public TaskStatus actualizar(MenuDTO updateMenu)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(configure =>
            {
                configure.CreateMap<MenuDTO,Menu>();
            });
            Mapper mapper = new Mapper(mapperConfiguration);
            Menu menu = mapper.Map<MenuDTO,Menu>(updateMenu);
            return _menuRepository.update(menu);
        }
    }
}