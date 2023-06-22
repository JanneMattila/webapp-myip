using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor
});

app.MapGet("/", (HttpContext context) =>
{
    return context.Connection.RemoteIpAddress.ToString();
});

app.Run();
