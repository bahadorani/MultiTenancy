using Microsoft.EntityFrameworkCore;
using Sample.Api;
using Sample.Application.Interface;
using Sample.Application.Services;
using Sample.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// tenant setter & getter
builder.Services.AddScopedAs<TenantService>(new[] { typeof(ITenantGetter), typeof(ITenantSetter) });

// IOptions version of tenants
builder.Services.Configure<TenantConfigurationSection>(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddDbContext<MultiTenantContext>((s, o) =>
{
    var tenant = s.GetService<ITenantGetter>()?.Tenant;
   var connectionString = tenant?.ConnectionString;
   // multi-tenant databases
   o.UseSqlServer(connectionString);
});
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<MultiTenantServiceMiddleware>();

var app = builder.Build();

// middleware that reads and sets the tenant
app.UseMiddleware<MultiTenantServiceMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.MapGet("/", async (MultiTenantContext db) => await db
    .Users
    .Select(x => new { x.Id, x.Name, x.Email })
    .ToListAsync());
app.MapGet("/p", async (ApplicationContext db) => await db
    .Products
    .Select(x => new { x.Id, x.Caption, })
    .ToListAsync());

app.Run();
