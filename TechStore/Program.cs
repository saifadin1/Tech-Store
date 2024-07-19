var builder = WebApplication.CreateBuilder(args);



// Add services to the container.  (DI container)
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBcontext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();
app.Run();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseAuthorization();



