using My.Custom.Template.Presentation.Extensions;
using My.Custom.Template.Application.DI;
using My.Custom.Template.Infraestructure.DI;
using My.Custom.Template.Presentation.Filters;
using My.Custom.Template.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);
// Aspire defaults
builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ResultTransformerActionFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen();



builder.Services.AddPresentationModule();
builder.Services.AddApplicationCore();
builder.Services.AddInfraesctructure();

var app = builder.Build();

//Asire Defaults
app.MapDefaultEndpoints();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();
