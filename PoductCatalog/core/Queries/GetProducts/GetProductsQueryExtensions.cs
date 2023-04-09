using ProductCatalog.Interfaces.Models;

namespace ProductCatalog.core.Queries.GetProducts
{
    public static class GetProductsQueryExtensions
    {
        public static GetProductDto MapTo(this Product movie)
        {
            return new GetProductDto
            {
                Id = movie.Id,
                Characteristic = movie.Characteristic,
                Description = movie.Description,
                Product_name = movie.Product_name,
                Price = movie.Price,
                Brend_id = movie.Brend_id,
                Category_id = movie.Category_id

            };
        }
    }
}
