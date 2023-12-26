using Control.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// ������������� ���������� ��������� ����������
var builder = WebApplication.CreateBuilder(args);

// ����������� ���� ������
string connection = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

// ������������ ������ ������������ � ����, � ����� ��������� �� ������ ���������
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

// ����������� �������������� �� ������� ����
builder.Services.ConfigureApplicationCookie(options =>
{
	options.ExpireTimeSpan = TimeSpan.FromHours(24);
	options.LoginPath = "/Users/Login";
	options.LogoutPath = "/Users/Logout";
	options.Cookie = new CookieBuilder
	{
		IsEssential = true
	};
});

// ����������� ��������
builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddScoped<IIssuesService, IssuesService>();

// ���������� �������� � ���������.
builder.Services.AddControllersWithViews();

// ���������� ����������
var app = builder.Build();

// ��������� ��������� HTTP ��������
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// ������� HSTS �������� - 30 ����. ��� ��������� ������� ��������, ��������� � https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

// ��������������� HTTP �������� �� HTTPS   
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// ����������� ��������������
app.UseAuthentication();

// ����������� �����������
app.UseAuthorization();

// ������������ ��������� �������������
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id1?}/{id2?}");

// ������������� ����������� � ������� �����
using (var serviceScope = app.Services.CreateScope())
{
	var services = serviceScope.ServiceProvider;
	var userManager = services.GetRequiredService<UserManager<User>>();
	var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
	IdentityInitializer.Initialize(userManager, rolesManager);
}

app.Run();
