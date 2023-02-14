using DataAccess;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

//this line below is necessary
builder.Services.AddDbContext<StonksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StonkDB")));

//added the optional line below for testing
builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("StonkDB")));

//--------- Data Access------------
builder.Services.AddScoped<IWalletDAO, WalletRepository>();
builder.Services.AddScoped<ITransactionDAO, TransactionRepository>();
builder.Services.AddScoped<IUserDAO, UserRepository>();
builder.Services.AddScoped<ICurrencyDAO, CurrencyRepository>();
builder.Services.AddScoped<IProfileDAO, ProfileRepository>();

//----------Services---------------
builder.Services.AddTransient<WalletServices>();
builder.Services.AddTransient<TransactionServices>();
builder.Services.AddTransient<UserServices>();
builder.Services.AddTransient<AuthServices>();
builder.Services.AddTransient<CurrencyServices>();
builder.Services.AddTransient<ProfileServices>();

//----------Controllers------------
builder.Services.AddScoped<WalletController>();
builder.Services.AddScoped<TransactionController>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<CurrencyController>();
builder.Services.AddScoped<ProfileController>();

//------------Swagger--------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();



app.MapGet("/", () => "Hey Gamestonks!\nYou're doing fine!");


//------------Auth-----------------
app.MapPost("/register", async (User user, AuthController controller) => await controller.Register(user));

app.MapPost("/login", async (User user, AuthController controller) => await controller.Login(user));

//------------User-------------
app.MapGet("/user", async (UserController controller) => await controller.GetAllUsers());

app.MapGet("/user/id/{id}", async (int id, UserController controller) => await controller.GetUserById(id));

app.MapGet("/user/email/{email}", async (string email, UserController controller) => await controller.GetUserByEmail(email));

app.MapPost("/create/User", async (User user, UserController controller) => await controller.CreateUser(user));

app.MapPut("/update/User", async (User user, UserController controller) => await controller.UpdateUser(user));

//------------profile-----------
app.MapGet("/profile", async (ProfileController controller) => await controller.GetAllProfiles());

app.MapGet("/profile/{id}", async (int id, ProfileController controller) => await controller.GetProfileById(id));

app.MapGet("/profile/user/{id}", async (int user_id, ProfileController controller) => await controller.GetProfileByUserId(user_id));

app.MapPost("/create/profile", async (Profile profile, ProfileController controller) => await controller.CreateProfile(profile));

app.MapPut("/update/profile", async (Profile profile, ProfileController controller) => await controller.UpdateProfile(profile));

//-----------currency-----------
app.MapGet("/Currency", async (CurrencyController controller) => await controller.GetAllCurrencies());

app.MapGet("/Currency/{ID}", async (int ID, CurrencyController controller) => await controller.GetCurrencyById(ID));

app.MapGet("/Currency/{Symbol}", async (string symbol, CurrencyController controller) => await controller.GetCurrencyBySymbol(symbol));

app.MapPost("/submit/Currency", async (Currency currency, CurrencyController controller) => await controller.CreateCurrency(currency));

app.MapPut("/update/Currrency", async (Currency currency, CurrencyController controller) => await controller.UpdateCurrency(currency));

//------------Wallet---------------
app.MapGet("/wallet", async (WalletController controller) => await controller.GetAllWallets());

app.MapGet("/wallet/user/{ID}", async (int ID, WalletController controller) => await controller.GetAllWalletsByUserId((int) ID));

app.MapPost("/submit/wallet", async ([FromBody] Wallet wallet, WalletController controller) => await controller.CreateWallet(wallet));

app.MapPut("/update/wallet", async ([FromBody] Wallet wallet,WalletController controller) => await controller.UpdateWallet(wallet));

//-----------Transaction-----------
app.MapGet("/transaction", async (TransactionController controller) => await controller.GetAllTransactions());

app.MapGet("/transaction/{ID}", (int ID, TransactionController controller) => controller.GetTransactionById(ID));

app.MapGet("/transaction/wallet/{ID}", (int ID, TransactionController controller) => controller.GetAllTransactionsByWalletId(ID));

app.MapGet("/transaction/currency/{ID}", (int ID, TransactionController controller) => controller.GetAllTransactionsByWalletId(ID));

app.MapGet("/transaction/wallet/{wallet_id}/currency{currency_id}", (int wallet_id, int currency_id, TransactionController controller) => controller.GetAllTransactionsByCurrencyIdAndWalletId(currency_id, wallet_id));

app.MapPost("/submit/transaction", (Transaction newTransaction, TransactionController controller) => controller.CreateTransaction(newTransaction));

app.MapPut("/update/transaction", (Transaction newTransaction, TransactionController controller) => controller.UpdateTransaction(newTransaction));







app.Run();
