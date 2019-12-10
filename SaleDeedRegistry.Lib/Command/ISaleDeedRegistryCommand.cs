using SaleDeedRegistry.Lib;
using System.Threading.Tasks;

namespace SaleDeedRegistry.Lib.Command
{
    public interface ISaleDeedRegistryCommand
    {
        Task<CommandResponse> Execute(SaleDeedRegistryBaseRequest requestObject);
    }
}
