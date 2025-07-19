using Inventarium.Web.Services;
using InventariumWebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InventariumWebApp.Models;
using Microsoft.AspNetCore.SignalR;
using InventariumWebApp.BuildScript;
using Microsoft.Extensions.FileProviders;
using InventariumWebApp.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configuração da cadeia de conexão
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Registrar HttpContextAccessor primeiro (necessário para DbContext e TenantProvider)
builder.Services.AddHttpContextAccessor();

// Registrar o DbContext com a conexão adequada
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Adicionar o suporte ao diagnosticador de banco de dados
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Registrar o Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// Configura o cookie de autenticação
builder.Services.ConfigureApplicationCookie(options => {
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
});

// Registrar o TenantProvider (agora sem a dependência circular)
builder.Services.AddScoped<ITenantProvider, TenantProvider>();

// Registra outros serviços
builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddScoped<EmailService>();

// Constrói o aplicativo
var app = builder.Build();

// Configura o ambiente
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Configura diretório para exportações
var exportBuildsPath = Path.Combine(Directory.GetCurrentDirectory(), "ExportBuilds");
if (!Directory.Exists(exportBuildsPath))
{
    Directory.CreateDirectory(exportBuildsPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(exportBuildsPath),
    RequestPath = "/exports"
});

app.UseRouting();

app.UseAuthentication();
// Adiciona o middleware de claim do tenant logo após a autenticação
app.UseMiddleware<TenantClaimsMiddleware>();
app.UseAuthorization();

// Inicializa as roles
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Administrator", "Default" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

// Mapeia o hub do SignalR
app.MapHub<BuildHub>("/BuildHub");

// Configura as rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();