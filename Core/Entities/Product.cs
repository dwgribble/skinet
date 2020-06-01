using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        // This product has an id and a name for the app
        // What would assignments have?  content pieces?

        // Our first "Product" entity should be pdfs or something?
        // this gets moved to BaseEntity
        //public int Id { get; set; }
        

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public int ProductBrandId { get; set; }

        // table in database is created, 2 columns id and name after Migrations
    }

    
}
