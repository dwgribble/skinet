namespace API.Dtos
{
    public class ProductToReturnDto
    {
        // moves data between layers, usually doesn't contain business logic
        // returns data to client?  browser window?
        public int Id {get; set;}
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public string ProductType { get; set; }

        public string ProductBrand { get; set; }

        
    }
}