using DotNet.Data;
using DotNet.Models;

namespace DotNet.DbConnection
{
	public class InMemorySeedData
	{
		public static void AddTestDataInMemory(IServiceProvider serviceProvider)
		{
			using var scope = serviceProvider.CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
			SeedData(context);
		}

		private static void SeedData(DatabaseContext context)
		{
			var customer = new[]
			{
				new Student { Id = 1, UserName = "Bojan", Email="", Password = "", Age =25 }
			};

			context.Students.AddRange(customer);
			context.SaveChanges();
		}
	}
}