using CRM.Application;
using CRM.Infrastructure;
using CRM.Infrastructure.Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Serilog;
using Serilog.Sinks.PostgreSQL;
using NpgsqlTypes;
using System.Collections.Generic;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

var dsBuilder = new NpgsqlDataSourceBuilder(conn);
dsBuilder.MapEnum<TinhTrang>();

var dataSource = dsBuilder.Build();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddIdentity<Nguoidung, IdentityRole<Guid>>().AddEntityFrameworkStores<CrmDbContext>().AddDefaultTokenProviders();


// cấu hình log 
var columnWriters = new Dictionary<string, ColumnWriterBase>
{
    { "message", new RenderedMessageColumnWriter() },
    { "message_template", new MessageTemplateColumnWriter() },
    { "level", new LevelColumnWriter() },
    { "time_stamp", new TimestampColumnWriter() },
    { "exception", new ExceptionColumnWriter() },
    { "properties", new LogEventSerializedColumnWriter() },
    { "log_event", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) }
};

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.PostgreSQL(
        connectionString: "Host=localhost;Port=5432;Database=CRM;Username=App_User;Password=123456",
        tableName: "logs",
        columnOptions: columnWriters,
        needAutoCreateTable: false
    )
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();
builder.Host.UseSerilog();
//-----------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
