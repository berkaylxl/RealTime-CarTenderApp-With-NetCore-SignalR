namespace WebClient.Models.DeserializeModels
{
    public class RegisterData
    {
        public List<string> data { get; set; }
        public int status { get; set; }
        public object message { get; set; }
        public object exception { get; set; }
    }
}
