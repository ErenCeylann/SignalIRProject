namespace SignalRWebUI.Dtos.RapidApiDto
{
    public class RootTastyApi
    {
        public List<ResultTastyApi> Results { get; set; }
    }
    public class ResultTastyApi
    {
        public string name { get; set; }
        public string thumbnail_url { get; set; }
        public string video_url { get; set; }
        public string language { get; set; }
    }
}
