namespace SWGalacticArchives.Models
{

    public class Root<T>
    {
        public string message { get; set; }
        public Result<T> Result { get; set; }
        public string apiVersion { get; set; }
        public DateTime Timestamp { get; set; }

        public string total_records { get; set; }

        public string total_pages { get; set; }

        public string previous { get; set; }

        public string next { get; set; }

        public List<Result<T>> Results {get;set; }

    }

}
