using Infrastructure.Modules;
using Modules.Configuration.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerDocumentation();
builder.Services.AddInfrastructure();
builder.Services.AddValidationState();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddConfigurationModule();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.UseConfigurationModuleAsync();
app.UseInfrastructure();
app.UseSwaggerDocumentation();

app.UseHttpsRedirection();

app.UseAuthorization();
    app.MapControllers();


app.UseRouting();

app.Run();
