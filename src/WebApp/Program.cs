using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor;
});

var app = builder.Build();

app.UseForwardedHeaders();

app.MapGet("/", (HttpContext context) =>
{
    return context.Connection.RemoteIpAddress.ToString();
});

app.Run();
