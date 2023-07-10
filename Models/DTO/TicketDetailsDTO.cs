using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.DTO
{
    public class TicketDetailsDTO
    {
        [Required]
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
