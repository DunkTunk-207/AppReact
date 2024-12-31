using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppProject.WebApi.Services;
using AppProject.Core.Models.Project;
using Microsoft.AspNetCore.Mvc;
using AppProject.WebApi.Services.Interfaces;
using AutoMapper;

namespace AppProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/projects")]
    [Produces("application/json")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectController> _logger;


        public ProjectController(IProjectService projectService, IMapper mapper, ILogger<ProjectController> logger)
        {
            _projectService = projectService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProjectDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProjectDto>> CreateNewProjectAsync([FromBody] CreateProjectRequest request)
        {
            _logger.LogInformation("Create new request: {ProjectName}", request.Name);

            if (!ModelState.IsValid)
                throw new ArgumentException("Invalid model state");

            var project = await _projectService.CreateAsync(request);
            var projectDto = _mapper.Map<ProjectDto>(project);
            _logger.LogInformation("Create Successfully: {ProjectId}", project.Id);

            return Ok(projectDto);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjectDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjectAsync()
        {
            _logger.LogInformation("Getting all projects");
            var projects = await _projectService.GetAllProjectAsync();
            var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            _logger.LogInformation("Retrieved {Count} projects", projectDtos.Count());
            
            return Ok(projectDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProjectDto>> GetOneProjectAsync(Guid id)
        {
            _logger.LogInformation("Getting project with ID: {ProjectId}", id);
            var project = await _projectService.GetOneProjectAsync(id);
            if (project == null)
                throw new KeyNotFoundException($"Project with ID {id} not found");

            _logger.LogInformation("Retrieved project: {ProjectId}", id);
            
            return Ok(project);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteProjectAsync(Guid id)
        {
            _logger.LogInformation("Deleting project: {ProjectId}", id);
            var result = await _projectService.DeleteProjectAsync(id);
            if (!result)
                throw new KeyNotFoundException($"Project with ID {id} not found");

            _logger.LogInformation("Project deleted: {ProjectId}", id);
            
            return NoContent();
        }
    }
}
