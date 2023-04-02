using Context;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy  => {
        policy.WithOrigins("http://localhost:8080")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<TodoDbContext>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.MapControllers();
app.Run();
