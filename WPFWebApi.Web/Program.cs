using Microsoft.EntityFrameworkCore;
using WPFWebApi.Data;
using WPFWebApi.Data.Repositories.Interfaces;
using WPFWebApi.Data.Repositories.ORM;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    
});
builder.Services.AddScoped<IUserRepository, UserRepositoryORM>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkORM>();

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
