using MudBlazor.Services;
using SpecificationDesignPattern.Migrations;
using SpecificationDesignPattern.UI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IMovieService, MovieService>();

builder.Services.AddDbContextFactory<SpecPatternReadDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x =>
    {
        x.MigrationsAssembly(typeof(MigrationsAssembly).Assembly.GetName().Name);
    })
#if DEBUG
    .EnableSensitiveDataLogging()
#endif
);

builder.Services.AddMudServices();

var app = builder.Build();
var runMigration = app.RunMigrationAsync();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await runMigration;
app.Run();
