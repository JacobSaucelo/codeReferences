using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace YourNamespace.Controllers
{
    public class YourModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class YourController : ApiController
    {
        private IHttpActionResult CreateResponse(object data, string message, bool success)
        {
            return Content(HttpStatusCode.BadRequest, new
            {
                message = message,
                success = success,
                data = data
            });
        }

        [HttpPost]
        public IHttpActionResult ValidateAndSaveData(YourModel model)
        {
            if (model == null)
            {
                return CreateResponse(null, "Request body cannot be empty", false);
            }

            if (model.Id <= 0)
            {
                return CreateResponse(null, "Id is required and must be greater than zero", false);
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                return CreateResponse(null, "Name is required", false);
            }

            if (string.IsNullOrEmpty(model.Type))
            {
                return CreateResponse(null, "Type is required", false);
            }

        
            return Ok(new { message = "Data successfully validated", success = true, data = model });
        }
    }
}
