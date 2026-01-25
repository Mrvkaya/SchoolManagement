using Microsoft.EntityFrameworkCore;
using SMIS.DAL.Context;
using SMIS.BLL.Interface;
using SMIS.BLL.Services;
using SMIS.DAL.Repositories.Interfaces;
using SMIS.DAL.Repositories.Ef;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache(); // Session çalýþabilmesi için RAM de geçici alan oluþturuyoruz.

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
builder.Services.AddScoped<ITeacherLessonService, TeacherLessonService>();
builder.Services.AddScoped<ILessonScheduleService, LessonScheduleService>();
builder.Services.AddScoped<IParentStudentService, ParentStudentService>();
builder.Services.AddScoped<ILessonAttendanceService, LessonAttendanceService>();


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SchoolManagementDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();
  
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
