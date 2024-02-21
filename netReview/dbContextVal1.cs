public class ProductsController : ApiController
{
    [HttpPost]
    public async Task<IHttpActionResult> CreateProductAsync(ProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var productEntity = productDto.Adapt<Product>();

        using (var dbContext = new MyDbContext())
        {
            dbContext.Products.Add(productEntity);
            await dbContext.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = productEntity.Id }, productEntity);
        }
    }

    [HttpPut]
    public async Task<IHttpActionResult> UpdateProductAsync(int id, ProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != productDto.Id)
        {
            return BadRequest();
        }

        using (var dbContext = new MyDbContext())
        {
            var existingProduct = await dbContext.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            dbContext.Entry(existingProduct).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok(existingProduct);
            }
        }

}
