using System.Collections.Generic;
using EntityMongo;

namespace Repository.mongo
{
    public interface MenuRepository
    {
        IList<Menu> findAll();
        Menu findById(int id);
        void insert(Menu menu);
        int update(Menu updateMenu);
        int delete(int id);
    }
}