﻿namespace CaptchaDemo.Dto
{
	public class UserDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string RecaptchaToken {  get; set; }
	}
}