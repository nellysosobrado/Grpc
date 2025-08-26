using Grpc.Core;

namespace GrpcServer.Services;

public class ProductSerivce: ProductHandler.ProductHandlerBase
{
    private List<Product> _products =
    [
        new() { Id = 1, Name = "Product 1", Price = 10.0 },
        new() { Id = 2, Name = "Product 2", Price = 20.0 },
        new() { Id = 3, Name = "Product 3", Price = 30.0 },
    ];
    public override Task<GetProductsReply> GetProducts(GetProductsRequests request, ServerCallContext context)
    {
        var reply = new GetProductsReply();
        reply.Products.AddRange(_products);

        return Task.FromResult(reply);

    }
}
