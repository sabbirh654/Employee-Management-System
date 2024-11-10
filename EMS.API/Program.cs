using EMS.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterUserServices();
builder.Services.RegisterFrameworkServices();

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
