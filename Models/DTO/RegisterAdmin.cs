namespace WebApp.Models.DTO
{
    public class RegisterAdmin
    {
        public string Admin_Name { get; set; }
        public string Name { get; set; }    
        public string Password { get; set; }

        // this is like  Role = AdminType
        public string Admin_Type { get; set; } 

    }
}
