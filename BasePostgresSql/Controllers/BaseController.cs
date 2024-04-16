using BasePostgresSql.Data;
using BasePostgresSql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasePostgresSql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;
        private readonly BaseDataContext _context;

        public BaseController(ILogger<BaseController> logger,
                              BaseDataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetBase")]
        public async Task<IActionResult> Get()
        {
            var base1 = new BaseModel()
            {
                Name = "test",
                Description = "testing"
            };
            _context.Add(base1);
            await _context.SaveChangesAsync();

            var allBases = await _context.BaseModels.ToListAsync();

            return Ok(allBases);
        }

    }
}