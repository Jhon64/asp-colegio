using EntitySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Service
{
    public interface UsuarioService
    {
        public IList<UsuarioDTO> listarUsuarios();
        UsuarioDTO findById(int id);
        Usuario insert(UsuarioCreateDTO createUsuario);
        int update(UsuarioCreateDTO updateUsuario,int id);
        int delete(int id);
    }
}