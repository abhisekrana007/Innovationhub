namespace UserService.MongoDBSettings
{
    public class UserDatabaseSettings : IUserDatabaseSettings
        {

            public string UsersCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }


        }

        public interface IUserDatabaseSettings
        {
            public string UsersCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }

        }

    }

