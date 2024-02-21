public class ProductsController : ApiController
{
    [HttpGet]
    public async Task<IHttpActionResult> GetProductAsync(int id)
    {
        using (var dbContext = new MyDbContext())
        {
            var productEntity = await dbContext.Products.FindAsync(id);

            if (productEntity == null)
            {
                return NotFound();
            }

            var productDto = productEntity.Adapt<ProductDto>();

            var response = new ApiResponse<ProductDto>
            {
                Success = true,
                Data = productDto
            };

            return Ok(response);
        }
    }
}


// public class ApiResponse<T>
// {
//     public bool Success { get; set; }
//     public T Data { get; set; }
//     public string ErrorMessage { get; set; }
// }
