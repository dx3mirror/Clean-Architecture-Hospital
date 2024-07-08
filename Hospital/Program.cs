// Program.cs
using API.Hospital;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration()
       .AddDatabase()
       .AddServices()
       .AddSwagger()
       .AddAutoMapper()
       .AddMvcControllers();

var app = builder.Build();

app.ConfigureMiddlewares()
   .Run();
