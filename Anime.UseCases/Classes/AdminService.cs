using System.Linq;
using System.Threading.Tasks;
using DomainModel.Entities;
using Microsoft.AspNetCore.Identity;

namespace DomainServices.Classes
{
    public class AdminService:IAdminService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _manager;
        private readonly RoleManager<IdentityRole> _role;

        public AdminService(AppDbContext context, UserManager<User> manager, RoleManager<IdentityRole> role)
        {
            _context = context;
            _manager = manager;
            _role = role;
        }


        public async Task<bool> TryAddToRole(string Email, string role)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == Email);
            if (user == null) return false;
            await _manager.AddToRoleAsync(user, role);
            return true;
        }
    }
}