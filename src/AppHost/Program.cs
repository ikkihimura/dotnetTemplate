using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var app = builder.AddProject<My_Custom_Template_API>("MyCustomTemplate");
builder.Build().Run();
