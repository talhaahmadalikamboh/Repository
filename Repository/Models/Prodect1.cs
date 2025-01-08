using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Prodect1
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Product Name")]
        public string ProdectName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
