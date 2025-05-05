using Domain.Common;

namespace Domain.Entities.UserEntity
{
    public class UserTokenSession : EntityBase
    {
        public required string RefreshToken { get; set; }
        
        public string? DeviceInfo { get; set; }
        public string? IpAddress { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }
        
        public DateTimeOffset? RevokedAt { get; set; }
        
        public bool IsRevoked { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
