using Microsoft.EntityFrameworkCore;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;
using VentasNet.Infra.Services.Interfaces;
using VentasNet.Infra.Services.Repo;
using VentasNET.Entity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();

builder.Services.AddDbContext<VentasNetContext>(options=>options.UseSqlServer(
    builder.Configuration.GetConnectionString("VentasNetConnection")));

builder.Services.AddScoped<IClienteRepo, ClienteRepo>();
builder.Services.AddScoped<IProveedorRepo, ProveedorRepo>();
builder.Services.AddScoped<IProductoRepo, ProductoRepo>();
builder.Services.AddScoped<IUsuarioRepo, UsuarioRepo>();
builder.Services.AddScoped<IClienteService, ClienteServices>();
builder.Services.AddScoped<IComprobanteRepo, ComprobanteRepo>();
builder.Services.AddScoped<IFormasPagoRepo, FormasPagoRepo>();
builder.Services.AddScoped<IMovCompRepo, MovCompRepo>();
builder.Services.AddScoped<IMovProvRepo, MovProvRepo>();
builder.Services.AddScoped<IStockRepo, StockRepo>();
builder.Services.AddScoped<IVenta, VentaRepo>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Inicio}/{id?}");

app.Run();

