using EntitySQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace Apis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;
       
        public UsuarioController(ILogger<UsuarioController> _logger,
            UsuarioService usuarioService
            ) {
            this._logger = _logger;
            _usuarioService = usuarioService;
        }

        [HttpGet("/api/usuario/listar")]
        public IList<UsuarioDTO> Getusers()
        {
            return _usuarioService.listarUsuarios();
          
        }

        [HttpPost("/api/usuario/create")]
        public Usuario addUsuario(UsuarioCreateDTO newUsuario)
        {
            return _usuarioService.insert(newUsuario);
        }

        [HttpGet("/api/usuario/{id}")]
        public ActionResult<UsuarioDTO> findById(int id)
        {
            try
            {
                return _usuarioService.findById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
