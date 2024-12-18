


using Microsoft.EntityFrameworkCore;
using WAD_00019330.Data;
using WAD_00019330.Models;
using WAD_00019330.Repositories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



var builder = WebApplication.CreateBuilder(args);




builder.Services.AddCors(options =>

{

    options.AddPolicy(MyAllowSpecificOrigins,

               policy =>

               {

                   policy.WithOrigins("http://localhost:4200")

                           .AllowAnyHeader()

                           .AllowAnyMethod()

                           .AllowAnyOrigin();

               });

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<GeneralDBContext>(

  o => o.UseSqlServer(

    builder.Configuration.GetConnectionString("SqlServerConnection")));



builder.Services.AddScoped<IRepository<SparePart>, SparePartRepository>();

builder.Services.AddScoped<IRepository<SpareCategory>, SpareCategoryRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())

{

    app.UseSwagger();

    app.UseSwaggerUI();

}





app.UseCors(MyAllowSpecificOrigins);



app.UseAuthorization();



app.MapControllers();







app.Run();