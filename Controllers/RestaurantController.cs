using System.Threading.Tasks;
using APIRestDotNet.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace APIRestDotNet.Controllers
{
    [Route("api/")]
    public class RestaurantController : ControllerBase
    {
        public AppDb Db { get; }
        public RestaurantController(AppDb db)
        {
            Db = db;
        }
        
        [HttpGet("dish/")]
        public async Task<IActionResult> GetAllDishes()
        {
            await Db.Connection.OpenAsync();
            var query = new DishQuery(Db);
            var result = await query.GetAllDishesAsync();
            return new OkObjectResult(result);
        }
        
        
        [HttpGet("dish/{id}")]
        public async Task<IActionResult> GetOneDish(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new DishQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }
        
        [HttpPost("dish/")]
        public async Task<IActionResult> PostDish([FromBody]Dish body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }
        
        [HttpPut("dish/{id}")]
        public async Task<IActionResult> UpdateADish(int id, [FromBody]Dish body)
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
        
        [HttpDelete("dish/{id}")]
        public async Task<IActionResult> DeleteOneDish(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new DishQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }
        
        [HttpDelete("dish/")]
        public async Task<IActionResult> DeleteAllDishes()
        {
            await Db.Connection.OpenAsync();
            var query = new DishQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }
        
        [HttpGet("meal/")]
        public async Task<IActionResult> GetAllMeals()
        {
            await Db.Connection.OpenAsync();
            var query = new MealQuery(Db);
            var result = await query.GetAllMealsAsync();
            return new OkObjectResult(result);
        }
        
        
        [HttpGet("meal/{id}")]
        public async Task<IActionResult> GetOneMeal(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new MealQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }
        
        [HttpPost("meal/")]
        public async Task<IActionResult> PostMeal([FromBody]Meal body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }
        
        [HttpPut("meal/{id}")]
        public async Task<IActionResult> UpdateAMeal(int id, [FromBody]Meal body)
        {
            await Db.Connection.OpenAsync();
            var query = new MealQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Label = body.Label;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }
        
        [HttpDelete("meal/{id}")]
        public async Task<IActionResult> DeleteOneMeal(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new MealQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }
        
        [HttpDelete("meal/")]
        public async Task<IActionResult> DeleteAllMeals()
        {
            await Db.Connection.OpenAsync();
            var query = new MealQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        [HttpGet("drink/")]
        public async Task<IActionResult> GetAllDrinks()
        {
            await Db.Connection.OpenAsync();
            var query = new DrinkQuery(Db);
            var result = await query.GetAllDrinksAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("drink/{id}")]
        public async Task<IActionResult> GetOneDrink(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new DrinkQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        [HttpPost("drink/")]
        public async Task<IActionResult> PostDrink([FromBody]Drink body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        [HttpPut("drink/{id}")]
        public async Task<IActionResult> UpdateADrink(int id, [FromBody]Drink body)
        {
            await Db.Connection.OpenAsync();
            var query = new DrinkQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Label = body.Label;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        [HttpDelete("drink/{id}")]
        public async Task<IActionResult> DeleteOneDrink(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new DrinkQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        [HttpDelete("drink/")]
        public async Task<IActionResult> DeleteAllDrinks()
        {
            await Db.Connection.OpenAsync();
            var query = new DrinkQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        [HttpGet("starter/")]
        public async Task<IActionResult> GetAllStarters()
        {
            await Db.Connection.OpenAsync();
            var query = new StarterQuery(Db);
            var result = await query.GetAllStartersAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("starter/{id}")]
        public async Task<IActionResult> GetOneStarter(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new StarterQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        [HttpPost("starter/")]
        public async Task<IActionResult> PostStarter([FromBody]Starter body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        [HttpPut("starter/{id}")]
        public async Task<IActionResult> UpdateAStarter(int id, [FromBody]Starter body)
        {
            await Db.Connection.OpenAsync();
            var query = new StarterQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Label = body.Label;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        [HttpDelete("starter/{id}")]
        public async Task<IActionResult> DeleteOneStarter(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new StarterQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        [HttpDelete("starter/")]
        public async Task<IActionResult> DeleteAllStarters()
        {
            await Db.Connection.OpenAsync();
            var query = new StarterQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        [HttpGet("dessert/")]
        public async Task<IActionResult> GetAllDesserts()
        {
            await Db.Connection.OpenAsync();
            var query = new DessertQuery(Db);
            var result = await query.GetAllDessertsAsync();
            return new OkObjectResult(result);
        }

        [HttpGet("dessert/{id}")]
        public async Task<IActionResult> GetOneDessert(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new DessertQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        [HttpPost("dessert/")]
        public async Task<IActionResult> PostDessert([FromBody]Dessert body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        [HttpPut("dessert/{id}")]
        public async Task<IActionResult> UpdateADessert(int id, [FromBody]Dessert body)
        {
            await Db.Connection.OpenAsync();
            var query = new DessertQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Label = body.Label;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        [HttpDelete("dessert/{id}")]
        public async Task<IActionResult> DeleteOneDessert(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new DessertQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        [HttpDelete("dessert/")]
        public async Task<IActionResult> DeleteAllDesserts()
        {
            await Db.Connection.OpenAsync();
            var query = new DessertQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        
    }
}