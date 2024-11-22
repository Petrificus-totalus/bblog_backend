using blog.Data;
using blog.Interfaces;
using blog.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IAlgorithmRepository, AlgorithmRepository>();
builder.Services.AddScoped<IAlgoTagRepository, AlgoTagRepository>();
builder.Services.AddScoped<ISwallowRepository, SwallowRepository>();
builder.Services.AddScoped<ISwallowLinksRepository, SwallowLinksRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // 这里的端口是 React 开发服务器的端口
                .AllowAnyHeader()
                .AllowAnyMethod().AllowCredentials();
        });
});
builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();
app.UseCors("AllowReactApp");

app.Run();

