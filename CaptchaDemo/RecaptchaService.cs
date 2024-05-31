using CaptchaDemo.Models;
using Newtonsoft.Json;

namespace CaptchaDemo
{
	public class RecaptchaService
	{
		private readonly HttpClient _httpClient;
		private readonly string _secretKey="";

		public RecaptchaService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_secretKey = configuration["Recaptcha:SecretKey"];
		}
		public async Task<bool> VerifyRecaptchaAsync(string token)
		{
			var response = await _httpClient.GetStringAsync(
				$"https://www.google.com/recaptcha/api/siteverify?secret={_secretKey}&response={token}");

			var recaptchaResponse = JsonConvert.DeserializeObject<RecaptchaResponse>(response);

			return recaptchaResponse.Success;
		}
	}
}
