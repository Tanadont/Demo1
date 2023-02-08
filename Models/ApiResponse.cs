namespace Demo1.Models
{
    public class ApiResponse
    {
        public string statusCode { get; set; }
        public string error { get; set; }
        public string message { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int totalRecords { get; set; }
        public dynamic data { get; set; }
    }
}
