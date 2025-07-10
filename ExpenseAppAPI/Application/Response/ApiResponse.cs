namespace ExpenseAppAPI.Application.Response
{
    public class ApiResponse<T>
    {
        public string StatusMessage { get; set; }
        public T Data { get; set; }

        public ApiResponse(string statusMessage, T data)
        {
            StatusMessage = statusMessage;
            Data = data;
        }
    }
}
