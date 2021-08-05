using EntitySQL;
using Repository;
using System;
using System.Collections.Generic;
using Databases;
using System.Data.SqlClient;
using System.Data;
namespace RepositoryImpl
{
    public class ImpUsuarioRepository : UsuarioRepository
    {
        private SqlConnection sqlConnection = SQLServerDB.sqlConection();
        public IList<Usuario> findAll()
        {
            SQLServerDB.abrirConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from usuario";
            SqlDataReader sqlDataReader= sqlCommand.ExecuteReader();
            IList<Usuario> list = new List<Usuario>();
            while (sqlDataReader.Read()) {
                Usuario usuario = new Usuario() {
                    Id=int.Parse(sqlDataReader[0].ToString()),
                    username=sqlDataReader[1].ToString(),
                    password=sqlDataReader[2].ToString(),
                    rol=int.Parse(sqlDataReader[3].ToString()),
                    persona_id=int.Parse(sqlDataReader[4].ToString()),
                    createdAt=sqlDataReader.GetDateTime("createdAt"),
                    updateAt=sqlDataReader.GetDateTime("updatedAt")
                    };
                list.Add(usuario);
            }
            SQLServerDB.cerrarConexion();
            return list;
        }

        public Usuario findById(int id)
        {
            SQLServerDB.abrirConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "sp_api_usuarios";
            sqlCommand.Parameters.Add(new SqlParameter("@operacion",3 ));
            sqlCommand.Parameters.AddWithValue("@id",id);
            SqlDataReader sqlDataReader= sqlCommand.ExecuteReader();
            Usuario resulUsuario = new Usuario();
            Console.Write(resulUsuario);
            while (sqlDataReader.Read())
            {
                resulUsuario.Id =int.Parse(sqlDataReader[0].ToString());
                resulUsuario.username = sqlDataReader[1].ToString();
                resulUsuario.password = sqlDataReader[2].ToString();
                resulUsuario.rol = int.Parse(sqlDataReader[3].ToString());
                resulUsuario.persona_id = int.Parse(sqlDataReader[4].ToString());
            }
            SQLServerDB.cerrarConexion();
            return resulUsuario;
        }

        public Usuario insert(Usuario createUsuario)
        {
            SQLServerDB.abrirConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "sp_api_usuarios";
            sqlCommand.Parameters.AddWithValue("@username", createUsuario.username);
            sqlCommand.Parameters.AddWithValue("@password",createUsuario.password);
            sqlCommand.Parameters.AddWithValue("@rol",createUsuario.rol);
            sqlCommand.Parameters.AddWithValue("@persona_id",createUsuario.persona_id);
            sqlCommand.Parameters.AddWithValue("@operacion",2);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            Usuario insertUser = new Usuario();
            while (sqlDataReader.Read())
            {
                insertUser.Id =sqlDataReader.GetInt32("id");
                insertUser.username = sqlDataReader.GetString("username");
                insertUser.password = sqlDataReader.GetString("password");
                insertUser.rol = sqlDataReader.GetInt32("rol");
                insertUser.persona_id = sqlDataReader.GetInt32("persona_id");
                insertUser.createdAt = sqlDataReader.GetDateTime("createdAt");
                insertUser.updateAt = sqlDataReader.GetDateTime("updatedAt");
            }
            SQLServerDB.cerrarConexion();
            return insertUser;
        }

        public int update(Usuario updateUsuario)
        {
            throw new NotImplementedException();
        }

        public int delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
