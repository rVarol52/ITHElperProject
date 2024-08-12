using DevExpress.AspNetCore;
using ITHelper.Application.Business.Services;
using ITHelper.Application.Business.Services.Interfaces;
using ITHelper.Infranstrucure.DataContext;
using ITHelper.Infranstrucure.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddDbContext<ITHelperContext>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();





builder.Services.AddScoped<IKullaniciService<Kullanici>, KullaniciService>();
builder.Services.AddScoped<IBlogService<Blog>, BlogService>();
builder.Services.AddScoped<IEtiketService<Etiket>, EtiketService>();
builder.Services.AddScoped<IBlogEtiketService<BlogEtiket>, BlogEtiketService>();
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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
