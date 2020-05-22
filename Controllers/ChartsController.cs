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

            List<object> catmarkets = new List<object>();

            catmarkets.Add(new[] { "Категорiя", "кiлькiсть магазинiв" });

            foreach (var c in categories)
            {
                catmarkets.Add(new object[] { c.Name, c.Markets.Count() });
            }
            return new JsonResult(catmarkets);
        }
    }
}