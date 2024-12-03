using Microsoft.AspNetCore.Mvc;
using FamilyPlanner_Api.Models.Users;
using FamilyPlanner_Api.Services;
using FamilyPlanner_Api.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyPlanner_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiBaseController
    {
        // Dependency Injection
        private readonly UserService _userService;

        public UsersController(FamilyDbContext dbContext)
        {
            _userService = new(dbContext);
        }



        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(string id)
        {
            User? user = await _userService.GetUserById(id);

            if (user is null)
            {
                return NotFound($"User '{id}' was not found");
            }

            return Ok(user);
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                User user = await _userService.CreateUser(createUserDto);
                return CreatedAtRoute(
                    nameof(GetUserById),
                    routeValues: new { id = user.Id },
                    value: user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                User? user = await _userService.UpdateUser(id, updateUserDto, GetCurrentUserID());

                if (user is null)
                {
                    return NotFound($"User '{id}' was not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return NoContent();
            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
