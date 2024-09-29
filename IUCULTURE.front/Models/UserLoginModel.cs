using System.ComponentModel.DataAnnotations;

namespace IUCULTURE.front.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        public string Password { get; set; } = null!;

    }
}
