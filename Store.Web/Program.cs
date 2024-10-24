
using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Repository;
using Store.Repository.interfaces;
using Store.Repository.UnitOfWork;
using Store.Web.Helper;

namespace Store.Web
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddDbContext<StoreDbContext>(options =>
				{
					options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

			}


				);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();
			await ApllySeeding.ApllySeedingAsync(app);
			

			app.MapControllers();

			app.Run();
		}
	}
}
