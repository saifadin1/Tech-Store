using TechStore.RepoServices;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.  (DI container)
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBcontext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepoService>();
builder.Services.AddScoped<IBrandRepository, BrandRepoService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepoService>();


var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseAuthorization();

app.Run();
