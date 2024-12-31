using AppProject.Core.Models.Project;
using Microsoft.AspNetCore.Mvc;
using AppProject.WebApi.Services.Interfaces;
using AppProject.WebApi.Models.Client;

namespace AppProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewClientAsync([FromBody] CreateClientRequest request)
        {
            var data = _clientService.CreateAsync(request);

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientAsync()
        {
            var data = _clientService.GetAllClientAsync();

            return Ok(data);
        }
    }
}
