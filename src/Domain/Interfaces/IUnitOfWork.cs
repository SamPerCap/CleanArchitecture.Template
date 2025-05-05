namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region repositories
        #endregion
        
        Task<int> CommitAsync();
    }
}
