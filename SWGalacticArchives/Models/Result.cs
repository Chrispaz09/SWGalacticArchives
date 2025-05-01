namespace SWGalacticArchives.Models
{

    public class Result<T>
    {
        public T Properties { get; set; }

        public string _id { get; set; }

        public string Description { get; set; }

        public string Uid { get; set; }

        public int __v { get; set; }

        public string name { get; set; }

        public string url { get; set; }
    }

}
