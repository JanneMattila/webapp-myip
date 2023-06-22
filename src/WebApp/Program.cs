var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    return context.Connection.RemoteIpAddress.ToString();
});

app.Run();
