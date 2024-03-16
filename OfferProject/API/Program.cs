using DAL;
using Business;
using DAL.Repositories;
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataAccess(builder.Configuration).
AddApplication(builder.Environment);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IOfferRepository, OfferRepository>();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyOrigin().AllowAnyHeader();
                      });
});
var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();


app.MapControllers();
app.Run();
