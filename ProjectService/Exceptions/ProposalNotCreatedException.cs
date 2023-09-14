namespace ProjectService.Exceptions
{
    public class ProposalNotCreatedException:ApplicationException
    {
        public ProposalNotCreatedException() { }
        public ProposalNotCreatedException(string message) : base(message) { }

    }
}
