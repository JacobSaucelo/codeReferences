public class MyController : ApiController
{
    [HttpGet]
    public async Task<IHttpActionResult> GetAsync(int id)
    {
        using (var dbContext = new MyDbContext())
        {
            var entity = await dbContext.Entities.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }

    [HttpPost]
    public async Task<IHttpActionResult> PostAsync(MyEntity entity)
    {
        using (var dbContext = new MyDbContext())
        {
            dbContext.Entities.Add(entity);
            await dbContext.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }
    }

    [HttpPut]
    public async Task<IHttpActionResult> PutAsync(int id, MyEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        using (var dbContext = new MyDbContext())
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok(entity);
        }
    }

    [HttpDelete]
    public async Task<IHttpActionResult> DeleteAsync(int id)
    {
        using (var dbContext = new MyDbContext())
        {
            var entity = await dbContext.Entities.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            dbContext.Entities.Remove(entity);
            await dbContext.SaveChangesAsync();
            return Ok(entity);
        }
    }
}
