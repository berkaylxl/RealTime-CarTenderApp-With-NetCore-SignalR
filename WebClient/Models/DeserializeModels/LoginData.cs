namespace WebClient.Models.DeserializeModels
{
    public class LoginData
    {
        public LoginDataPart data { get; set; }
        public int status { get; set; }
        public string? message { get; set; }
        public object? exception { get; set; }
    }
    public class LoginDataPart
    {
        public string? token { get; set; }
        public DateTime time { get; set; }
    }
}
