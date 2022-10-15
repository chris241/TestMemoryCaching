using TestMemoryCaching.Repositories;
using TestMemoryCaching.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<DataContext>(options =>
    {
        string c = "server = MU-LTP-0017 ; DataBase=Cach ; user=sa ; password ='Qwerty@1234'";
        options.UseSqlServer(c);
    });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductService, CachedProductService>();
builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
