using DotCrafts.Models;
using DotCrafts.Services;
using Microsoft.AspNetCore.Builder;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
//ADD STUFF
// Add services to the container.
builder.Services.AddRazorPages();
//Added for the Components
builder.Services.AddServerSideBlazor();
//service of Json created
builder.Services.AddTransient<JsonFileProductService>();
//For now only controllers and no all MVC
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//USE STAFF
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
//USE the added controllers service
app.MapControllers();
app.MapBlazorHub();

//a simple api to visualize in Json on the web the product
//this not the ideal way, it's done manually and in program.
//app.MapGet("/products", async (context) =>
//{
//	var productService = context.RequestServices.GetRequiredService<JsonFileProductService>();
//	var products = productService.GetProducts();
//	var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
//	var json = JsonSerializer.Serialize<IEnumerable<Product>>(products, options);
//	await context.Response.WriteAsync(json);
//});

app.Run();
