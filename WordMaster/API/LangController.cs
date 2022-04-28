using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public IActionResult Post([FromForm] Language entity)
        {
            _repository.Add(entity);
            return Created("",true);
        }

        // PUT api/<LangController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromForm] Language entity)
        {
            _repository.Update(entity);
            return true;
        }

        // DELETE api/<LangController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                _repository.Delete(id);
            }
            catch (Exception)
            {

             //   return StatusCode(403);
                return Forbid();
            }
            return Ok(true);
        }
    }
}
