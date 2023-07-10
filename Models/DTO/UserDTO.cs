using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.DTO
{
    public class UserDTO
    { 
    
    
        public int Id { get; set; }

        //these are the validations used to verify the values entred is correct or not.
        
        public string? Name { get; set; }    
      

        public string? Email { get; set; }

        public int? Age { get; set; }

        public string? UserPhoto { get; set; }
       
        public double? Phone { get; set; }


    }


    
}
