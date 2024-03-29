namespace MovieApp.Models
{
    public class AddToOrderDTO
    {
        public Guid SelectedTicketId { get; set; }
        public int Quantity { get; set; }
    }
}
