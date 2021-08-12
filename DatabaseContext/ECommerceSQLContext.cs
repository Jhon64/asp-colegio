using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databases;
using EntitySQL;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext
{
    public class ECommerceSQLContext : DbContext
    {
       public DbSet<Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cadenaConexion = SQLServerDB._getCadenaConexion();
            Console.Write(cadenaConexion);
            optionsBuilder.UseSqlServer(cadenaConexion);
         
        }

       

    }
}
