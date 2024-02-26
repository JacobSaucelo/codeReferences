public class PaginationResult<T>
{
    public int Count { get; set; }
    public string Next { get; set; }
    public string Previous { get; set; }
    public List<T> Results { get; set; }
}

[Route("api/items")]
public class ItemsController : ApiController
{
    [HttpGet]
    public IHttpActionResult GetItems(int limit = 10, int offset = 0)
    {
       
        var items = list

        var totalItemCount = int
        var nextPageUrl = offset + limit < totalItemCount ? Url.Link("DefaultApi", new { limit, offset = offset + limit }) : null;
        var prevPageUrl = offset - limit >= 0 ? Url.Link("DefaultApi", new { limit, offset = Math.Max(0, offset - limit) }) : null;

        var paginationResult = new PaginationResult<ItemViewModel>
        {
            Count = totalItemCount,
            Next = nextPageUrl,
            Previous = prevPageUrl,
            Results = items
        };

        return Ok(paginationResult);
    }
}

// PAGINATION TEMPLATE

using System.Linq;
using System.Data.Entity; 

public class ItemsController : ApiController
{
    private DbContext _context;

    public ItemsController()
    {
        _context = new DbContext(); 
    }

    [HttpGet]
    public IHttpActionResult GetItems(int limit = 10, int offset = 0)
    {
        var totalItemCount = _context.Items.Count(); 

        var items = _context.Items
                        .OrderBy(i => i.Id) 
                        .Skip(offset)
                        .Take(limit)
                        .ToList();

        var nextPageUrl = offset + limit < totalItemCount ? Url.Link("DefaultApi", new { limit, offset = offset + limit }) : null;
        var prevPageUrl = offset - limit >= 0 ? Url.Link("DefaultApi", new { limit, offset = Math.Max(0, offset - limit) }) : null;

        var paginationResult = new PaginationResult<ItemViewModel>
        {
            Count = totalItemCount,
            Next = nextPageUrl,
            Previous = prevPageUrl,
            Results = items
        };

        return Ok(paginationResult);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
        base.Dispose(disposing);
    }
}

// SEARCH TEMPLATE

using System.Linq;
using System.Data.Entity;
using System;

public class ItemsController : ApiController
{
    private DbContext _context;

    public ItemsController()
    {
        _context = new DbContext();
    }

    [HttpGet]
    public IHttpActionResult GetItems(string searchTerm = "", int limit = 10, int offset = 0)
    {
        IQueryable<Item> query = _context.Items;

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(item => item.Name.Contains(searchTerm));
        }

        var totalItemCount = query.Count(); 

        var items = query
                        .OrderBy(item => item.Id)
                        .Skip(offset)
                        .Take(limit)
                        .ToList();

        var nextPageUrl = offset + limit < totalItemCount ? Url.Link("DefaultApi", new { searchTerm, limit, offset = offset + limit }) : null;
        var prevPageUrl = offset - limit >= 0 ? Url.Link("DefaultApi", new { searchTerm, limit, offset = Math.Max(0, offset - limit) }) : null;

        var paginationResult = new PaginationResult<ItemViewModel>
        {
            Count = totalItemCount,
            Next = nextPageUrl,
            Previous = prevPageUrl,
            Results = items
        };

        return Ok(paginationResult);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
        base.Dispose(disposing);
    }
}



// https://imagecolorpicker.com/en

// https://undraw.co/search

// https://custicon.com/