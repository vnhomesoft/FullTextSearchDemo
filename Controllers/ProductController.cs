using FulltextSearchDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullTextSearchDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly AppDbContext _context;

    public ProductController (
        ILogger<ProductController> logger,
        AppDbContext context
        )
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IEnumerable<Product> Search(string text)
    {
        return _context.Products
            .Where( p => p.SearchVector.Matches( text ) )
            .ToList();
    }
}
