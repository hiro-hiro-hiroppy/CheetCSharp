// 備忘録
// クロスオリジン要求
// https://docs.microsoft.com/ja-jp/aspnet/core/security/cors?view=aspnetcore-6.0


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// クロスオリジン要求 追加 --------------------------------------------------
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://example.com",
                                              "http://www.contoso.com");
                      });
});
// ----------------------------------------------------------------------

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// クロスオリジン要求 追加------------------------------
app.UseCors(MyAllowSpecificOrigins);
//--------------------------------------------------

app.UseAuthorization();

app.MapControllers();

app.Run();
