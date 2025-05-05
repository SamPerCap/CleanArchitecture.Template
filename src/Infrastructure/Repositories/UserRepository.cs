using Application.Common.Interfaces.Repositories;
using Domain.Entities.UserEntity;
using Infrastructure.Data;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddValueAsync(User value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByConditionAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetValueByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync([id], cancellationToken);
        }

        public Task RemoveValueAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateValueAsync(User value)
        {
            throw new NotImplementedException();
        }
    }
}
