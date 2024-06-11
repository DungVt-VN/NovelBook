using api;
using api.Data;
using api.Interfaces;
using api.Models;
using api.Repository;
using api.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add image containers 
builder.Services.Configure<ImgurSettings>(builder.Configuration.GetSection("ImgurSettings"));

// ----------------------------------------------------------------
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] { }
    }});
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add Entity Password Authentication
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 4;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDBContext>()
.AddDefaultTokenProviders();

// Authentication Middleware
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var signingKey = builder.Configuration["JWT:SigningKey"];
    if (signingKey != null)
    {
        options.RequireHttpsMetadata = false; // for development only
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero // Optional: giảm thời gian sai lệch cho việc hết hạn token
        };
    }
    else
    {
        // Xử lý trường hợp SigningKey là null
        Console.WriteLine("Error: JWT Signing Key is not configured.");
    }
});

// Add Interface Service
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserProfileRepo, UserProfileRepo>();
builder.Services.AddScoped<IBookItemRepo, BookItemRepo>();
builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();

var app = builder.Build();

// // Seed the database.
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var context = services.GetRequiredService<ApplicationDBContext>();

//     var seed = new Seed(context);
//     seed.SeedDataContext();
// }



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true));

app.UseMiddleware<GuestRoleMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
