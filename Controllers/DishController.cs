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
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Dish body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody]Dish body)
        {
            await Db.Connection.OpenAsync();
            var query = new DishQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Name = body.Name;
            result.DishType = body.DishType;
            result.DishStatus = body.DishStatus;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new DishQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new DishQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }
    }
}