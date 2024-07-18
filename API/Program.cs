using Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();



builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrador", policy =>
    {
        policy.RequireRole("Administrador");
    });
    
    options.AddPolicy("Professor", policy =>
    {
        policy.RequireRole("Professor");
    });
    
    options.AddPolicy("Aluno", policy =>
    {
        policy.RequireRole("Aluno");
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
