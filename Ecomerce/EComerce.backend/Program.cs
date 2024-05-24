using EComerce.backend.Data;
using ECommerce.backend.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Context SQL Server
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("name=LocalConnection"));

//builder.Services.AddDbContext<DataContext>(options =>
//             options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));
#endregion Context SQL Server

#region Register (dependency injection)
DependencyInyectionHandler.DepencyInyectionConfig(builder.Services);
#endregion Register (dependency injection)

var app = builder.Build();

app.UseCors( x=> x
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(o => true)
.AllowCredentials()
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
