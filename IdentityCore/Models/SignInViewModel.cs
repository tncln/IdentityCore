using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.Models
{
    public class SignInViewModel
    {
        [Display(Name ="Kullanıcı Adı:")]
        [Required(ErrorMessage ="Kullanıcı Adı Boş Geçilemez")]
        public string UserName { get; set; }

        [Display(Name = "Şifre:")]
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        public string Password { get; set; }
    }
}
