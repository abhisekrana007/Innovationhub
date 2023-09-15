using ProjectService.Models;

namespace ProjectService.services
{
    public interface IProposalService
    {

        bool CreateProposal(Proposal proposal);
        bool DeleteProposal(string proposalId);
        bool UpdateProposal(Proposal proposal);
        List<Proposal> GetAllProposalByProjectId(string projectid);
        bool StatusUpdate(Proposal proposal);
    }
}
