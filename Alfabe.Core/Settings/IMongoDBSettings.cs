namespace Alfabe.Core
{
    public interface IMongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
 
    }
}