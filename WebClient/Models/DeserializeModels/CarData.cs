namespace WebClient.Models.DeserializeModels
{
    public class CarData
    {
            public List<CarDataPart> data { get; set; }
            public int status { get; set; }
            public string message { get; set; }
            public object exception { get; set; }

        public class CarDataPart
        {
            public string id { get; set; }
            public string plate { get; set; }
            public string plateState { get; set; }
            public string chassisNumber { get; set; }
            public string brand { get; set; }
            public string model { get; set; }
            public int year { get; set; }
            public int engineSize { get; set; }
            public string fuelType { get; set; }
            public string gear { get; set; }
            public int mileage { get; set; }
            public string location { get; set; }
            public string description { get; set; }
            public List<DocumentDataPart> document { get; set; }
        }

    }
}
