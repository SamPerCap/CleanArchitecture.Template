namespace Domain.Common
{
    public abstract class AuditBase
    {
        public int UserId_Created { get; set; }
        public DateTimeOffset DateTime_Created { get; set; }
        public int? UserId_Changed { get; set; }
        public DateTimeOffset? DateTime_Changed { get; set; }
    }
}
