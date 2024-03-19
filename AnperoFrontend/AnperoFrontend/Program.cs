using Anpero;
using Anpero.Ultil.Caching;
using AnperoControl;
using AnperoControl.Inteface;
using AnperoControl.Interface;
using AnperoFrontend.Bussiness;
using AnperoModels;
using ServiceStack;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSingleton<IClientControl, ClientControl>();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICacheService, CacheHelper>();
builder.Services.AddSingleton<ICommonDataControl, CommonDataControl>();
builder.Services.AddSingleton<IBuildModuleInteface, BuildModuleControl>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//Compression in IIS
//app.UseResponseCompression();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
