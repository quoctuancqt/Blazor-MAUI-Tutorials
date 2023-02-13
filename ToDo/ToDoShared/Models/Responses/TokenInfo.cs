namespace ToDoShared.Models.Responses
{
    public class TokenInfo
    {
        public string AccessToken { get; set; }
        public int Expires { get; set; }
        public string RefreshToken { get; set; }
        public string TokenType { get; set; }
    }
}
