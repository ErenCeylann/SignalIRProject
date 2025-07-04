using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalRDataAccessLayer.Concrete;
using SignalREntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

var requiredAuthorizePolicy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requiredAuthorizePolicy));
});

builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Login/Index";
});

builder.Services.AddHttpClient();

var app = builder.Build();

app.UseStatusCodePages(async x =>
{
    if (x.HttpContext.Response.StatusCode==404)
    {
        x.HttpContext.Response.Redirect("/Error/NotFount404Page");
    }
});

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
