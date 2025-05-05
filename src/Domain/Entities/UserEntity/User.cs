using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.UserEntity
{
    public class User : IdentityUser<int>
    {
        public required string Phone { get; set; }
        public required string PrefixPhone { get; set; }


        [MaxLength(200)]
        public string? Description { get; set; }
        public string? Address { get; set; }

        public DateOnly? Birthday { get; set; }

        public ICollection<UserTokenSession> TokenSessions { get; set; } = [];
        
        public bool PhoneConfirmed { get; set; }
    }
}
