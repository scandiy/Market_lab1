using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly MarketDb1Context _context;

        public ChartsController(MarketDb1Context context)
        {
            _context = context;
        }

        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var categories = _context.Categories.Include(b => b.Markets).ToList();

            List<object> catMarkets = new List<object>();

            catMarkets.Add(new[] { "Категорiя", "кiлькiсть магазинiв" });

            foreach (var c in categories)
            {
                catMarkets.Add(new object[] { c.Name, c.Markets.Count() });
            }
            return new JsonResult(catMarkets);
        }
        [HttpGet("JsonData1")]
        public JsonResult JsonData1()
        {
            var departments = _context.Departments.Include(b => b.Workers).ToList();

            List<object> depWorkers = new List<object>();

            depWorkers.Add(new[] { "r", "кiлькiсть магазинiв" });

            foreach (var c in departments)
            {
                depWorkers.Add(new object[] { c.MarketId, c.Workers.Count() });
            }
            return new JsonResult(depWorkers);
        }
    }
}


