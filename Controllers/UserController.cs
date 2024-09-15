using System.Runtime.CompilerServices;
using TheAgoraAPI.DTOs;

namespace TheAgoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await userRepository.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await userRepository.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(String email, String password)
        {
            try
            {
                var user = await userRepository.GetUserByEmailAndPassword(email, password);
                return Ok(user);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto newUserDto)
        {
            try
            {
                // Map the DTO to your User model
                var newUser = new User
                {
                    UserId = newUserDto.UserId,
                    Fname = newUserDto.Fname,
                    Lname = newUserDto.Lname,
                    Email = newUserDto.Email,
                    Password = newUserDto.Password,
                    IsStaffMember = newUserDto.IsStaffMember,
                    PhoneNumber = newUserDto.PhoneNumber
                };

                var userId = await userRepository.Register(newUser);
                return Ok(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
