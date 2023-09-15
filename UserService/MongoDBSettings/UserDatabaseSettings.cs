namespace UserService.MongoDBSettings
{
    public class UserDatabaseSettings : IUserDatabaseSettings
    {
        public string InnovatorsCollectionName { get; set; }
        public string ExpertsCollectionName { get; set; }
        public string ExpertFeedbacksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }


    }

    public interface IUserDatabaseSettings
    {
        public string InnovatorsCollectionName { get; set; }
        public string ExpertsCollectionName { get; set; }
        public string ExpertFeedbacksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

}



