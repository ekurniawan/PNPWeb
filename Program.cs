using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyASPApp.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//menambahkan pengaturan identity
/*builder.Services.AddIdentity<IdentityUser,IdentityRole>(options=>{
    options.Password.RequiredLength = 10;
}).AddDefaultUI().AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();*/

builder.Services.AddDefaultIdentity<IdentityUser>(
    options=>options.SignIn.RequireConfirmedAccount=true
    ).AddEntityFrameworkStores<AppDbContext>();

//mendaftarkan EF
builder.Services.AddDbContext<AppDbContext>(
    options=>options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

//menggunakan DI
builder.Services.AddTransient<ITrainer,TrainerDAL>();

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
app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
