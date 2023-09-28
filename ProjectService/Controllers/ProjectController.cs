using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Exceptions;
using ProjectService.Models;
using ProjectService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectServices _projectService;
        public ProjectController(IProjectServices projectService)
        {
            _projectService = projectService;

        }
        // GET: api/ProjectController
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _projectService.GetAllAsyc();
            return Ok(projects);
        }

        // GET api/ProjectController/5
        [HttpGet("projects/{projectId}")]
        public async Task<IActionResult> Get(string projectId)
        {
            var project = await _projectService.GetById(projectId);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpGet("[action]/{innovatorId}")]
        public IActionResult GetByInnovatorId(string innovatorId)
        {
            var project =  _projectService.GetByInnoId(innovatorId);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        // POST api/ProjectController
        [HttpPost]
        public async Task<IActionResult> Post(Project project)
        {
            await _projectService.CreateAsync(project);
            return Ok("Created successfully");
        }

        // PUT api/ProjectController/5
        [HttpPut("{projectId}")]
        public async Task<IActionResult> Put(string projectId, [FromBody] Project newproject)
        {
            var project = await _projectService.GetById(projectId);
            if (project == null)
                return NotFound();

            await _projectService.UpdateAsync(projectId, newproject);
            return Ok("Updated successfully");
        }

        // DELETE api/ProjectController/5
        [HttpDelete("{projectId}")]
        public async Task<IActionResult> Delete(string projectId)
        {
            var project = await _projectService.GetById(projectId);
            if (project == null)
                return NotFound();
            await _projectService.DeleteAysnc(projectId);
            return Ok("deleted Successfully");
        }

        [HttpGet("[action]/{proposalid}")]

        public IActionResult GetAccepetedProposal(List<Proposal> proposals,string proposalid)
        {
            var obj = _projectService.GetAcceptedProposal(proposals, proposalid);
            return Ok(obj);

        }

        [HttpGet("[action]/{expertid}")]

        public IActionResult GetByExpertId(string expertid)
        {
            var obj=_projectService.GetByExpertID(expertid);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpPut("update/{projectid}")]

        public ActionResult StatusUpdate(string projectid)
        {

            try
            {
                var result = _projectService.StatusUpdate(projectid);
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
