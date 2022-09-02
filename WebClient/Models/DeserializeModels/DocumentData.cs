namespace WebClient.Models.DeserializeModels
{
    public class DocumentData
    {
        public List<DocumentDataPart> data { get; set; }
        public int status { get; set; }
        public string message { get; set; }
        public object exception { get; set; }
    }

    public class DocumentDataPart
    {
        public string id { get; set; }
        public string carId { get; set; }
        public string createByUserId { get; set; }
        public string url { get; set; }
        public string fileName { get; set; }
        public DateTime createDate { get; set; }
        public bool isActive { get; set; }
        public int documentType { get; set; }
    }


}
