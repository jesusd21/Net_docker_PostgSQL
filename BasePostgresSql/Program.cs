using BasePostgresSql.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var postgresSQLConnection = builder.Configuration.GetConnectionString("PostgresSQLConnection");

builder.Services.AddControllers();

builder.Services.AddDbContext<BaseDataContext>(options =>
{
    options.UseNpgsql(postgresSQLConnection);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
