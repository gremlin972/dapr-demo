var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddConcurrencyLimiter("concurrency", options =>
    {
        options.PermitLimit = 3;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 9999999;
    });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapDefaultControllerRoute();

app.UseRateLimiter();

await app.RunAsync();

