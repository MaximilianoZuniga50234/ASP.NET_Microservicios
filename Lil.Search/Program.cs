using Lil.Sales.Services;
using Lil.Search.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICustomersService, CustomersService>();
builder.Services.AddSingleton<IProductsService, ProductsService>();
builder.Services.AddSingleton<ISalesService, SalesService>();
builder.Services.AddHttpClient("customersService", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Service:Customers"]);
});
builder.Services.AddHttpClient("productsService", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Service:Products"]);
});
builder.Services.AddHttpClient("salesService", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Service:Sales"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
