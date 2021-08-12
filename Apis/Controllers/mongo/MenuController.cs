using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.mongo;
using EntityMongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Service.mongo;
using ServiceImpl.mongo;

namespace Apis.Controllers.mongo
{
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _menuService;
        private readonly ILogger<MenuController> _logger;
       
        public MenuController(ILogger<MenuController> _logger,
            MenuService menuService
        ) {
            this._logger = _logger;
            _menuService = menuService;
        }

        // GET: api/Menu
        [HttpGet]
        public List<MenuDTO> Get()
        {
          return _menuService.listar();
          
        }

        // GET: api/Menu/5
        [HttpGet("{id}")]
        public MenuDTO Get(string id)
        {
            return _menuService.findById(id);
        }

        // POST: api/Menu
        [HttpPost]
        
        public void Post([FromBody] MenuCreateDTO newMenu)
        {
             _menuService.save(newMenu);   
        }

        // PUT: api/Menu/5
        [HttpPut()]
        public TaskStatus Put(MenuDTO updateMenu )
        {
            return _menuService.actualizar(updateMenu);
        }

        // DELETE: api/Menu/5
        [HttpDelete("{_id}")]
        public TaskStatus Delete(string _id)
        {
            return _menuService.eliminar(_id);
        }

        [HttpGet("listar/submenus")]
        public ICollection<MenuSubmenuDTO> listarMenuSubmenus()
        {
            return _menuService.listarMenuSubmenus();
        }
    }
}
