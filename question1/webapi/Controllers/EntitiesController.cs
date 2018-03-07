using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using webapiProxy.DataContracts;

namespace webapi.Controllers
{
    [Route("api/[Controller]")]
    public class EntitiesController : Controller
    {
        IMemoryCache _cache;
        const string CACHE_KEY = "entities";
        public EntitiesController(IMemoryCache cache)
        {
            _cache = cache;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Entity> Get()
        {
            var res = new List<Entity>();
            _cache.TryGetValue(CACHE_KEY, out res);
            if (res == null)
                res = new List<Entity>();
            return res;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Entity Get(int id)
        {
             var res = new List<Entity>();
            _cache.TryGetValue(CACHE_KEY, out res);
            if (res == null)
                return null;
          return  res.FirstOrDefault(r => r.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Entity value)
        {
            if (value == null || value.Id <= 0)
                throw new ApplicationException("invalid entity to save");
            var res = new List<Entity>();
            _cache.TryGetValue(CACHE_KEY, out res);
            if (res == null)
                res = new List<Entity>();
            if (res.Any(r => r.Id == value.Id))
                throw new ApplicationException("Id is an existed.");
            res.Add(value);
            var cacheEntryOptions = new MemoryCacheEntryOptions();
            cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromMinutes(60));
            _cache.Set(CACHE_KEY, res, cacheEntryOptions);

        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }


}
