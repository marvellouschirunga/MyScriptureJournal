using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class Entry
    {
        public int Id { get; set; }
        [StringLength(32, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; } = string.Empty;
        [StringLength(256, MinimumLength = 1)]
        [Required]
        public string? Notes { get; set; } = string.Empty;
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_]+$")]
        [Required]
        public string? Book { get; set; } = string.Empty;
        [RegularExpression(@"^\d+:\d+$")]
        [Required(ErrorMessage = "<Please enter a valid scripture format (e.g., '1:1')>")]

        public String? Scripture { get; set; } = string.Empty;
    }
}