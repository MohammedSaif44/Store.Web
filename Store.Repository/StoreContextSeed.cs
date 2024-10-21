using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Store.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Store.Repository
{
	public class StoreContextSeed
	{
		public static async Task seedAsync(StoreDbContext context, ILoggerFactory loggerFactory)
		{
			try
			{
				if (context.productTypes != null && !context.productTypes.Any()) //if brands not any in table do this code
				{
					// to Read Json File
					var TypesData = File.ReadAllText("../Store.Repository/SeedData/Types.json");
					// to convert Json file to List
					var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
					// to add List in dataBase
					if (Types is not null)
					{

						await context.Set<ProductType>().AddRangeAsync(Types);

					}

				}
				if (context.productBrands != null && !context.productBrands.Any()) //if brands not any in table do this code
				{
					// to Read Json File
					var BrandsData = File.ReadAllText("../Store.Repository/SeedData/brands.json");
					// to convert Json file to List
					var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
					// to add List in dataBase
					if (Brands is not null)
					{

						await context.Set<ProductBrand>().AddRangeAsync(Brands);

					}

				}
			
				if (context.products != null && !context.products.Any()) //if brands not any in table do this code
				{
					// to Read Json File
					var ProductData = File.ReadAllText("../Store.Repository/SeedData/products.json");
					// to convert Json file to List
					var product = JsonSerializer.Deserialize<List<Product>>(ProductData);
					// to add List in dataBase
					if (product is not null)
					{

						await context.Set<Product>().AddRangeAsync(product);

					}

				}
				await context.SaveChangesAsync();
			}
			
			catch (Exception ex)
			{
				await context.SaveChangesAsync();
				var looger = loggerFactory.CreateLogger<StoreDbContext>();
				looger.LogError(ex.Message);
			}
		}
	}
}
