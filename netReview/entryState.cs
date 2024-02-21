using System.Linq;
using System.Data.Entity;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class ProductService
{
    private readonly MyDbContext dbContext;

    public ProductService(MyDbContext context)
    {
        dbContext = context;
    }

    public void UpdateProductPrice(int productId, decimal newPrice)
    {
        var product = dbContext.Products.FirstOrDefault(p => p.Id == productId);

        if (product != null)
        {
            product.Price = newPrice;

            // get entry
            var entry = dbContext.Entry(product);

            // modify entry
            entry.State = EntityState.Modified;

            dbContext.SaveChanges();
        }
    }
}

