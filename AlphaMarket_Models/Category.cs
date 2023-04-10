using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace AlphaMarket_Models
{
    public class Category
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        [DisplayName("Имя Категории товаров")]
        
        public string? Name { get; set; }
        //  [DisplayName("Display Order")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Число должно быть больше 0")]
        public int? DisplayOrder { get; set; } 
    }
}
