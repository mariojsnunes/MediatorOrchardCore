using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(
    (context, options) =>
    {
        options.AddServerHeader = false;
        options.Limits.MaxRequestBodySize = 157286400;
    }
);

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

//builder.Services.AddMediator(opts =>
//{
//    opts.ServiceLifetime = ServiceLifetime.Transient;
//});

var ocBuilder = builder.Services.AddOrchardCms();

builder.Services.AddResponseCompression();

if (builder.Environment.IsProduction())
{
    builder.Services.AddHsts(options =>
    {
        options.Preload = true;
        options.IncludeSubDomains = true;
        options.MaxAge = TimeSpan.FromDays(60);
    });
}

builder.Services.AddAntiforgery(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

var app = builder.Build();

app.UseResponseCompression();
app.UseOrchardCore();

await app.RunAsync();
