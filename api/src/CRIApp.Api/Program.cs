using CRIApp.Api.Middlewares;
using CRIApp.Application.Abstractions;
using CRIApp.Application.Services;
using CRIApp.Domain.Data;
using CRIApp.Domain.Settings;
using CRIApp.Repository.Repositories;
using AppContext = CRIApp.Repository.AppContext;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<UserSettings>(builder.Configuration.GetSection("UserSettings"));

// Add services to the container.
builder.Services.AddDbContext<AppContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

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