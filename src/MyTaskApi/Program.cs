using Microsoft.EntityFrameworkCore;
using MyTaskApi.Persistence;
using MyTaskApi.Persistence.Repositories.Tasks;

var builder = WebApplication.CreateBuilder(args);
{
  // configure services (DI)
  builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
  builder.Services.AddScoped<ITaskRepository, TaskRepository>();
  builder.Services.AddControllers();
  builder.Services.AddSwaggerGen();
  builder.Services.AddCors(options =>
  {
    options.AddPolicy(name: "angularApp", policy => policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
  });
}


var app = builder.Build();
{
  // configure request pipeline
  app.UseSwagger();
  app.UseSwaggerUI();
  app.MapControllers();
  app.UseCors("angularApp");

}
app.Run();

