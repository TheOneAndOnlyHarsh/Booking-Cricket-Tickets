using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class User
    {
        // we want this to primary key and update by 1:


        // AUTOMATIC ID MANAGEMNET:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public int Age { get; set; }

        // we don't want these two fields in DTO
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateTime { get; set; }

        public string UserPhoto { get; set; }

        public double Phone { get; set; }
    }
}
