namespace MovieApp.Models
{
    public class OrderDTO
    {
        public List<TicketInOrder>? AllTickets { get; set; }
        public double TotalPrice { get; set; }
    }
}
