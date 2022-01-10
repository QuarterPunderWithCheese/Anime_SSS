using System.Threading.Tasks;

namespace DomainServices
{
    public interface IAdminService
    {
        public Task<bool> TryAddToRole(string Email, string role);
    }
}