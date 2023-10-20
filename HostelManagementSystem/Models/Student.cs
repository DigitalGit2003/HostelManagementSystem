using Microsoft.AspNetCore.Identity;

namespace HostelManagementSystem.Models
{
    public class Student : IdentityUser
    {
        public string Name { get; set; }
        public DateTime dob { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        // 
        public Room room { get; set; }
        public int roomId { get; set; }

    }
}
