using System.Threading.Tasks;
using System.Web.Http;
using Mapster;

public class ProductsController : ApiController
{
    private readonly ApplicationDbContext _context;

    public ProductsController()
    {
        _context = new ApplicationDbContext();
    }

    [HttpGet]
    public async Task<IHttpActionResult> GetProductAsync(int id)
    {
        var productEntity = await _context.Products.FindAsync(id);

        if (productEntity == null)
        {
            return NotFound(); 
        }

        var productDto = productEntity.Adapt<ProductDto>();

        return Ok(productDto);
    }
}
