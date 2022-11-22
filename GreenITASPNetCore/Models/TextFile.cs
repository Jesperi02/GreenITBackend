using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenITASPNetCore.Models
{
    public class TextFile
    {
        public long Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
        public string Name { get; set; } = String.Empty;
        [NotMapped]
        public IFormFile? File { get; set; }
        public string Filename { get; set; } = String.Empty;
    }

    public class TextFileDTO
    {
        public long Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
        public string Name { get; set; } = String.Empty;
        public string Filename { get; set; } = String.Empty;
    }
}
