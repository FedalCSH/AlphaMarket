using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AlphaServer.Models
{
    public class ApplicationType
    {
        [Key]
        public int? Id { get; set; }
        //  [DisplayName("Имя Категории")]
        [Required]
        [DisplayName("Имя Категории товаров")]
        public string? Name { get; set; }
      
    }
}
