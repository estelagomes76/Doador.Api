using Doador.Domain.Command;
using Doador.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Doador.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoadorController : ControllerBase
    {
        private readonly IDoadorService _doadorService;
        public DoadorController(IDoadorService doadorService)
        {
            _doadorService = doadorService;
        }
        [HttpPost]
        [Route("CriarCliente")]
        public async Task<string> PostAsync([FromBody] DoadorCommand command)
        {
           return await _doadorService.PostAsync(command);
        }
        [HttpGet]
        public async Task<IEnumerable<DoadorCommand>> GetAsync()
        {
            return await _doadorService.GetAsync();
        }
    }
}
