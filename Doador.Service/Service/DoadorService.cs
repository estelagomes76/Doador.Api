using Doador.Domain.Command;
using Doador.Domain.Interfaces;
using Doador.Repository.Repository;

namespace Doador.Service.Service
{
    public class DoadorService : IDoadorService
    {
        private readonly IDoadorRepository _doadorRepository;
        
        public DoadorService(IDoadorRepository doadorRepository)
        {
            _doadorRepository = doadorRepository;
        }

        public async Task<string> PostAsync(DoadorCommand command)
        {
            return await _doadorRepository.PostAsync(command);
        }
        public async Task<IEnumerable<DoadorCommand>> GetAsync()
        {
            return await _doadorRepository.GetAsync();
        }
    }

}
