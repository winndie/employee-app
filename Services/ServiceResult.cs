namespace InterviewTest.Services
{
    public class ServiceResult<T> where T : new()
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; } = new T();

        public ServiceResult(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        public ServiceResult()
        {
            IsSuccess = false;
        }
    }
}
