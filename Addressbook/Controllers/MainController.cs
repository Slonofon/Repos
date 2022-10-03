using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Addressbook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Addressbook.Controllers
{
    public class MainController : Controller
    {
        public IAddressbookRepository Persons { get; set; }

        public MainController(IAddressbookRepository pesons)
        {
            Persons = pesons;
        }

        private ViewResult ViewList(IEnumerable<Person> list)
        {
            List<string> pNames = new List<string>();
            foreach (var property in Type.GetType("Addressbook.Models.Person").GetProperties())
                pNames.Add(property.Name);
            ViewBag.CPNames = pNames;
            return View(list);
        }

        public ViewResult List(string str = null)
        {
            if (str == null)
                return ViewList(Persons.GetAll());
            else
                return ViewList(Persons.Find(str));
        }

        //[Authorize]
        //[Authorize(Roles = "Administrator")]
        //[Authorize(Roles = "Администраторы")]
        //[Authorize(Roles = "Опытные пользователи")]
        public ViewResult Edit(string act, int id, Person person)
        {
            switch (act)
            {
                case "delete":
                    Persons.Remove(id);
                    break;
                case "edit":
                    Persons.Update(person);
                    break;
                case "add":
                    Persons.Add(person);
                    break;
            }
            return ViewList(Persons.GetAll());
        }
    }
}