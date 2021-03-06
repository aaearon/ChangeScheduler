using ChangeScheduler.CyberArk;
using ChangeScheduler.CyberArk.Api;
using ChangeScheduler.Data;
using ChangeScheduler.Data.Repositories;
using ChangeScheduler.Data.Services;
using ChangeScheduler.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var PvwaBaseAddressFromConfig = builder.Configuration["CyberArkEnvironment:PvwaBaseAddress"];
var UsernameFromConfig = builder.Configuration["CyberArkEnvironment:Username"];
var PasswordFromConfig = builder.Configuration["CyberArkEnvironment:Password"];

builder.Services.AddSingleton(new CyberArkAuthenticationRequest
{
    Address = PvwaBaseAddressFromConfig,
    UserName = UsernameFromConfig,
    Password = PasswordFromConfig,
    ConcurrentSession = true
});
builder.Services.AddHttpClient<ICyberArkApiSessionClient, CyberArkApiSessionClient>(client =>
{
    client.BaseAddress = new Uri(PvwaBaseAddressFromConfig);
});
builder.Services.AddTransient<CyberArkApiSessionTokenHandler>();
builder.Services.AddHttpClient<ApiClient>(client =>
{
    client.BaseAddress = new Uri(PvwaBaseAddressFromConfig);
}).AddHttpMessageHandler<CyberArkApiSessionTokenHandler>();


builder.Services.AddDbContext<ChangeSchedulerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ChangeSchedulerContext")));
builder.Services.AddTransient<IRepository<ChangeTask>, ChangeTaskRepository>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddTransient<IAccountService, AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ChangeSchedulerContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
