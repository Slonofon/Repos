using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Addressbook.Models;
using Microsoft.AspNetCore.Builder;

namespace Addressbook.Data
{
    public class DBObjects
    {
        internal static void Initial(AppDBContent content)
        {
            if (!content.Person.Any())
            {
                content.AddRange(
                    new Person { FullName = "William Jefferson Bill Clinton", Birthday = new DateTime(1946, 8, 19), Email = "billy1946@gov.us" },
                    new Person { FullName = "Hillary Diane Rodham Clinton", Birthday = new DateTime(1947, 10, 26), Email = "hlinton1947@gmail.com" },
                    new Person { FullName = "Barack Hussein Obama II", Birthday = new DateTime(1961, 8, 4), Email = "bobama@ameritech.net" }
                    );
                content.SaveChanges();
            }
        }
    }
}
