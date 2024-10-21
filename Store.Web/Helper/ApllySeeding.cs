using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Repository;

namespace Store.Web.Helper
{
	public class ApllySeeding
	{
		public static async Task ApllySeedingAsync(WebApplication app)
		{
			using (var scope = app.Services.CreateScope())
			{
				var service = scope.ServiceProvider;
				var loogerFactory = service.GetRequiredService<ILoggerFactory>();

				try
				{
					var context = service.GetRequiredService<StoreDbContext>();
					await context.Database.MigrateAsync();
					await StoreContextSeed.seedAsync(context,loogerFactory);
				}
				catch(Exception ex)
				{
					var looger = loogerFactory.CreateLogger<ApllySeeding>();
					looger.LogError(ex.Message);
				}
				}

		}
	}
}
