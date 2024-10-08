global using Microsoft.AspNetCore.Mvc;
global using TheAgoraAPI.Models;
global using TheAgoraAPI.Interfaces;
global using TheAgoraAPI.Repositories;
global using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//register dbcontext
builder.Services.AddDbContext<TheAgoraDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMarketListingRepository, MarketListingRepository>();
builder.Services.AddScoped<IForumPostRepository, ForumPostRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<IForumCommentRepository, ForumCommentRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

//configure swagger
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
