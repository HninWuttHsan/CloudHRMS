using System.ComponentModel.DataAnnotations;

namespace CloudHRMS.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public required string Id { get; set; } // for primary key in DB
        public required DateTime CreatedAt { get; set; } // for audi purpose
        public required string CreatedBy { get; set; }// for audir purpose
        public DateTime? UpdatedAt { get; set; }// for audir purpose
        public string? UpdatedBy { get; set; }// for audir purpose
        public required string Ip { get; set; }// for audir purpose
        public bool IsActive { get; set; }// soft delete ( no delete in DB - change only status)
    }
}
