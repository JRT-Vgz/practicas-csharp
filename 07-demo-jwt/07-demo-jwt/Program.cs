using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string key = "khsdkjJHLKJHDF87875FFLkKJfg87fbiTiviUFGI6Utriu6FVIUFIv";

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
{
    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

    opt.RequireHttpsMetadata = false;

    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = signingKey
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();



app.MapGet("hello", () => "Hello World!")
.WithName("Hello")
.WithOpenApi();

app.MapGet("hello/protected", (ClaimsPrincipal user) => $"Hello World Protected! Hola {user.Identity.Name}")
.RequireAuthorization()
.WithName("HelloProtected")
.WithOpenApi();

app.MapGet("hello/protectedwithscope", (ClaimsPrincipal user) => $"Hello World Protected! Hola {user.Identity.Name}")
.RequireAuthorization(e => e.RequireClaim("scope", "myapi:drunk"))
.WithName("HelloProtectedWithClaim")
.WithOpenApi();

app.MapGet("/auth/{user}/{pass}",(string user, string pass) =>
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var byteKey = Encoding.UTF8.GetBytes(key);
    var tokenDes = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, user),
            new Claim("scope", "myapi:drunk")
        }),
        Expires = DateTime.UtcNow.AddMonths(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey), 
                                                        SecurityAlgorithms.HmacSha256Signature)
    };

    var token = tokenHandler.CreateToken(tokenDes);
    return tokenHandler.WriteToken(token);
})
.WithName("AuthToken")
.WithOpenApi();



app.Run();

