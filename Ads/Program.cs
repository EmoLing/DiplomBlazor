using Ads.DbContexts;
using Ads.Repository;
using Helper.Database;
using Microsoft.EntityFrameworkCore;

string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        policy => policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

string connectionString = DbHelper.GetTrueConnectionString(builder.Configuration.GetConnectionString("Db")
    , AppDomain.CurrentDomain.BaseDirectory);

builder.Services.AddDbContext<AdContext>(o
    => o.UseSqlServer(connectionString));
builder.Services.AddTransient<IAdsRepository, AdsRepository>();

var app = builder.Build();

app.UseCors(myAllowSpecificOrigins);

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
