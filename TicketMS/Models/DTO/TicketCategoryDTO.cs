namespace TicketMS.Models.DTO
{
    public class TicketCategoryDTO
    {
        public int TicketCategoryid { get; set; }
        public string Description { get; set; } = null!;
        public float Price { get; set; }
        public int? Eventid { get; set; }
    }
}
