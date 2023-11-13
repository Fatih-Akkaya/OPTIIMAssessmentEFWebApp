using AssessmentEF.Business;
using AssessmentEF.DataAccess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "corsPolicy",
        policy =>
        {
            policy.WithOrigins(
                    "https://localhost:7166",
                    "http://localhost:5155");
        });
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddBusinessServices();
builder.Services.AddDataServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
