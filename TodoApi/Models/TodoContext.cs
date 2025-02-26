using MongoDB.Driver;
using Microsoft.Extensions.Options;
using TodoApi.Models;

namespace TodoApi.Models
{
    public class TodoContext
    {
        private readonly IMongoDatabase _database;

        public TodoContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<TodoItem> TodoItems => 
            _database.GetCollection<TodoItem>("TodoItems");
            
        public IMongoCollection<Estadisticas> Estadisticas => 
            _database.GetCollection<Estadisticas>("Estadisticas");
    }
}
