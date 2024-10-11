using Microsoft.EntityFrameworkCore;
using ProHodie.API.Data;
using ProHodie.API.Data.Repositories;
using ProHodie.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ProHodieDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ProHodieDbConnectionString"))
);

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityCategoryRepository, ActivityCategoryRepository>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IActivityCategoryService, ActivityCategoryService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("ProhodieClientApiCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    }
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ProhodieClientApiCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
