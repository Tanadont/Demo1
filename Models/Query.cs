namespace Demo1.Models
{
    public class Query
    {
        public string Search { get; set; } = "";
        public int Limit { get; set; }
        public int Skip { get; set; }
    }
}
