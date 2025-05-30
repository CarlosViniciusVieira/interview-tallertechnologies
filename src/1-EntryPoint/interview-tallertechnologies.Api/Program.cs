using interview_tallertechnologies.Api;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
