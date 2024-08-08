using Amazon_Api.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon_Api.Controllers
{
    [Route("ErrorEndPoint/{code}")]
    [ApiController]
    //I will Add Ignor For Ignore Ui Request 
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorEndPointController : ControllerBase
    {
       
        public ActionResult getNotFound(int code)
        {
            if(code == 401)
            {
                return Unauthorized(new ApiResponse(401));
            }

            return NotFound(new ApiResponse(404));
        }
    }
}
