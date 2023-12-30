using RAFWEB.Core;
using RAFWEB.API.Configuration;
using IdentityModel.AspNetCore.OAuth2Introspection;
using RAFWEB.API.Configuration.Identity;
using IdentityServer4;
using IdentityServer4.AccessTokenValidation;
using RAFWEB.API.Configuration.Extentions;
using RAFWEB.API.Configuration.IdentityServer;
using System.Security.Claims;
using MediatR;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddIdentity();
builder.Services.AddRepositoreis();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddIdentityServerInfrastructure(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.AddApplicationLayer();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(IdentityServerConstants.LocalApi.PolicyName, policy =>
    {
        policy.AddAuthenticationSchemes(IdentityServerConstants.LocalApi.AuthenticationScheme)
            .RequireClaim("scope", "openid", "role");
    });

    options.AddPolicy("Teacher", policy => policy.RequireRole("Teacher"));
    options.AddPolicy("Moderator", policy => policy.RequireRole("Moderator"));
    options.AddPolicy("Student", policy => policy.RequireRole("Student"));
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
})
    .AddLocalApi(options =>
    {
        options.ExpectedScope = IdentityServerConstants.LocalApi.ScopeName;
        options.SaveToken = true;
    })
    .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Authority = builder.Configuration.GetValue<string>("ServerUrl");
        options.SupportedTokens = SupportedTokens.Jwt;
        options.RequireHttpsMetadata = false;
        options.RoleClaimType = ClaimTypes.Role;
        options.NameClaimType = ClaimTypes.Name;
        options.ApiName = IdentityServerConstants.LocalApi.ScopeName;
        options.TokenRetriever = req =>
        {
            var fromHeader = TokenRetrieval.FromAuthorizationHeader();
            var fromQuery = TokenRetrieval.FromQueryString();
            var result = fromHeader(req) ?? fromQuery(req);
            return result;
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
ScopeCreation.ConfigureScope(app);



app.UseIdentityServer();

app.UseRouting();



app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
