using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.DTO
{
    public class TicketCreateDTO
    {
        [Required]
        public int Id { get; set; }
        public int TicketId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
