using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.DTO
{
    public class TicketUpdateDTO
    {

        [Required]
        public int Id { get; set; }

        [Required]

        public int TicketId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
