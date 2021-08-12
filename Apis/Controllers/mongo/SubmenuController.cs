using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.mongo;
using EntityMongo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.mongo;

namespace Apis.Controllers.mongo
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmenuController : ControllerBase
    {
        private readonly SubmenuService _submenuService;
        private readonly ILogger<SubmenuController> _logger;

        public SubmenuController(ILogger<SubmenuController> _logger,
            SubmenuService submenuService
        )
        {
            this._logger = _logger;
            _submenuService = submenuService;
        }
        
        // GET: api/Menu
        [HttpGet]
        public IList<Submenu> Get()
        {
            return _submenuService.findAll();

        }
        
        [HttpPost]
        public void insert([FromBody] SubmenuCreateDTO addSubmenu)
        {
             _submenuService.save(addSubmenu);

        }

        [HttpGet("buscar/{_id}")]
        public SubmenuDTO findById(string _id)
        {
            return _submenuService.findById(_id);
        }

        [HttpDelete(template: "{_id}")]
        public TaskStatus eliminar(string _id)
        {
            return _submenuService.delete(_id);
        }

        [HttpPut()]
        public TaskStatus actualizar([FromBody] SubmenuUpdateDTO updateSubmenu)
        {
            return _submenuService.update(updateSubmenu);
        }
    }
    
}