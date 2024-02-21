using API.Domain.Entities;
using API.Domain.Interfaces;
using API.Service.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API_Hahn.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private IBaseService<User> _baseUserService;

            public UserController(IBaseService<User> baseUserService)
            {
                _baseUserService = baseUserService;
            }

            [HttpPost]
            public IActionResult Create([FromBody] User user)
            {
                if (user == null)
                    return NotFound();

                return Execute(() => _baseUserService.Add<UserValidator>(user).Id);
            }

            [HttpPut]
            public IActionResult Update([FromBody] User user)
            {
                if (user == null)
                    return NotFound();

                return Execute(() => _baseUserService.Update<UserValidator>(user));
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                if (id == 0)
                    return NotFound();

                Execute(() =>
                {
                    _baseUserService.Delete(id);
                    return true;
                });

                return new NoContentResult();
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Execute(() => _baseUserService.Get());
            }

            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                if (id == 0)
                    return NotFound();

                return Execute(() => _baseUserService.GetById(id));
            }

            private IActionResult Execute(Func<object> func)
            {
                try
                {
                    var result = func();

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }
}
