namespace ChangeScheduler.CyberArk.Api
{
    public interface ICyberArkApiSessionClient
    {
        Task<string> GetSessionTokenAsync();
        void ClearSessionToken();
    }
}
