using aspnet_hotwire_nodeless.Hubs;
using aspnet_hotwire_nodeless.Services;
using Microsoft.Extensions.FileProviders;
using Westwind.AspNetCore.LiveReload;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IRazorPartialToStringRenderer, RazorPartialToStringRenderer>();
builder.Services.AddLiveReload(config =>
{
  // optional - use config instead
  // config.LiveReloadEnabled = true;
  // config.FolderToMonitor = Path.GetFullname(Path.Combine(Env.ContentRootPath,"..")) ;
});
builder.Services.AddSignalR();

var app = builder.Build();

app.UseLiveReload();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "Views", "Foo", "js")),
    RequestPath = "/js"
});
app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "Views", "Hello", "js")),
    RequestPath = "/js"
});

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
  endpoints.MapControllers();
  endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapHub<AppHub>("/appHub");
app.Run();
