namespace Application.Common.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PrefixPhone { get; set; } = default!;
        public string Phone { get; set; } = default!;

        public DateTime Birthday { get; set; }

        public bool PhoneConfirmed { get; set; }
    }
}