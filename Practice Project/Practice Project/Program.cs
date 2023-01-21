using Autofac;
using Autofac.Extensions.DependencyInjection;
using Practice_Project;
using Practice_Project.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
builder.Services.AddTransient<ITestModel,TestModel>();  

//Autofac Configuration
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());  //this line used for Add aurifac as a depedency Injection

//Which module we load our project
builder.Host.ConfigureContainer<ContainerBuilder>(e =>
{
    e.RegisterModule(new WebModule());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area=exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
