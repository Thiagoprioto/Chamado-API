using FluentValidation;
using GestaoDeChamados_Application.DTO.User;
using GestaoDeChamados_Application.Interface;
using GestaoDeChamados_Application.Service;
using GestaoDeChamados_Domain.Interface;
using GestaoDeChamados_infrastructure.Data;
using GestaoDeChamados_infrastructure.Repository;
using GestaoDeChamados_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GestaoDeChamadosDb")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddValidatorsFromAssemblyContaining<IUserService>();

var app = builder.Build();

// Configuração do Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Middleware

// --> here you can add custom middleware if needed


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();