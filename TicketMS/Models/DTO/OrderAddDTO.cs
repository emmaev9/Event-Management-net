namespace TicketMS.Models.DTO
{
    public class OrderAddDTO
    {
        public int CustomerID { get; set; }
        public int TicketCategoryID { get; set; }
        public int EventId { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
