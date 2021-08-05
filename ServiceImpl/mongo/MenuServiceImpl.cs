using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoMapper;
using DTO.mongo;
using EntityMongo;
using MongoDB.Bson;
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
            Console.WriteLine(resultList.First().descripcion);
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
           /*resultList.ForEach(x =>
            {
                MenuDTO menuDto = new MenuDTO();
                menuDto._id =x._id.ToString();
                menuDto.nombre = x.nombre.ToString();
                menuDto.clases = x.clases.ToString();
                menuDto.color = x.color.ToString();
                menuDto.css = x.color.ToString();
                menuDto.descripcion = x.descripcion.ToString();
                menuDto.estado = Boolean.Parse(x.estado.ToString());
                menuDto.icono = x.icono.ToString();
                menuDto.url = x.url.ToString();
                listDto.Add(menuDto);
            });*/
            return listDto;
        }

        public void save(MenuDTO newMenu)
        {
          
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<MenuDTO,Menu>();
            });
            IMapper iMapper = mapperConfiguration.CreateMapper();
            Menu menu=iMapper.Map<MenuDTO,Menu>(newMenu);
            _menuRepository.insert(menu);
            
        }
    }
}