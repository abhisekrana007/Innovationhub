using ProjectService.Models;

namespace ProjectService.Repository
{
    public interface IProposalRepo
    {

        bool CreateProposal(Proposal proposal);
        bool DeleteProposal(string proposalId);
        bool UpdateProposal(Proposal proposal);
        List<Proposal> GetAllProposalByProjectId(string projectid );
       


    }
}
