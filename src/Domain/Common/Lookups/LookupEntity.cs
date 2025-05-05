namespace Domain.Common.Lookups
{
    public abstract class LookupEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
