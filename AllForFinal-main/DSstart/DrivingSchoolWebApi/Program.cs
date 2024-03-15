
using DrivingSchoolWebApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;






var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(opcije =>
{
    opcije.AddPolicy("CorsPolicy",
        builder =>
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


builder.Services.AddDbContext<Context>(o =>
    o.UseSqlServer(
        builder.Configuration.
        GetConnectionString(name: "Context")
        )
    );



var app = builder.Build();

// Configure the HTTP request pipeline.
 //if (app.Environment.IsDevelopment())
//{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options =>
    {
        options.ConfigObject.
        AdditionalItems.Add("requestSnippetsEnabled", true);

    });
    

//}

app.UseHttpsRedirection();

app.MapControllers();
app.UseCors("CorsPolicy");
app.UseDefaultFiles();
app.UseDeveloperExceptionPage();
app.MapFallbackToFile("index.html");

app.UseStaticFiles();
app.Run();
