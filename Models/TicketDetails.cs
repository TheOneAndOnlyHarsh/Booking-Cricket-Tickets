using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class TicketDetails
    {

        
        [Key ,DatabaseGenerated(DatabaseGeneratedOption.None)]
        // we do not want to update this.
        public int TicketId { get; set; }
        // this is added for forgien:

        [ForeignKey("User")]
        public int Id { get; set; }

        // for navigation property we have a key:

        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
