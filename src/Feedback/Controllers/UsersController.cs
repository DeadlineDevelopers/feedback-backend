using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Feedback.Core.Services;
using Feedback.Core.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Feedback.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return _usersService.All();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(long id)
        {
            var user = _usersService.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        /// <summary>
        /// Creates a User.
        /// </summary>
        /// <remarks>
        /// 
        ///     POST /Users
        ///     {
        ///        "name": "name1",
        ///        "username": "username1",
        ///        "password": "1",
        ///        "mail": "abc@gmail.com",
        ///        "Phone":"05555555555"
        ///     }
        /// 
        /// </remarks>
        /// <param name="userModel"></param>
        /// <returns>New Created User</returns>
        /// <response code="201">Returns the newly created user</response>
        /// <response code="400">If the user is null</response>
        [HttpPost]
        [ProducesResponseType(typeof(UserModel), 201)]
        [ProducesResponseType(typeof(UserModel), 400)]
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]UserModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }
            TryValidateModel(userModel);
            if (this.ModelState.IsValid)
            {
                var user = _usersService.Create(userModel);
                return CreatedAtRoute("GetUser", new { controller = "Users", id = user.Id }, user);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]UserModel userModel)
        {
            if (userModel == null || userModel.Id != id)
            {
                return BadRequest();
            }

            var user = _usersService.Find(id);
            if (user == null)
            {
                return NotFound();
            }            

            TryValidateModel(userModel);
            if (this.ModelState.IsValid)
            {
                user.Name = userModel.Name;
                user.Username = userModel.Username;
                user.Password = userModel.Password;
                user.MAIL = userModel.MAIL;
                user.Phone = userModel.Phone;
                _usersService.Update(user);
                return new NoContentResult();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletes a specific User.
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _usersService.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _usersService.Delete(id);
            return new NoContentResult();
        }
    }
}
