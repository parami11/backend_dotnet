using BH.Backend.AccountService.DataAccess;
using BH.Backend.Models.Db;
using BH.Backend.Models.Validators;
using BH.Backend.TransactionService.DataAccess;
using FluentValidation;
using AccountS = BH.Backend.AccountService.Service;
using CustomerS = BH.Backend.CustomerService.Service;
using TransactionS = BH.Backend.TransactionService.Service;

namespace BH.Backend.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<CustomerS.ICustomerService, CustomerS.CustomerService>();
            builder.Services.AddScoped<IValidator<Account>, AccountEntityValidator>()
                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<AccountS.IAccountService, AccountS.AccountService>();
            builder.Services.AddScoped<IValidator<Transaction>, TransactionEntityValidator>()
                .AddScoped<ITransactionRepository, TransactionRepository>()
                .AddScoped<TransactionS.ITransactionService, TransactionS.TransactionService>();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}