using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangController : ControllerBase
    {
        WordMasterDbContext _context;
        public LangController(WordMasterDbContext context)
        {
            _context = context;
        }
        // GET: api/<LangController>
        [HttpGet]
        public IEnumerable<Language> Get()
        {
            return _context.Set<Language>().ToList();
        }

        // GET api/<LangController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LangController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LangController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
