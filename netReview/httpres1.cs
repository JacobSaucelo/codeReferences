using System.Threading.Tasks;
using System.Web.Http;

public class MyController : ApiController
{
    [HttpGet]
    public async Task<IHttpActionResult> GetAsync()
    {
        var result = await AsyncFunction();

        if (result != null)
        {
            // return 200 successssss
            return Ok(result); 
        }
        else
        {
            return NotFound(); 
        }
    }

    private async Task<object> AsyncFunction()
    {
        // async delay
        await Task.Delay(1000);
        return new { Message = "Data retrieved successfully" };
    }
}
