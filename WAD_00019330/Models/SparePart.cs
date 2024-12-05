using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WAD_00019330.Models
{
    public class SparePart
    {
        [Required]
        public int SparePartId { get; set; }
        [Required(ErrorMessage = "Spare part name is required")]

        public string? SparePartName { get; set; }
        [Required(ErrorMessage = "Spare part quantity is required")]

        public int? SparePartQuantity { get; set; }
        [Required(ErrorMessage = "Spare part price is required")]

        public decimal? SparePartPrice { get; set; }
        public int? SparePartCategoryID { get; set; }
        [ForeignKey("SparePartCategoryID")]

        public SpareCategory? SpareCategory { get; set; }
    }
}
