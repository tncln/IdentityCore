using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.Models
{
    public class UserSignUpViewModel
    {
        [Required( ErrorMessage ="Kullanıcı Adı Boş Geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "Şifre Eşleşmiyor")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "İsim Boş Geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyisim Boş Geçilemez")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Email Boş Geçilemez")]
        public string Email { get; set; }
    }
}
