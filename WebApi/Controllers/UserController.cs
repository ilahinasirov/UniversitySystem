using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;


        public UserController(IUserService userService, IAuthorizationService authorizationService,
            UserManager<User> userManager)
        {
            _userService = userService;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }
        public UserController()
        {

        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] User user)
        {
            var admin = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                SurName = user.SurName,
                Password = user.Password,

            };
            var roleName = "Admin";
            var result = await _userService.AddUserWithRole(admin, roleName);


            return Ok(result);
        }


        #region Teacher Operations
        [HttpPost("add-teacher")]
        public async Task<IActionResult> AddTeacher(User user)
        {
            var isAdmin = await _authorizationService.IsUserInRole(HttpContext.User, "Admin");
            if (isAdmin)
            {
                var teacher = new User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Name = user.Name,
                    SurName = user.SurName,
                    Password = user.Password,
                };
                string roleName = "Teacher";
                var result = await _userService.AddUserWithRole(teacher, roleName);
                return Ok(result);
            }
            return Unauthorized(Messages.Unauthorized);
        }


        [HttpDelete("delete-teacher/{teacherId}")]
        public async Task<IActionResult> DeleteTeacher(int teacherId)
        {
            var isAdmin = await _authorizationService.IsUserInRole(HttpContext.User, "Admin");
            if (isAdmin)
            {
                var teacherToDelete = await _userManager.FindByIdAsync(teacherId.ToString());
                if (teacherToDelete == null)
                {
                    return NotFound(Messages.UserNotFound);
                }
                var result = await _userManager.DeleteAsync(teacherToDelete);
                if (result.Succeeded)
                {
                    return Ok(Messages.UserDeleted);
                }
                return BadRequest(result.Errors);

            }
            return Unauthorized(Messages.Unauthorized);
        }
        #endregion

        #region Student Operations

        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent(User user)
        {
            var isAdmin = await _authorizationService.IsUserInRole(HttpContext.User, "Admin");
            var isTeacher = await _authorizationService.IsUserInRole(HttpContext.User, "Teacher");
            if (isAdmin || isTeacher)
            {
                var student = new User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Name = user.Name,
                    SurName = user.SurName,
                    Password = user.Password,
                };
                string roleName = "Student";
                var result = await _userService.AddUserWithRole(student, roleName);
                return Ok(result);
            }
            return Unauthorized(Messages.Unauthorized);
        }


        [HttpDelete("delete-student/{studentId}")]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            var isAdmin = await _authorizationService.IsUserInRole(HttpContext.User, "Admin");
            var isTeacher = await _authorizationService.IsUserInRole(HttpContext.User, "Teacher");
            if (isAdmin || isTeacher)
            {
                var studentToDelete = await _userManager.FindByIdAsync(studentId.ToString());
                if (studentToDelete == null)
                {
                    return NotFound(Messages.UserNotFound);
                }
                var result = await _userManager.DeleteAsync(studentToDelete);
                if (result.Succeeded)
                {
                    return Ok(Messages.UserDeleted);
                }
                return BadRequest(result.Errors);

            }
            return Unauthorized(Messages.Unauthorized);
        }


        #endregion
    }
}
