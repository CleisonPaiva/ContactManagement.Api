using ContactManagement.Api.Context;
using ContactManagement.Api.Core.AutoMappers;
using ContactManagement.Api.Services;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ContactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the service interface and implementation
builder.Services.AddScoped<IContactService, ContactService>();

//Mapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(ContactProfile).Assembly);
});

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
