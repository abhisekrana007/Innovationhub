using ProjectService.Models;

namespace ProjectService.Repository
{
    public interface IProposalRepo
    {

        bool CreateProposal(Proposal proposal);
        bool DeleteProposal(string proposalId);
        bool UpdateProposal(string id,Proposal proposal);
        List<Proposal> GetAllProposalByProjectId(string projectid );
        bool StatusUpdate(string proposalid);
        List<Proposal> GetAllProposal();
        List<Proposal> GetAllProposalByExpertId(string expertid);



    }
}
