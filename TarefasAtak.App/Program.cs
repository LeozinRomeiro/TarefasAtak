using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using TarefasAtak.App;
using TarefasAtak.App.Servicos;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient(
    Configuration.HttpClientName,
    x =>
    {
        x.BaseAddress = new Uri(Configuration.UrlApi);
    }
    );

builder.Services.AddTransient<TarefaServico>();

await builder.Build().RunAsync();
