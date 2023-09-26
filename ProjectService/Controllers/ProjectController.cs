using Microsoft.AspNetCore.Mvc;
using ProjectService.Exceptions;
using ProjectService.Models;
using ProjectService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var project = await _projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpGet("[action]/{innovatoriD}")]
        public IActionResult GetbyInnoid(string innovatoriD)
        {
            var project =  _projectService.GetByInnoId(innovatoriD);
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Project newproject)
        {
            var project = await _projectService.GetById(id);
            if (project == null)
                return NotFound();

            await _projectService.UpdateAsync(id, newproject);
            return Ok("Updated successfully");
        }

        // DELETE api/ProjectController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var project = await _projectService.GetById(id);
            if (project == null)
                return NotFound();
            await _projectService.DeleteAysnc(id);
            return Ok("deleted Successfully");
        }

        [HttpGet("[action]/{proposalid}")]

        public IActionResult GetAccepetedProposal(List<Proposal> proposals,string proposalid)
        {
            var obj = _projectService.GetAcceptedProposal(proposals, proposalid);
            return Ok(obj);

        }

        [HttpGet("[action]/{expertid}")]

        public IActionResult GetProjectByExpertid(string expertid)
        {
            var obj=_projectService.GetByExpertID(expertid);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        //[HttpPut("update/{proposalid}")]

        //public ActionResult StatusUpdate(string proposalid)
        //{

        //    try
        //    {
        //        var result = _projectService.StatusUpdate(proposalid);
        //        return Created("Status Updated", result);
        //    }
        //    catch (ProposalNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}


    }
}
