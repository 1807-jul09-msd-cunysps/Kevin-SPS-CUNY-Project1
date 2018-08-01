using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactDAL;
using PhoneAppLibrary;
using System.Web.Http.Cors;

    
namespace ContactAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PersonController : ApiController
    {
        PersonCrud crud = new PersonCrud();
        //READ
        [HttpGet]
        public IEnumerable<Person> Get()
        {

            var person = crud.GetPersons();
            return person; 
        }


    }
}
