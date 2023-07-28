namespace TicketMS.Models.DTO
{
    public class OrderPatchDTO
    {
        public int OrderID { get; set; }
        public int TicketCategoryID { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
