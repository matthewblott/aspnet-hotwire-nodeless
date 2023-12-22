using aspnet_hotwire.Hubs;
using aspnet_hotwire.Services;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IRazorPartialToStringRenderer, RazorPartialToStringRenderer>();
builder.Services.AddSignalR();

var app = builder.Build();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "Views", "Foo", "Scripts")),
    RequestPath = "/foo-js"
});
app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "Views", "Hello", "Scripts")),
    RequestPath = "/hello-js"
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
