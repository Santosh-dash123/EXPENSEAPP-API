using ExpenseAppAPI.Application.Mappings;
using ExpenseAppAPI.Application.Services;
using ExpenseAppAPI.Infrastructure.Data;
using ExpenseAppAPI.Infrastructure.Interfaces;
using ExpenseAppAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExpenseConnection")));
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<IManageUserRepository, ManageUserRepository>();
builder.Services.AddScoped<ManageUserService>();
builder.Services.AddScoped<IMasterRepository, MasterRepository>();
builder.Services.AddScoped<MasterService>();
builder.Services.AddScoped<IHelperRepository, HelperRepository>();
builder.Services.AddScoped<HelperService>();

//Code For Mapped Dto 
builder.Services.AddAutoMapper(typeof(RoomProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ManageUserProfile).Assembly);
builder.Services.AddAutoMapper(typeof(MasterProfile).Assembly);
builder.Services.AddAutoMapper(typeof(MemberProfile).Assembly);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Use CORS globally
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
