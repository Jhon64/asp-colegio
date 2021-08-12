using System;
using DatabaseContext;
using EntitySQL;

namespace DatabaseContext
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ECommerceSQLContext())
            {
                var persona1 = new Persona()
                {
                    nombres = "alexander",
                    paterno = "amaranto",
                    materno = "tandaypan",
                    dni = "12312312",
                    celular = "123123123",
                    sexo = "M",
                    email = "juan@alexander",
                    direccion = "viru",
                    nacimiento = new DateTime()
                };
                context.Personas.Add(persona1);
                context.SaveChanges();
            };
            Console.WriteLine("Hello World!");
        }
    }
}
