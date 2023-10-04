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
    //[Authorize]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalService _proposalservice;

        public ProposalController(IProposalService proposalService)
        {
            _proposalservice = proposalService;
        }

        [HttpGet("project/{projectId}")]
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
        [HttpGet("experts/{expertid}")]

        public ActionResult GetProposalsBYExpertid(string expertid)
        {
            try
            {
                var result = _proposalservice.GetAllProposalByExpertId(expertid);
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

        public ActionResult StatusUpdate(string proposalid,string status)
        {

            try
            {
                var result = _proposalservice.StatusUpdate(proposalid,status);
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
