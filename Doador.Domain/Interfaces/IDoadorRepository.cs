using Doador.Domain.Command;
using System.Collections;

namespace Doador.Domain.Interfaces
{
    public interface IDoadorRepository
    {
        Task<string> PostAsync(DoadorCommand command);
        Task<IEnumerable<DoadorCommand>> GetAsync();
    }
}
