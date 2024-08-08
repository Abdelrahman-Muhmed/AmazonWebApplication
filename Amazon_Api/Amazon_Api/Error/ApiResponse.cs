
namespace Amazon_Api.Error
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int status , string? message = null)
        {

            Status = status;
            Message = message ?? GetDeafualtMessage(status);

        }

        private string? GetDeafualtMessage(int status)
        {
            //Using Switch Case in .Net8
            return status switch
            {
                400 => "Bad Request",
                404 => "Not Found",
                401 => "UnAuthrized",
                500 => "Error 500",
                _ => null,
            };
        }
    }
}
