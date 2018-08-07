﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactDAL;
using PhoneAppLibrary;
using System.Web.Http.Cors;
using Newtonsoft.Json;

    
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


        //ADD
        [HttpPost]
        public IHttpActionResult Post([FromBody] Person p)
        {
   
            if (p != null)
            {
                crud.InsertPerson(p);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        // to do  Put

        // to do Delete

    }
}
