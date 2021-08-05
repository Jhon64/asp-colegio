using System.Collections.Generic;
using DTO.mongo;
using EntityMongo;

namespace Service.mongo
{
    public interface MenuService
    {
        List<MenuDTO> listar();
        void save(MenuDTO newMenu);
    }
}