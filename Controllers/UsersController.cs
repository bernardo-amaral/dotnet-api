using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_net.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_net.Controllers
{
    [Route("/v1/[controller]")]
    public class UsersController : Controller
    {
        // GET v1/users
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            using (var db = new databaseContext())
            {
                try
                {
                    return db.Users.ToList();
                } catch (Exception) {
                    return null;
                }

            }
        }

        // GET v1/users/5
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            using (var db = new databaseContext())
            {
            try
                {
                    return db.Users.First((user => user.Id == id));
                } catch (Exception) {
                    return null;
                }

            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
