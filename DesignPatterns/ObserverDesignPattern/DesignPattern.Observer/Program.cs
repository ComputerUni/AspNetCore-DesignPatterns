using DesignPattern.Observer.DAL;
using DesignPattern.Observer.ObserverPattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<CreateWelcomeMessage>();
builder.Services.AddScoped<CreateMagazineAnnouncement>();
builder.Services.AddScoped<CreateDiscountCode>();

builder.Services.AddScoped<ObserverObject>(sp =>
{
    var observerObject = new ObserverObject();
    observerObject.RegisterObserver(sp.GetRequiredService<CreateWelcomeMessage>());
    observerObject.RegisterObserver(sp.GetRequiredService<CreateMagazineAnnouncement>());
    observerObject.RegisterObserver(sp.GetRequiredService<CreateDiscountCode>());
    return observerObject;
});

builder.Services.AddControllersWithViews();

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
