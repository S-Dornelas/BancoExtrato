using BancoTeste.Context;
using BancoTeste.Repository;
using BancoTeste.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BancoTesteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BancoTesteContext") ?? throw new InvalidOperationException("Connection string 'BancoTesteContext' not found.")));
//conexão com o banco de dados

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
//injeção de dependecias

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
