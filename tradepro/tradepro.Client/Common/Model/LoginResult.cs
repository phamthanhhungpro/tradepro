namespace tradepro.Client.Common.Model
{
    public class LoginResult
    {
        public string tokenType { get; set; }
        public string accessToken { get; set; }
        public int expiresIn { get; set; }
        public string refreshToken { get; set; }

    }
}
