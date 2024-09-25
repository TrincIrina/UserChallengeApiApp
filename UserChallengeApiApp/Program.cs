using UserChallengeApiApp.Crypto;
using UserChallengeApiApp.Model;
using UserChallengeApiApp.Plug;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<IUserStorage, UserStorageStub>();
builder.Services.AddTransient<IEncoder, MD5Encoder>();

var app = builder.Build();

app.MapControllers();


app.Run();
