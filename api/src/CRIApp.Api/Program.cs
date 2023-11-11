using CRIApp.Api.Middlewares;
using CRIApp.Application.Extensions;
using CRIApp.Domain.Settings;
using AppContext = CRIApp.Repository.AppContext;

var builder = WebApplication.CreateBuilder(args);

// TODO: Isolate in extensions
builder.Services.Configure<UserSettings>(builder.Configuration.GetSection("UserSettings"));

// Add services to the container.
builder.Services.AddDbContext<AppContext>();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseErrorHandler();

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