using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Databases
{
    
    public class SQLServerDB
    {
        private static  SQLServerDB sqlserverDB;
        private static SqlConnection sqlConnection;
        private static string cadenaConexion;

        private SQLServerDB() {
            cadenaConexion = "workstation id=ecommerceSQL.mssql.somee.com;packet size=4096;user id=jhon64_SQLLogin_1;pwd=v9ph5i75kt;data source=ecommerceSQL.mssql.somee.com;persist security info=False;initial catalog=ecommerceSQL";
            sqlConnection = new SqlConnection(cadenaConexion);
        }
        public static SqlConnection sqlConection()
        {
            if (sqlConnection == null)
            {
                sqlserverDB = new SQLServerDB();
            }
            return sqlConnection;
        }

        public static void abrirConexion()
        {
            if (sqlConnection == null)
            {
                sqlserverDB = new SQLServerDB();
            }

            sqlConnection.Open();
        }
        public static void cerrarConexion()
        {
            if (sqlConnection == null)
            {
                sqlserverDB = new SQLServerDB();
            }
            sqlConnection.Close();
        }
    }
}
