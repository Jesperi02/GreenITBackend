using GreenITASPNetCore.Models;
using GreenITASPNetCore.Repositories;
using GreenITASPNetCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFileRepository, FileRepository>();

builder.Services.AddDbContext<FileContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("GreenDB"))
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    FileContext dbcontext = scope.ServiceProvider.GetRequiredService<FileContext>();
    dbcontext.Database.EnsureCreated();

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
