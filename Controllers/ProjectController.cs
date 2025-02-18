using Buisness.Services;
using Buisness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataStorage.Contexts;

namespace Presentation.ConsoleApp.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;


        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectRegistrationForm form)
        {
            if (form == null || string.IsNullOrWhiteSpace(form.Title))
            {
                return BadRequest("Invalid project data.");
            }

            var success = await _projectService.CreateProjectAsync(form);
            if (!success)
            {
                return BadRequest("Project could not be created.");
            }

            return CreatedAtAction(nameof(GetProjectById), new { id = form.Title }, form);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound("Project not found.");
            }

            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Project updatedProject)
        {

            if (updatedProject == null || string.IsNullOrWhiteSpace(updatedProject.Title))
            {
                return BadRequest("Invalid project data.");
            }

            if (updatedProject.Id != id)
            {
                return BadRequest("Mismatch between URL ID and body ID.");
            }

            var success = await _projectService.UpdateProjectAsync(updatedProject);
            if (!success)
            {
                return NotFound($"Project with ID {id} not found.");
            }

            return Ok("Project updated successfully!");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var success = await _projectService.DeleteProjectAsync(id);
            if (!success)
            {
                return NotFound("Project not found.");
            }

            return Ok("Project deleted successfully!");
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetProjectDetails(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound("Project not found.");
            }

            return Ok(new
            {
                project.ProjectNumber,
                project.Title,
                project.Description,
                project.StartDate,
                project.EndDate,
                project.CustomerId,
                project.StatusId
            });
        }
    }
}
