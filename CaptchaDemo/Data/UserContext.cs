using CaptchaDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CaptchaDemo.Data
{
	public class UserContext:DbContext
	{
		public DbSet<User> Users { get; set; }
		public UserContext(DbContextOptions<UserContext> options) : base(options) { }
	}
}
