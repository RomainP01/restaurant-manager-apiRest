using System.Threading.Tasks;
using APIRestDotNet.Utils;
using Microsoft.AspNetCore.Mvc;

namespace APIRestDotNet.Controllers
{
    [Route("api/[controller]")]
    public class DishController : ControllerBase
    {
        public AppDb Db { get; }
        public DishController(AppDb db)
        {
            Db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Db.Connection.OpenAsync();
            var query = new DishQuery(Db);
            var result = await query.GetAllDishesAsync();
            return new OkObjectResult(result);
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new DishQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}