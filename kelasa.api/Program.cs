using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
  .Services
  .Configure<KelasaDatabaseSettings>(
    builder.Configuration.GetSection("KelasaDatabaseSettings")
  );
  builder.Services.AddSingleton<IMongoClient>(_ => {
    var connectionString = 
        builder
            .Configuration
            .GetSection("KelasaDatabaseSettings:ConnectionString")?
            .Value;

    return new MongoClient(connectionString);
});

builder.Services.AddSingleton<IKelasaRepository, KelasaRepository>();

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
