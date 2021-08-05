using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.mongo;
using EntityMongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.mongo;
using ServiceImpl.mongo;

namespace Apis.Controllers.mongo
{
    [Route("api/[controller]")]
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
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Menu
        [HttpPost]
        
        public void Post([FromBody] MenuDTO newMenu)
        {
             _menuService.save(newMenu);   
        }

        // PUT: api/Menu/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Menu/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
