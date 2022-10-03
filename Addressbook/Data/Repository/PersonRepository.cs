using Addressbook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addressbook.Data.Repository
{
    public class PersonRepository : IAddressbookRepository
    {
        private readonly AppDBContent appDBContent;

        public PersonRepository(AppDBContent appDBContent)
        {
            this.appDBContent  = appDBContent;
        }

        public void Add(Person person)
        {
            appDBContent.Person.Add(person);
            appDBContent.SaveChanges();
        }

        public Person FindById(int id) => appDBContent.Person.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Person> Find(string str)
        {
            var result = new HashSet<Person>();
            result = appDBContent.Person.Where(p => p.Id.ToString().Contains(str)).ToHashSet();
            result.UnionWith(appDBContent.Person.Where(p => p.FullName.Contains(str)).ToHashSet());
            result.UnionWith(appDBContent.Person.Where(p => p.Birthday.ToShortDateString().Contains(str)).ToHashSet());
            result.UnionWith(appDBContent.Person.Where(p => p.Email.Contains(str)).ToHashSet());
            return result;
        }

        public IEnumerable<Person> GetAll() => appDBContent.Person;

        public void Remove(int id)
        {
            var sample = new Person() { Id = id };
            appDBContent.Person.Attach(sample);
            appDBContent.Person.Remove(sample);
            appDBContent.SaveChanges();
        }

        public void Update(Person person)
        {
            appDBContent.Person.Update(person);
            appDBContent.SaveChanges();
        }
    }
}
