using System.ComponentModel.DataAnnotations;

namespace MyEmotiApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? HashPassword { get; set; }
    }
}