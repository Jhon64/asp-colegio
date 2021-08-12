using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.mongo;
using EntityMongo;
using MongoDB.Driver;

namespace Repository.mongo
{
    public interface MenuRepository
    {
        IList<Menu> findAll();
        Menu findById(string id);
        void insert(Menu menu);
        TaskStatus update(Menu updateMenu);
        TaskStatus delete(string _id);

        ICollection<MenuSubmenuDTO> findAllDetailSubmenus();
    }
}