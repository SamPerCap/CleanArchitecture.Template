using Domain.Entities.UserEntity;
using Domain.Interfaces;

namespace Application.Common.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
