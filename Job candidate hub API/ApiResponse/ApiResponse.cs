using Microsoft.AspNetCore.Http;

namespace Job_candidate_hub_API.ApiResponse
{
    public class ApiResponse<T>
    {
        public T ResponseData { get; set; }
        public bool? IsValidResponse { get; set; }
        public string CommandMessage { get; set; }
        public List<string> Errors { get; set; }
        public ApiResponse<T> SuccessResult(T data, string message, bool? isValidResponse)
        {
            ResponseData = data;
            CommandMessage = message;
            IsValidResponse = isValidResponse;
            return this;
        }

        public ApiResponse<T> FailedResult(T data, List<string> errors, bool? isValidResponse)
        {
            ResponseData = data;
            Errors = errors;
            IsValidResponse = isValidResponse;
            return this;
        }
    }

}
