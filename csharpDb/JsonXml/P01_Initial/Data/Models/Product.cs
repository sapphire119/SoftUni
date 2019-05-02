namespace P01_Initial.Data.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("user")] //това което е "user" във стринга влиза като "Name"
        public string Name { get; set; }

        public string Description { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<ProductWerehouse> ProductWerehouses { get; set; }
    }
}
