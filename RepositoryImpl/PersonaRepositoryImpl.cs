using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitySQL;
using Repository;
using Databases;
using System.Data.SqlClient;
using System.Data;

namespace RepositoryImpl
{
    public class PersonaRepositoryImpl : PersonaRepository
    {
        private SqlConnection sqlConnection = SQLServerDB.sqlConection();
        public IList<Persona> findAll()
        {
            SQLServerDB.abrirConexion();
            IList<Persona> listPerson = new List<Persona>();
            
            SQLServerDB.cerrarConexion();
            return listPerson;
        }
    }
}
