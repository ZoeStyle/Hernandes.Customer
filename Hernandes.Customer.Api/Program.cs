using Hernandes.Customer.Api;
using Hernandes.Customer.Application.Handlers;
using Hernandes.Customer.Application.Repositories;
using Hernandes.Customer.Infra.Context;
using Hernandes.Customer.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddResponseCompression();

builder.Services.AddScoped<IStoreDataContext, StoreDataContext>();

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<CustomerHandler, CustomerHandler>();

var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option =>
{
    option.RequireHttpsMetadata = false;
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hernandes Customer",
        Version = "v1",
        Description = "Hernandes Customer",
        Contact = new OpenApiContact
        {
            Name = "Victor Hernandes",
            Email = "regiotimao@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/victor-hernandes-57412562/")
        }
    });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter into field the word 'Bearer' following by space and the access_token (JWT)",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement {
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
                    }
                  });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    option.IncludeXmlComments(xmlPath);
    option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Hernandes.Customer.Application.xml"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCompression();

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "Hernandes Customer");
    //x.RoutePrefix = string.Empty;
});


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();