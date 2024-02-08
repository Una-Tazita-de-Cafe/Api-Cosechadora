var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
 //cors
 builder.Services.AddCors(options=>options.AddPolicy("AllowWebapp",
                                          builder=>builder.AllowAnyOrigin()
                                                           .AllowAnyHeader()
                                                           .AllowAnyMethod()));
var app = builder.Build();
app.UseCors("AllowWebapp");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
