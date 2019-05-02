namespace BusTicket.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        public int AcountNumber { get; set; }

        public decimal Balance { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
