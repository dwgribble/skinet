using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Identity
{
    public class Address
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        // note in the lecture here, have to add [Required] attribute
        // to the property of the string AppUserId but I'm not sure where to put it
        [Required()]
        public string AppUserId { get; set; } 

        public AppUser AppUser { get; set; }
    }
}