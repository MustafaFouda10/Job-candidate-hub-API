namespace Job_candidate_hub_API.ApiResponse
{
    public class ApiResponse<T>
    {
        public T ResponseData { get; set; }
        public bool? IsValidResponse { get; set; }
        public string CommandMessage { get; set; }
        public ApiResponse<T> SetResult(T data, string message, bool? isValidResponse)
        {
            ResponseData = data;
            CommandMessage = message;
            IsValidResponse = isValidResponse;
            return this;
        }
    }

}
