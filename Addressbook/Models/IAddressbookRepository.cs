using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addressbook.Models
{
    public interface IAddressbookRepository
    {
        void Add(Person person);
        IEnumerable<Person> GetAll();
        IEnumerable<Person> Find(string str);
        Person FindById(int id);
        void Remove(int id);
        void Update(Person person);
    }
}
