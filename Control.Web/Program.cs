using Control.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// Инициализация экземпляра строителя приложения
var builder = WebApplication.CreateBuilder(args);

// Подключение базы данных
string connection = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

// Установление модели пользователя и роли, а также хранилища на основе контекста
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

// Подключение аутентификации на основке куки
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

// Регистрация сервисов
builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddScoped<IIssuesService, IssuesService>();

// Добавление сервисов в контейнер.
builder.Services.AddControllersWithViews();

// Построение приложения
var app = builder.Build();

// Настройка конвейера HTTP запросов
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// Базовое HSTS значение - 30 дней. Для изменения данного сценария, перейдите в https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

// Перенаправление HTTP запросов на HTTPS   
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Подключение аутентификации
app.UseAuthentication();

// Подключение авторизации
app.UseAuthorization();

// Установление паттернов маршрутизации
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id1?}/{id2?}");

// Инициализация суперадмина и базовых ролей
using (var serviceScope = app.Services.CreateScope())
{
	var services = serviceScope.ServiceProvider;
	var userManager = services.GetRequiredService<UserManager<User>>();
	var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
	IdentityInitializer.Initialize(userManager, rolesManager);
}

app.Run();
