
using TestTask.BLL.Interfaces.Accounts;
using TestTask.BLL.Interfaces.Contacts;
using TestTask.BLL.Interfaces.Incidents;
using TestTask.BLL.Services.Accounts;
using TestTask.BLL.Services.Contacts;
using TestTask.BLL.Services.Incidents;
using TestTask.DAL.Repositories.Interfaces;
using TestTask.DAL.Repositories.Realization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TestTask.DAL.TestTaskDBContext>();

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IIncidentService, IncidentService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
