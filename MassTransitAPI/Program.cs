using MassTransit;
using MassTransitAPI;
using MassTransitData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddSqlMessageScheduler();

    x.AddConsumer<RegistrationBatchConsumer>();

    x.UsingSqlServer((context, cfg) =>
    {
        cfg.UseSqlMessageScheduler();

        cfg.ConfigureEndpoints(context);


        cfg.ReceiveEndpoint("kuyruk1", t =>
        {
            t.Subscribe<SubmitRegistration>();
        });
    });
});

var connectionString = builder.Configuration.GetConnectionString("Db");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString) 
);

builder.Services.AddOptions<SqlTransportOptions>()
    .Configure(options =>
    {
        options.ConnectionString = connectionString;
    });

builder.Services.AddSqlServerMigrationHostedService();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
