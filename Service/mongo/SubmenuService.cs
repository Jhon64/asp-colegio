using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.mongo;
using EntityMongo;
using MongoDB.Driver;

namespace Service.mongo
{
    public interface SubmenuService
    {
        public IList<Submenu> findAll();
        public void save(SubmenuCreateDTO newSumenu);
        public SubmenuDTO findById(string _id);
        public TaskStatus delete(string _id);
        public TaskStatus update(SubmenuUpdateDTO updateSubmenu);
    }
}