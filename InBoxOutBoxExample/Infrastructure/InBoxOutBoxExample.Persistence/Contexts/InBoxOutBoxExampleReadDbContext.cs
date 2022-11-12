using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace InBoxOutBoxExample.Persistence.Contexts
{
    public class InBoxOutBoxExampleReadDbContext
    {
        private readonly IMongoDatabase _database;

        public InBoxOutBoxExampleReadDbContext(IConfigurationSection section)
        {
            string Host = section["Host"];
            int Port = Int32.Parse(section["Port"]);
            string Database = section.GetSection("Database").Value;

            MongoClient client = new MongoClient($"mongodb://{Host}:{Port}");
            _database = client.GetDatabase(Database);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name.ToLower()+"s");
        }
    }
}
