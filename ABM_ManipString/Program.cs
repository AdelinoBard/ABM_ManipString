using ABM_ManipString.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container DI
builder.Services.AddScoped<StringManipulacaoService>();
builder.Services.AddControllers();  // Necessário para suportar controllers MVC

// Configura os serviços necessários para controladores com views
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configura as rotas para controladores com views
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
