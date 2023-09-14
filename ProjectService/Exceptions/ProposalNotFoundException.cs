namespace ProjectService.Exceptions
{
    public class ProposalNotFoundException:ApplicationException
    {
        public ProposalNotFoundException() { }
        public ProposalNotFoundException(string message) : base(message) { }


    }
}
