using System.Collections.Generic;
using EntityMongo;

namespace Repository.mongo
{
    public interface SubMenuRepository
    {
        IList<Submenu> findAll();
        Submenu findById(int id);
        Menu insert(Submenu submenu);
        int update(Submenu updateSubmenu);
        int delete(int id);
    }
}