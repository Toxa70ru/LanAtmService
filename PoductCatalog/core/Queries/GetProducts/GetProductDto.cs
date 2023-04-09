namespace ProductCatalog.core.Queries.GetProducts
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Product_name { get; set; }
        public int Brend_id { get; set; }
        public string Description { get; set; }
        public string Characteristic { get; set; }
        public int Category_id { get; set; }
        public int Price { get; set; }
    }
}
