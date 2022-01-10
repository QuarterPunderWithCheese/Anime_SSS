using System.Collections.Generic;
using DomainModel.Entities;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace DomainServices.Services
{
    public class AdminLogsService
    {
        /*
                public IGridFSBucket gridFS;   // файловое хранилище
                public IMongoCollection<AdminLog> Logs;
        
                public AdminLogsService()
                {
                    string connectionString = "mongodb://localhost:27017/";
                    var connection = new MongoUrlBuilder(connectionString);
                    // получаем клиента для взаимодействия с базой данных
                    MongoClient client = new MongoClient(connectionString);
                    // получаем доступ к самой базе данных
                    IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
                    // получаем доступ к файловому хранилищу
                    gridFS = new GridFSBucket(database);
                    Logs = database.GetCollection<AdminLog>("AdminLogs");
        
                }
                
                
                
        
                public void Create(AdminLog adminLog) => Logs.InsertOne(adminLog);
        
                public List<AdminLog> Get() => Logs.Find(AdminLogs => true).ToList();
            }
        */
    }
}