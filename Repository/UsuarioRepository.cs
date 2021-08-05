using EntitySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface UsuarioRepository
    {
        IList<Usuario> findAll();
        Usuario findById(int id);
        Usuario insert(Usuario createUsuario);
        int update(Usuario updateUsuario);
        int delete(int id);
    }
}
