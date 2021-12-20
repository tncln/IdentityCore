
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.Models
{
    public class UserUpdateViewModel
    {
        [Display(Name="Email :")]
        [Required(ErrorMessage = "Email Alanı Gereklidir")]
        [EmailAddress(ErrorMessage ="Lütfen Geçerli bir Email formatı giriniz")]
        public string Email { get; set; }
        [Display(Name = "Telefon :")]
        public string PhoneNumber { get; set; }
        public string PictureUrl { get; set; }
        public IFormFile Picture { get; set; }
        [Display(Name = "İsim :")]
        [Required(ErrorMessage = "Name Alanı Gereklidir")]
        public string Name { get; set; }
        [Display(Name = "Soyisim :")]
        [Required(ErrorMessage = "Surname Alanı Gereklidir")]
        public string SurName { get; set; }
    }
}
