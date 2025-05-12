using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProHodie.API;
using ProHodie.API.Configuration;
using ProHodie.API.Data;
using ProHodie.API.Data.Repositories;
using ProHodie.API.Models.Entities;
using ProHodie.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(opt =>
    {
        opt.SerializerSettings.DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTimeOffset;
    }
);

builder.Services.AddDbContext<ProHodieDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ProHodieDbConnectionString"))
);

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = true;
})
    .AddEntityFrameworkStores<ProHodieDbContext>();

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

var identitySettings = builder.Configuration.GetSection("SuperAdmin").Get<IdentitySeedSettings>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await IdentitySeed.EnsureRolesAndUsers(serviceProvider, identitySettings);
}

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
