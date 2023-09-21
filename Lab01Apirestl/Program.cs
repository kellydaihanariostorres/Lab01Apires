using Lab01Apirestl.Extensions;
using Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using NLog;
using Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);


builder.Services.AddControllers()
.AddApplicationPart(typeof(CompanyEmployee.Presentation.AssemblyReference).Assembly);



var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
{
app.UseHsts();
}


//if (app.Environment.IsDevelopment())
//    app.UseDeveloperExceptionPage();
//else
//    app.UseHsts();

//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

//app.Run(async context => {
//    await context.Response.WriteAsync("Hello from the middleware component."); 
//});

//app.Use(async (context, next) => { 
//    Console.WriteLine($"Logic before executing the next delegate in the Use method");
//    await next.Invoke(); 
//    Console.WriteLine($"Logic after executing the next delegate in the Use method");
//});

//app.Map("/usingmapbranch", builder => { builder.Use(async (context, next) => 
//{ 
//    Console.WriteLine("Map branch logic in the Use method before the next delegate");
//    await next.Invoke();
//    Console.WriteLine("Map branch logic in the Use method after the next delegate");
//}); 
//    builder.Run(async context => { Console.WriteLine($"Map branch response to the client in the Run method"); 
//        await context.Response.WriteAsync("Hello from the map branch.");
//    }); 
//});

//app.MapWhen(context => context.Request.Query.ContainsKey("testquerystring"), builder => {
//    builder.Run(async context => {
//        await context.Response.WriteAsync("Hello from the MapWhen branch.");
//    });
//});

//app.Run(async context => {
//    Console.WriteLine($"Writing the response to the client in the Run method");
//    await context.Response.WriteAsync("Hello from the middleware component.");
//});

app.MapControllers();

app.Run();



namespace Microsoft.AspNetCore.Http
{
    public delegate Task RequestDelegate(HttpContext context);
}