
using CaptchaDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace CaptchaDemo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<UserContext>((options) =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));
			});
			builder.Services.AddCors(option =>
			{
				option.AddPolicy("AllowLocalhost4200",
					builder =>
					{
						builder.WithOrigins("http://localhost:4200")
							   .AllowAnyHeader()
							   .AllowAnyMethod();
					});
			});
			
			builder.Services.AddControllers();
			builder.Services.AddHttpClient<RecaptchaService>();
			builder.Services.AddScoped<RecaptchaService>();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseCors("AllowLocalhost4200");
			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
