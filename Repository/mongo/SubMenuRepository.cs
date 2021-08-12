using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.mongo;
using EntityMongo;
using MongoDB.Driver;

namespace Repository.mongo
{
    public interface SubMenuRepository
    {
        IList<Submenu> findAll();
        SubmenuDTO findById(string _id);
        void insert(Submenu submenu);
        TaskStatus update(Submenu updateSubmenu);
        TaskStatus delete(string _id);
    }
}