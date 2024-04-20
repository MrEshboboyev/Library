using Library.Web.Service;
using Library.Web.Service.IService;
using Library.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// add HttpClient, HttpContextAccessor
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

// adding HttpClient
builder.Services.AddHttpClient<IBookService, BookService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();

// adding lifetime for services
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// adding urls
SD.BookAPIBase = builder.Configuration["ServiceUrls:BookAPI"];
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
