using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pagination.Filter;
using Pagination.Model;
using Pagination.Wrapers;

namespace Pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }

        [HttpGet("getProduct")]
        public async Task<IActionResult> GetProduct([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pageData = await _context.Products.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize).ToListAsync();
           var totalRecords=await _context.Products.CountAsync();   

            return Ok(new PagedResponse<List<Product>>(pageData,validFilter.PageNumber,validFilter.PageSize,totalRecords));
        }
    }
}
