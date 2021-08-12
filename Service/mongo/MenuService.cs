using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.mongo;
using EntityMongo;
using MongoDB.Driver;

namespace Service.mongo
{
    public interface MenuService
    {
        List<MenuDTO> listar();
        void save(MenuCreateDTO newMenu);
        MenuDTO findById(string _id);
        ICollection<MenuSubmenuDTO> listarMenuSubmenus();
        TaskStatus eliminar(string _id);
        TaskStatus actualizar(MenuDTO updateMenu);
    }
}