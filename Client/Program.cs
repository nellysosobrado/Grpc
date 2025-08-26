using Grpc.Net.Client;
using GrpcClient;



var channel = GrpcChannel.ForAddress("https://localhost:7232");
var greeterClient = new Greeter.GreeterClient(channel);    
var productClient= new ProductHandler.ProductHandlerClient(channel);

Console.WriteLine("Press Any Key to continue");
Console.ReadKey();

var helloReplay = await greeterClient.SayHelloAsync(new HelloRequest { Name = "Nelly" });
Console.WriteLine($"Response: {helloReplay.Message}");
Console.ReadKey();


var fullNameReply = await greeterClient.GetFullNameAsync(new FullNameRequest { FirstName = "Nelly", LastName="Sosobrado" });
Console.WriteLine($"Response: {fullNameReply.FullName}");
Console.ReadKey();

var productReply = await productClient.GetProductsAsync(new GetProductsRequests { });
foreach(var product in productReply.Products)
    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");

Console.ReadKey();
