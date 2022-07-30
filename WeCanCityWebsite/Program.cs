using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#region Add CORS
builder.Services.AddCors();
#endregion

builder.Services.Configure<Helper>(builder.Configuration.GetSection("PATHS"));

#region Add Context
builder.Services.AddDbContext<Db_Context>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"), options =>
    {
        options.CommandTimeout(180); // 3 minutes
    }));
#endregion
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

#region Allow CORS 
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
