using ProCreditBankZadacha;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
string mt799Message = ":Field1:Value1\r\n:Field2:Value2\r\n";


SwiftMT799Parser parser = new SwiftMT799Parser();


SwiftMT799Parser.SwiftMT799Message parsedMessage = parser.ParseMT799(mt799Message);

Console.WriteLine("Field1: " + parsedMessage.Field1);
Console.WriteLine("Field2: " + parsedMessage.Field2);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();