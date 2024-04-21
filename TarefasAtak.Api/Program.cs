using TarefasAtak.Api.Extensions;
using TarefasAtak.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.AddDatabase();
builder.Services.AddCors(
    x=>x.AddPolicy(
        Configuration.CorsPolicyName,
        policy=> policy
            .WithOrigins([Configuration.UrlApp,Configuration.UrlApp,Configuration.UrlAppHTTPS])
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
        ));
builder.AddTarefaContext();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(Configuration.CorsPolicyName);

app.MapControllers();

app.Run();
