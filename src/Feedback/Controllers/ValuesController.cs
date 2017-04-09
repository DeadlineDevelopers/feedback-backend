using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Feedback.Core.Models;
using Feedback.Core.Services;

namespace Feedback.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IUsersService _usersService;

        public ValuesController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return _usersService.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            return _usersService.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]UserModel model)
        {
            //UserModel model = new UserModel();
            //model.CreatedAt = DateTime.Now;
            //model.CreatedBy = 1;
            //model.UpdatedAt = DateTime.Now;
            //model.UpdatedBy = 1;

            _usersService.Create(model);
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
