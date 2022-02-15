using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [StringLength(36)]
        public string CardId { get; set; }

        [Required]
        [ForeignKey(nameof(CardId))]
        public Cart Cart { get; set; }
    }
}