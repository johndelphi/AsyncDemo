using AsyncDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ClaimProcessor>();
builder.Services.AddScoped<PolicyService>();
builder.Services.AddScoped<FraudService>();
builder.Services.AddScoped<CoverageService>();
builder.Services.AddScoped<PayoutService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();