using MediatR;

namespace ProductCatalog.core.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<IList<GetProductDto>>
    {
    }
}
