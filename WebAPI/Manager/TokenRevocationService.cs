namespace WebAPI.Manager
{
    public class TokenRevocationService
    {
        private HashSet<string> revokedTokens = new HashSet<string>();

        public void RevokeToken(string token)
        {
            revokedTokens.Add(token);
        }

        public bool IsTokenRevoked(string token)
        {
            return revokedTokens.Contains(token);
        }
    }
}
