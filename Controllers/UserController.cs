using Microsoft.AspNetCore.Mvc;
using TrainingAPI;

namespace TrainingAPI.Controllers
{
    [ApiController]
    [Route("users/[controller]")]
    public class UserController : Controller
    {

        static Dictionary<int, user> users = new Dictionary<int, user>();



        [HttpGet("")]

        public IActionResult getAllUsers()
        {

            return Ok(users.ToArray());
        }


        [HttpGet("/{id}")]

        public IActionResult getUserById(int id)
        {
            return (!users.ContainsKey(id)) ? NotFound() : Ok(users[id]);

        }


        [HttpPost("")]
        public IActionResult AddUser(user user)
        {

            users.Add(user.Id, user);

            return Ok(user);
        }



        [HttpPut("/{id}")]
        public IActionResult EditUser(int id, user user)
        {


            try
            {
                users.Add(user.Id, user);
            }
            catch (Exception ex)
            {
                return NotFound("User Id : " + id + "I Not Found");
            }

            return Ok(user);
        }


        [HttpDelete("/{id}")]
        public IActionResult DeleteUser(int id)
        {

            try
            {
                users.Remove(id);
            }
            catch (Exception ex)
            {
                return NotFound("User Id : " + id + "I Not Found");
            }

            return NoContent();
        }


    }
}
