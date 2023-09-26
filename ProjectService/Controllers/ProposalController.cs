using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Conventions;
using ProjectService.Exceptions;
using ProjectService.Models;
using ProjectService.services;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalService _proposalservice;

        public ProposalController(IProposalService proposalService)
        {
            _proposalservice = proposalService;
        }

        [HttpGet("{projectId}")]
        public ActionResult GetByProjectId(string projectId)
        {
            try
            {
                var result = _proposalservice.GetAllProposalByProjectId(projectId);
                return Ok(result);
            }
            catch (ProposalNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }




        }
        [HttpGet]
        public ActionResult GetAllProposal()
        {
            try
            {
                var result = _proposalservice.GetAllProposal();
                return Ok(result);
            }
            catch (ProposalNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public ActionResult Create([FromBody] Proposal proposal)
        {
            try
            {
                var result = _proposalservice.CreateProposal(proposal);
                return Created("Proposal Created", result);
            }
            catch (ProposalNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{proposalId}")]

        public ActionResult Edit(string proposalId, [FromBody] Proposal proposal)
        {
            try
            {
                var result = _proposalservice.UpdateProposal(proposalId, proposal);
                return Ok(result);
            }
            catch (ProposalNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{proposalId}")]

        public ActionResult Delete(string proposalId)
        {
            try
            {
                var result = _proposalservice.DeleteProposal(proposalId);
                return Ok(result);
            }
            catch (ProposalNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{proposalid}")]

        public ActionResult StatusUpdate(string proposalid)
        {

            try
            {
                var result = _proposalservice.StatusUpdate(proposalid);
                return Created("Status Updated", result);
            }
            catch (ProposalNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



    }


}
