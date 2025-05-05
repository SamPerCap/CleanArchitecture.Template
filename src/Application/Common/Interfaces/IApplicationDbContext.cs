using Domain.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        DbSet<UserTokenSession> TokenSessions { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
