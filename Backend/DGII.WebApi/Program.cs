using Microsoft.AspNetCore.Mvc.ApiExplorer;
using DGII.Core.Application;
using DGII.Infrastructure.Persistence;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Versioning;
using DGII.WebApi;
using DGII.Common.Extensions;
using System.Text.Json.Serialization;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


//Implementing SERILOG
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();

builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();


builder.Services.AddControllers()
    .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddVmMaping();

var cultureInfo = new CultureInfo("es-DO");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddCors(o =>
    o.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));



builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("x-api-version"),
        new MediaTypeApiVersionReader("x-api-version"));
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});




var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger();
app.UseSwaggerUI();
//app.UseSwaggerUI(c =>
//{
//    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
//    {
//        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
//            description.GroupName.ToUpperInvariant());
//    }
//    c.RoutePrefix = "";

//});

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseCors("CorsPolicy");
app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
