namespace UserService.MongoDBSettings
{
    public class InnovatorDatabaseSettings : IInnovatorDatabaseSettings
    {

        public string InnovatorsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }


    }

    public interface IInnovatorDatabaseSettings
    {
        public string InnovatorsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

}
