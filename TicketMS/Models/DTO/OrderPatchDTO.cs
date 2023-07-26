namespace TicketMS.Models.DTO
{
    public class OrderPatchDTO
    {
        public int OrderID { get; set; }
        public float TotalPrice { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
