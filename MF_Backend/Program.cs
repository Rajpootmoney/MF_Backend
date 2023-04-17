using MF_DataAccess.Data;
using MF_DataAccess.DTO_Mapping;
using MF_DataAccess.Repository;
using MF_DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string cs = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(cs));

builder.Services.AddSwaggerDocument();

builder.Services.AddScoped<IUserFormRepositoy, UserFormRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IGenderTypeRepository, GenderTypeRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
    builder =>
    {
        builder.WithOrigins()
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOpenApi();

app.UseSwaggerUi3();

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
