using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace AlphaMarket_Models
{
    public class ApplicationType
    {
        [Key]
        public int? Id { get; set; }
        //  [DisplayName("Имя Категории")]
        [Required]
        [DisplayName("Имя Типа товаров")]
        public string? Name { get; set; }
      
    }
}
