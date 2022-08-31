namespace WebClient.Models
{
    public class Data
    {
        public data data { get; set; }
        public int status { get; set; }
        public string? message { get; set; }
        public object? exception { get; set; }
    }

    public class data
    {
        public string? token { get; set; }
        public DateTime time { get; set; }
    }
}
