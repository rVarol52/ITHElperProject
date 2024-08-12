using ITHelper.Infranstrucure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Infranstrucure.ViewModel.KullaniciViewModel
{
    public class CreateKullaniciViewModel
    {
        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        public string KullaniciSoyadi { get; set; }

        [Required]
        [EmailAddress]
        public string KullaniciMail { get; set; }

        [Required]
        [PasswordComplexity]
        public string KullaniciSifresi { get; set; }

        [Required]
        [Compare("KullaniciSifresi", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
