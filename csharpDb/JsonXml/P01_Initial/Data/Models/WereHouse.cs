namespace P01_Initial.Data.Models
{
    using System.Collections.Generic;

    public class WereHouse
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public ICollection<ProductWerehouse> ProductWerehouses { get; set; }
    }
}
