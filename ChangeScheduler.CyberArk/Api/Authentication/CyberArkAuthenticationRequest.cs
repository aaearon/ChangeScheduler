namespace ChangeScheduler.CyberArk.Api
{
    public class CyberArkAuthenticationRequest
    {
        public CyberArkAuthenticationRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public CyberArkAuthenticationRequest()
        {

        }

        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool ConcurrentSession { get; set; } = true;
    }
}
