using Sample.Domain;
using Sample.Persistence.Context;

namespace Sample.Application.Services
{
    public class UserService
    {
        private MultiTenantContext _context;

        public UserService(MultiTenantContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
