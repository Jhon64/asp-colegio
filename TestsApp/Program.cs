using System;
using System.Collections.Generic;
using Databases;
using EntityMongo;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace TestsApp
{
    class Program
    {
         private static IMongoDatabase mongoDB = ConexionMongo.getInstanceDB();
          private static IMongoCollection<Usuario> collectionDB;


          static void Main(string[] args)
          {
              //listar();
              //actualizar();
              //findBy("60de8256117d98adf1bdf87a");
              // registrar();
              // delete("60de8256117d98adf1bdf87a");
              //insertDetails();
              //eliminarTodos();
              //listarDetails();
              listarMenu();
          }

          public static void listarMenu()
          {
              try
              {
                  Console.Write("Lista de menu");
                  List<Menu> MenucollectionDB=mongoDB.GetCollection<Menu>("menu").Find(d=>true).ToList();
                  
                  Console.Write(MenucollectionDB.First().nombre);

              }
              catch (Exception e)
              {
                  Console.WriteLine(e);
                  throw;
              }
              
          }
          public static void listarDetails()
          {
              IMongoCollection<Usuario> collectionUsuarios = mongoDB.GetCollection<Usuario>("usuarios");
              IMongoCollection<DetalleUsuario> collectionDetails = mongoDB.GetCollection<DetalleUsuario>("detalle_usuario");
              List<BsonDocument> listaUsuarios = collectionUsuarios
                  .Aggregate<Usuario>()
                  .Lookup(
                   "detalle_usuario",
                  "ListaRefs",
                  "id",
                 "detailsUsers"
                  )
                //  .Unwind("result")
                  .ToList();

              listaUsuarios.ForEach(x =>
              {
                  String json = x.ToJson();
                  Console.Write(json);
                //String json= x.GetElement("detailsUsers").Value.ToJson();
  //                List<DetalleUsuario> list_detalle = JsonSerializer.Deserialize<List<DetalleUsuario>>(json);
              });

          }
          public static void insertDetails()
          {
              IMongoCollection<Usuario> collectionUsuarios = mongoDB.GetCollection<Usuario>("usuarios");
              IMongoCollection<DetalleUsuario> collectionDetails = mongoDB.GetCollection<DetalleUsuario>("detalle_usuario");
              Usuario newUsuario = new Usuario() { Name="Sneider", Password="Sn@der10",Username="Sn@ider64"};
              List<MongoDBRef> listUsuarios = new List<MongoDBRef>();

              DetalleUsuario detailsUser1 = new DetalleUsuario() { Test="test detalle 1"};
              var result=collectionDetails.InsertOneAsync(detailsUser1);
              listUsuarios.Add(new MongoDBRef("detalle_usuario",result.Id));
              DetalleUsuario detailsUser2 = new DetalleUsuario() { Test="detalle test 2"};
              var result2 = collectionDetails.InsertOneAsync(detailsUser2);
              listUsuarios.Add(new MongoDBRef("detalle_usuario", result2.Id));
              newUsuario.ListaRefs = listUsuarios;
              collectionUsuarios.InsertOne(newUsuario);

          }

          public static void delete(string _id) {
              collectionDB = mongoDB.GetCollection<Usuario>("usuarios");
              DeleteResult deleteResult= collectionDB.DeleteOne(x=>x.Id==_id);
              Console.Write(deleteResult.DeletedCount);
          }

          public static void findBy(string _id)
          {
              collectionDB = mongoDB.GetCollection<Usuario>("usuarios");
              Usuario search = collectionDB.Find(d => d.Id ==_id).First();
              Console.Write(search.Name);
          }

          public static void actualizar()
          {
              //buscamos el usuario
              try
              {

                  collectionDB = mongoDB.GetCollection<Usuario>("usuarios");
                  string findId = "60de71c6005faadb66a162b5";
                  var filters = Builders<Usuario>.Filter.Eq(eq=>eq.Id, findId);
                  var updateUser = Builders<Usuario>.Update
                      .Set(x => x.Name, "Alexandre")
                      .Set(x=>x.Password,"admin")
                      .Set(x=>x.Username,"test");

                  collectionDB.UpdateOne(filters, updateUser);
              }catch(Exception ex)
              {
                  Console.Write("error"+ex.ToString());
              }

          }

          public static void listar()
          {
              collectionDB = mongoDB.GetCollection<Usuario>("usuarios");
              List<Usuario> list = collectionDB.Find(d => true).ToList();
  //delegate se puede usar como lamda con una funcion
              list.ForEach(e=>
              {
                  Console.Write(e.Name);
              });

          }
          public static void eliminarTodos()
          {
              collectionDB = mongoDB.GetCollection<Usuario>("usuarios");
              collectionDB.DeleteMany(x=>true);
          }
          public static void registrar()
          {
              try
              {
                  collectionDB = mongoDB.GetCollection<Usuario>("usuarios");
                  Usuario usuario = new Usuario() { Name = "jonathan", Password = "123", Username = "jon", ListaRefs = null };
                  collectionDB.InsertOne(usuario);

              }
              catch (Exception ex) { Console.Write(ex.Message); }
          }
      }
       /* private static readonly SqlConnection sqlServerDB = SQLServerDB.sqlConection();
        static void main(string[] args)
        {
            try
            {
                SQLServerDB.abrirConexion();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlServerDB;
                command.CommandType = CommandType.Text;
                command.CommandText = "select *from usuario";
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Console.Write(sqlDataReader[0]);
                }

                SQLServerDB.cerrarConexion();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
    }*/
}
