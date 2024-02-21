public class MyController : ApiController
{
    private readonly IDbContext dbContext;
    private readonly IExternalServiceClient externalServiceClient;

    public MyController(IDbContext dbContext, IExternalServiceClient externalServiceClient)
    {
        this.dbContext = dbContext;
        this.externalServiceClient = externalServiceClient;
    }

    [HttpGet]
    public IHttpActionResult GetData()
    {
        var dataFromDb = dbContext.GetData();
        var dataFromExternalService = externalServiceClient.GetData();

        return Ok(new { DataFromDb = dataFromDb, DataFromExternalService = dataFromExternalService });
    }

}
