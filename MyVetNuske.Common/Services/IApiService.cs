using MyVetNuske.Common.Models;
using System.Threading.Tasks;

namespace MyVetNuske.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetOwnerByEmailAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);

        Task<Response> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);
    }
}
