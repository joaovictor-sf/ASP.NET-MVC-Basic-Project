using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models {
    public class SerialNumber {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        // Navigation property to Item
        [ForeignKey("ItemId")]
        public Item? Item { get; set; }
        // Foreign key to Item
        public int? ItemId { get; set; }
    }
}