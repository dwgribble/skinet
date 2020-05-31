using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        // This product has an id and a name for the app
        // What would assignments have?  content pieces?

        // Our first "Product" entity should be pdfs or something?
        public int Id { get; set; }

        public string Name { get; set; }

        // table in database is created, 2 columns id and name after Migrations
    }
}
