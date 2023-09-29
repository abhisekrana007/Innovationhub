using ProjectService.Models;
using ProjectService.Repository;
using ProjectService.Exceptions;

namespace ProjectService.services
{
    public class ProposalService:IProposalService
    {

        private readonly IProposalRepo _repo;
        public ProposalService(IProposalRepo repo)
        {
            _repo = repo;
        }

        public bool CreateProposal(Proposal proposal)
        {
            var result = _repo.CreateProposal(proposal);
            if (!result)
            {
                throw new ProposalNotCreatedException("Proposal Already exists");
            }



            return result;
        }

        public bool DeleteProposal(string proposalId)
        {
            var result = _repo.DeleteProposal(proposalId);
            if (!result)
            {
                throw new ProposalNotFoundException("Proposal does not exist");
            }



            return result;



        }

        public bool UpdateProposal(string id, Proposal proposal)
        {
            var result = _repo.UpdateProposal(id,proposal);
            if (!result)
            {
                throw new ProposalNotFoundException("Proposal Not Found");
            }



            return result;
        }

       public List<Proposal> GetAllProposalByProjectId(string projectid)
        {
            var result = _repo.GetAllProposalByProjectId(projectid);
            if (result == null)
            {
                throw new ProposalNotFoundException("No proposal with this projectid");
            }
            return result;
        }

        public bool StatusUpdate(string proposalid,string status)
        {

            var result = _repo.StatusUpdate(proposalid,status);
            if (!result)
            {
                throw new ProposalNotFoundException("No accepted propsal came from innvoator side");


            }
            return result;

        }

        public List<Proposal> GetAllProposal()
        {
            var result = _repo.GetAllProposal();
            if (result == null)
            {
                throw new ProposalNotFoundException("No proposals found in database");
            }
            return result;
        }
        public List<Proposal> GetAllProposalByExpertId(string expertid)
        {
            var result = _repo.GetAllProposalByExpertId(expertid);
            if (result == null)
            {
                throw new ProposalNotFoundException("No proposal with this expertid");
            }
            return result;
        }








    }
}
