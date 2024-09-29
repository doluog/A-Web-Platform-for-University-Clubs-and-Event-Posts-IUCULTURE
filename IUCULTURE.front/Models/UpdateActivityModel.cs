using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IUCULTURE.front.Models
{
    public class UpdateActivityModel
    {
        [Required(ErrorMessage = "Id boş geçilemez")]
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string? ClubName { get; set; }

        [Required(ErrorMessage = "Etkinlik adı boş geçilemez")]
        public string? ActivityName { get; set; }
        [Required(ErrorMessage = "Etkinlik tarihi boş geçilemez")]
        public DateTime? ActivityDate { get; set; }
        [Required(ErrorMessage = "Etkinlik tipi boş geçilemez")]
        public string? ActivityType { get; set; }

        [Required(ErrorMessage = "Etkinlik açıklaması boş geçilemez")]
        public string? ActivityDefinition { get; set; }
        [Required(ErrorMessage = "Etkinlik açıklama başlığı boş geçilemez")]
        public string? ActivityDefinitionBold { get; set; }
        [Required(ErrorMessage = "Etkinlik görseli boş geçilemez")]
        public string? ActivityImage { get; set; }

        public SelectList? Clubs { get; set; }
     
    }
}
