namespace InterviewTest.Services
{
    public class ServiceParam
    {
        public ServiceParam(string connectionString,
            int pageSize,
            int displaySum) {

            ConnectionString = connectionString;
            PageSize = pageSize;
            DisplaySum = displaySum;
        }
        public readonly string ConnectionString;
        public readonly int PageSize;
        public readonly int DisplaySum;
    }
}
