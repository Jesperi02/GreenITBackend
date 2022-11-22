using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GreenITASPNetCore.Models
{
    public class TextFile
    {
        public long Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
        public string Name { get; set; } = String.Empty;
        public IActionResult? File { get; set; }
    }

    public class TextFileDTO
    {
        public long Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
        public string Name { get; set; } = String.Empty;
        public string File { get; set; } = String.Empty;
    }
}
