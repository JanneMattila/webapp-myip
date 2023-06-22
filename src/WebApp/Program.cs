using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor;

    // Only loopback proxies are allowed by default.
    // Clear that restriction to allow any proxy.
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();

app.UseForwardedHeaders();

app.MapGet("/", (HttpContext context) =>
{
    return context.Connection.RemoteIpAddress.ToString();
});

app.Run();
