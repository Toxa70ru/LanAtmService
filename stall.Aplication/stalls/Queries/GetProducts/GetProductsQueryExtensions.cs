using stall.Domain.seller;

namespace stall.Application.stalls.Queries.GetProducts
{
    public static class GetProductsQueryExtensions
    {
        public static GetProductDto MapTo(this Product movie)
        {
            return new GetProductDto
            {
                Product_id = movie.Product_id,
                Characteristic = movie.Characteristic,
                Description = movie.Description,
                Product_name = movie.Product_name,
                Price = movie.Price
            };
        }
    }
}