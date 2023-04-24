using Microsoft.Extensions.Options;
using ProjMongoAtividade24042023.Config;
using ProjMongoAtividade24042023.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//configuration Singleton  andd AppSettings Parameters
builder.Services.Configure<ProjMongoAtividadeSettings>(builder.Configuration.GetSection("ProjMongoAtividadeSettings"));
builder.Services.AddSingleton<IProjMongoAtividadeSettings>(s => s.GetRequiredService<IOptions<ProjMongoAtividadeSettings>>().Value);
builder.Services.AddSingleton<ClientService>(); 
builder.Services.AddSingleton<AddressService>();
builder.Services.AddSingleton<CityService>();
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
