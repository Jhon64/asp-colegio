using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databases;
using System.Data;

namespace TestsApp
{
    class TestSQL
    {
        private static readonly SqlConnection sqlServerDB = SQLServerDB.sqlConection();
        static void Mn(string[] args)
        {
            try
            {
                SQLServerDB.abrirConexion();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlServerDB;
                command.CommandType = CommandType.Text;
                command.CommandText = "select *from usuario";
                SqlDataReader sqlDataReader= command.ExecuteReader();
                while (sqlDataReader.Read()) {
                    Console.Write(sqlDataReader[1]);
                }

                SQLServerDB.cerrarConexion();
            }catch(Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
    }
}
