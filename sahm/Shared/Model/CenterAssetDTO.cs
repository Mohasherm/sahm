using System.ComponentModel.DataAnnotations;

namespace sahm.Shared.Model
{
    public class CenterAssetDTO
    {
        public int Id { get; set; }
        [Required]
        public int? Center_Id { get; set; }
        [Required]
        public int? Asset_Id { get; set; }
        [Required]
        public int QTY { get; set; }
        [Required]
        public string Barcode { get; set; } = string.Empty;
    }
}
