using E_CommeerceApp.Data;
using E_CommeerceApp.Data.Interfaces;
using E_CommeerceApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Configuration.GetConnectionString("AppConnectionString");

#region DbContext Configuration
builder.Services.AddDbContext<AppDbContext>(opt => opt
.UseSqlServer(builder.Configuration.GetConnectionString("AppConnectionString")));
#endregion

#region Register Services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
#endregion

//builder.Host.UseSerilog((ctx, lc) => lc
//    .WriteTo.Console()
//    .ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
