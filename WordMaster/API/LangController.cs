using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WordMaster.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangController : ControllerBase
    {
        ILanguageRepository _repository;
        public LangController(ILanguageRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<LangController>
        [HttpGet]
        public IEnumerable<Language> Get()
        {

            return _repository.List();
        }

        // GET api/<LangController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LangController>
        [HttpPost]
        public bool Post([FromForm] Language entity)
        {
            _repository.Add(entity);
            return true;
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
