using System.ComponentModel.DataAnnotations;

namespace IUCULTURE.front.Models
{
    public class CreateClubModel
    {
        [Required(ErrorMessage="Kulüp adı gereklidir")]
        public string ClubName { get; set; } = null!;
        [Required(ErrorMessage = "Kulüp liderinin adı gereklidir")]
        public string ClubLeaderName { get; set; } = null!;
        [Required(ErrorMessage = "Kulüp tipi gereklidir")]
        public string ClubType { get; set; } = null!;
        [Required(ErrorMessage = "Kulüp Açıklaması gereklidir")]
        public string? ClubDefinition { get; set; }
        [Required(ErrorMessage = "Kulüp Açıklama Başlığı gereklidir")]
        public string? ClubDefinitionBold { get; set; }

        public string? ClubImage { get; set; } 
    }
}
