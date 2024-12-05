using System.ComponentModel.DataAnnotations;

namespace WAD_00019330.Models
{
    public class SpareCategory
    {
        [Required]
        public int SpareCategoryId { get; set; }
        [Required(ErrorMessage = "Spare category name is required")]
        public string SpareCategoryName { get; set; }
    }
}
