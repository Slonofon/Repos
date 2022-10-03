using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Addressbook.Models;
using Microsoft.AspNetCore.Mvc;

namespace Addressbook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressbookController : Controller
    {
        public IAddressbookRepository Persons { get; set; }

        public AddressbookController(IAddressbookRepository pesons)
        {
            Persons = pesons;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return Persons.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return Persons.FindById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Person value)
        {
            Persons.Add(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Person value)
        {
            Persons.Update(value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Persons.Remove(id);
        }
    }
}
