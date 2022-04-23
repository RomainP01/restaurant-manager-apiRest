using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace APIRestDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Dish> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Dish
                {
                    Name = "Welsh",
                    DishType = DishType.Plat,
                    DishStatus = DishStatus.EnPréparation
                })
                .ToArray();
        }
    }
}