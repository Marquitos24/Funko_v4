using System.Text.Json.Serialization;
using Funkos.Infrastructure;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.MapControllers();
app.Run();

