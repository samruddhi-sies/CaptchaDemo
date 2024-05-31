using CaptchaDemo.Data;
using CaptchaDemo.Dto;
using CaptchaDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaptchaDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly UserContext _userContext;
		private readonly RecaptchaService _recaptchaService;
		public HomeController(UserContext userContext, RecaptchaService recaptchaService)
		{
			_userContext = userContext;
			_recaptchaService = recaptchaService;
		}

		[HttpGet]
		public IActionResult GetUsers()
		{
			var users = _userContext.Users;
			return Ok(users);
		}

		[HttpPost]
		public async Task<IActionResult> Register(UserDto userDto)
		{
			if (!await _recaptchaService.VerifyRecaptchaAsync(userDto.RecaptchaToken))
			{
				return BadRequest("Invalid reCAPTCHA");
			}
			var user = new User()
			{
				FirstName = userDto.FirstName,
				LastName = userDto.LastName,
				Email = userDto.Email,
				Password = userDto.Password,
			};
			_userContext.Users.Add(user);
			_userContext.SaveChanges();
			return Ok(user);
		}
    }
}
