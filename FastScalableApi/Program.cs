using FastScalableApi.Data;
using FastScalableApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Services
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<MongoDbContext>();

builder.Services.AddScoped<MongoRepository>();
builder.Services.AddScoped<SqlRepository>();

builder.Services.AddScoped<UserService>();



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

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

