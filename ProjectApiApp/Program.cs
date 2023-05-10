using Microsoft.EntityFrameworkCore;
using ProjectApiApp.EFCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EF_DataContext>(
                o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db"))
            );
builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
