using Demo63Assignment.Models;
using Demo63Assignment.Models.DataModel;
using Demo63Assignment.Models.Interface;
using Demo63Assignment.Models.Service;
using Demo63Assignment.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
AddDependacyInjection(builder);
 

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

void AddDependacyInjection(WebApplicationBuilder builder)
{
    var ConnectionString = builder.Configuration.GetConnectionString("defaultConnection");
    builder.Services.AddDbContext<UserMgtContext>(options => options.UseSqlServer(ConnectionString));
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
    builder.Services.AddScoped<ICrudService<UserViewModel>, UserService>();
    builder.Services.AddScoped<ICrudService<DepartmentViewModel>, DepartmentService>();
    builder.Services.AddScoped<IDepartmentService, DepartmentService>();
    builder.Services.AddScoped<IUserService,UserService>();
}