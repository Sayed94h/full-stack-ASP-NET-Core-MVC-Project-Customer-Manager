using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Customer_Manager.Models
{
    public class CustomerViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string? Address { get; set; }

        public string? JobTitle { get; set; }

        public string? Phone { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; } 

        public bool IsAdmin { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
