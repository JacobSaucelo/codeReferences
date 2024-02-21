using System.Threading.Tasks;
using System.Web.Http;
using MyProject.Models; // dto import

public class MyController : ApiController
{
    private readonly MyDbContext _dbContext;

    public MyController()
    {
        _dbContext = new MyDbContext();
    }

    [HttpGet]
    public async Task<IHttpActionResult> GetAsync(int id)
    {
        var entity = await _dbContext.MyEntities.FindAsync(id);

        if (entity == null)
        {
            return NotFound();
        }

        var dto = MapToDTO(entity);

        return Ok(dto); // Return DTO with 200 OK
    }

    private MyEntityDTO MapToDTO(MyEntity entity)
    {
        var dto = new MyEntityDTO
        {
            Id = entity.Id,
            // Firstname = entity.Firstname,
            // Lastname = entity.Lastname,
            // Email = entity.Email,
            // Description = entity.Description,
        };

        return dto;
    }

// old dispose
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose(); 
        }
        base.Dispose(disposing);
    }
}
