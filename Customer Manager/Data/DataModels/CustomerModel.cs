using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Manager.Data.DataModels
{
    public class CustomerModel
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50), Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [MaxLength(100), Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [MaxLength(100), Column(TypeName = "nvarchar(100)")]
        public string? Address { get; set; }

        [MaxLength(50), Column(TypeName = "nvarchar(50)")]
        public string? JobTitle { get; set; }

        [MaxLength(30), Column(TypeName = "nvarchar(30)")]
        public string? Phone { get; set; }

        [MaxLength(20), Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsAdmin { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        [Column(TypeName = "datetime")]
        public DateTime? Birthday { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
