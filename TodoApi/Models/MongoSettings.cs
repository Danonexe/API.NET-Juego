using MongoDB.Driver;
using Microsoft.Extensions.Options;
using TodoApi.Models;

namespace TodoApi.Models
{
public class MongoSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
}