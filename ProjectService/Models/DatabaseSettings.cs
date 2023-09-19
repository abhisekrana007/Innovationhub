namespace ProjectService.Models
{
    public class DatabaseSettings :IDatabaseSettings
    {
        public string? ProposalsCollectionName { get; set; }
        public string? ProjectsCollectionName { get; set; }
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        


    }
    public interface IDatabaseSettings
    {

        public string? ProposalsCollectionName { get; set; }
        public string? ProjectsCollectionName { get; set; }
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
    }
}
