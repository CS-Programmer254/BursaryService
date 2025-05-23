using Application.Handlers.CommandHandlers.Bursary;
using Application.Handlers.QueryHandlers.Bursary;
using Application.services;
using Application.Services;
using Domain.Data;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=BursaryApplicationServiceDb.db"));

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBursaryRepository,BursaryRepository>();
builder.Services.AddScoped<IBursaryApprovalRepository,BursaryApprovalRepository>();
builder.Services.AddScoped<IFamilyStatusRepository,FamilyStatusRepository>();
builder.Services.AddScoped<IFeeBalanceRepository,FeeBalanceRepository>();
builder.Services.AddScoped<IFinancialSponsorshipRepository,FinancialSponsorshipRepository>();
builder.Services.AddScoped<IParentRepository,ParentRepository>();
builder.Services.AddScoped<IBursaryApprovalStatusRepository,BursaryApprovalStatusRepository>();
builder.Services.AddScoped<IBursaryApplicationService, BursaryApplicationService>();
builder.Services.AddScoped<IBursaryApprovalService, BursaryApprovalService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateBursaryApplicationCommandHandler)));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(UpdateBursaryApplicationCommandHandler)));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetAllBursaryApplicationsQueryHandler)));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetBursaryApplicationByIdQueryHandler)));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetBursaryApplicationsByPhoneNumberQueryHandler)));
builder.Services.AddGrpc();


// Add services to the container.
// Add gRPC Client to call the Auth Service
//builder.Services.AddGrpcClient<AuthService.AuthServiceClient>(o =>
//{
//    o.Address = new Uri("http://localhost:9090");
//});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") 
                  .AllowAnyMethod() 
                  .AllowAnyHeader() 
                  .AllowCredentials();
        });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    dbContext.Database.Migrate();
//}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();  
app.UseCors("AllowReactApp");  
app.UseAuthorization(); 

app.MapControllers();

app.Run();
