using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLibrary
{
    class PhoneDirectory
    {
        List<Person> Directory;
        PhoneDirectory()
        {
           Directory  = new List<Person>();
        }

        public void Add(Person p)
        {
            Directory.Add(p);
        }
        public void Delete(Person p)
        {
            foreach(var person in Directory)
            {
                if (p.Pid.Equals(person))
                {
                    Directory.Remove(person);
                }
            }
        }



    }
}
