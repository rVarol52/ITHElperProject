using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Infranstrucure.ViewModel.KullaniciViewModel
{
    public class ResultKullaniciViewModel
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSoyadi { get; set; }
        public string KullaniciMail { get; set; }
        public string KullaniciSifresi { get; set; }
        public bool KullaniciAktifligi { get; set; }
    }
}
