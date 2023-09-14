namespace UserService.MongoDBSettings
{
    public class ExpertDatabaseSettings : IExpertDatabaseSettings
    {

        public string ExpertsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }


    }

    public interface IExpertDatabaseSettings
    {
        public string ExpertsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

}

