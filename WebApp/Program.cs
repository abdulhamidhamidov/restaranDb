using Infrostructure.DataContext;
using Infrostructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IDapperContext,DapperContext>();
builder.Services.AddSingleton<ICustomerService,CustomerService>();
builder.Services.AddSingleton<IMenuItemService,MenuItemService>();
builder.Services.AddSingleton<ITableService,TableService>();
builder.Services.AddSingleton<IOrderService,OrderService>();
builder.Services.AddSingleton<IQueryService,QueryService>();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options=>options.SwaggerEndpoint("/openapi/v1.json",":"));
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
