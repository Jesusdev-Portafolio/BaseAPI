using API;
using Application;
using Infrastructure;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication(builder)
        .AddInfrastructure();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseSerilogRequestLogging();
    app.UseExceptionHandler("/error");
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

    // me creo un exception middleware y re executo la request hacia mi endpoint error
}


//TODO: CONFIGURE EF