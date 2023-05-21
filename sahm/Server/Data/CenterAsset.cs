using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sahm.Server.Data
{
    public class CenterAsset
    {
        [Key]
        public int Id { get; set; }
        public int? Center_Id { get; set; } 
        public int? Asset_Id { get; set; }
        public int QTY { get; set; } 
        public string Barcode { get; set; } = string.Empty;

        [ForeignKey(nameof(Center_Id))]
        public Center Center{ get; set; }

        [ForeignKey(nameof(Asset_Id))]
        public Asset Asset{ get; set; }
    }
}
