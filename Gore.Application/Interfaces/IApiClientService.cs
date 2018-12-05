using Gore.Application.ViewModels;
using System.Threading.Tasks;

namespace Gore.Application.Interfaces
{
    public interface IApiClientService
    {
        Task<AddressViewModel> GetCepAsync(string cep);
    }
}
