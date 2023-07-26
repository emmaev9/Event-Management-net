namespace TicketMS.Models.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set;}
        public int CustomerID { get; set;}
        public int TicketCategoryID { get; set;}
        public float TotalPrice { get; set;}
        public int NumberOfTickets { get; set;}
        public DateTime? OrderAt { get; set;}
    }
}
