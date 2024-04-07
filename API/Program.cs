using API;
using Application;
using Infrastructure;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}




//TODO: ADD GIT IGNORE
//TODO: CONFIGURE ALL LAYERS AND DEPENDENCIES BETWEEN EACH OTHERS
//TODO: CONFIGURE EF