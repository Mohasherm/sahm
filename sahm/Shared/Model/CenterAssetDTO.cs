using System.ComponentModel.DataAnnotations;

namespace sahm.Shared.Model
{
    public class CenterAssetDTO
    {
        public int Id { get; set; }
        [Required]
        public int? Center_Id { get; set; }
        public string Center_Name { get; set; } =string.Empty;
        [Required]
        public int? Asset_Id { get; set; }
        public string Asset_Name { get; set; } =string.Empty;
        [Required]
        [Range(1, int.MaxValue,ErrorMessage ="value must be more than 0")]
        public int QTY { get; set; }
        [Required]
        public string Barcode { get; set; } = string.Empty;
    }
}
