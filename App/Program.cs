using martianRobots.ServicesInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ServicesInjection.ConfigureServicesInjection(builder.Services);

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    }
);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

